using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.DL;
using Birth_Certificate_Generator.ML;
using Birth_Certificate_Generator.ML.POCO;
using Birth_Certificate_Generator.Other;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using ServiceStack.OrmLite;
using System.Data;

namespace Birth_Certificate_Generator.BL.Handler
{
    /// <summary>
    /// Business logic handler for managing birth certificates, including validation and PDF generation.
    /// </summary>
    public class BLBCT01Handler : IBCT01
    {
        #region Private Members
        /// <summary>
        /// The context for birth certificate request data operations.
        /// </summary>
        private readonly DBBCR01Context _objDbBCR01;

        /// <summary>
        /// ORM Lite connection factory for database operations.
        /// </summary>
        private readonly OrmLiteConnectionFactory _dbFactory;

        /// <summary>
        /// The path where generated certificate PDFs are stored.
        /// </summary>
        private string _path = Directory.GetCurrentDirectory() + "\\Certificate\\";
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the BLBCT01Handler class with the specified context and ORM Lite factory.
        /// </summary>
        /// <param name="dbBCR01Context">Database context for birth certificate requests.</param>
        /// <param name="dbFactory">ORM Lite connection factory for database operations.</param>
        public BLBCT01Handler(DBBCR01Context dbBCR01Context, OrmLiteConnectionFactory dbFactory)
        {
            _objDbBCR01 = dbBCR01Context;
            _dbFactory = dbFactory;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Validates whether a certificate request with the given ID already exists.
        /// </summary>
        /// <param name="requestId">The ID of the certificate request to validate.</param>
        /// <returns>A Response object indicating validation success or failure.</returns>
        public Response Validation(int requestId)
        {
            Response response = new Response();
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                int count = (int)db.Count<BCT01>(x => x.T01F02 == requestId); // Check if the request ID exists
                if (count > 0)
                {
                    response.IsSuccess = false;
                    response.Message = $"Request ID {requestId} already exists."; // Handle duplicate case
                }
            }

            return response;
        }

        /// <summary>
        /// Generates a birth certificate PDF and updates the database with the new certificate.
        /// </summary>
        /// <param name="id">The index of the certificate request to generate.</param>
        /// <returns>A Response object with the file path or error message.</returns>
        public Response FinalCertificate(int id)
        {
            Response response = new Response();
            DataSet dtResult = _objDbBCR01.GetAllData(); // Get all data from the context

            try
            {
                if (dtResult.Tables.Count != 0 && dtResult.Tables[0].Rows.Count > 0)
                {
                    DataRow row = dtResult.Tables[0].Rows[id - 1]; // Get the row by index
                    string childFirstName = row["D01F02"].ToString();
                    string RequestID = row["C01F01"].ToString();
                    string certificateNumber = Guid.NewGuid().ToString(); // Unique certificate number
                    DateTime issueDate = DateTime.Now;

                    _path = _path + "Certi_" + RequestID + "_" + childFirstName + "_" + ".pdf"; // Path for the generated PDF

                    // Create the PDF document
                    using (FileStream fs = new FileStream(_path, FileMode.Create))
                    {
                        Document doc = new Document();
                        PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                        // Apply the custom page event for page borders
                        writer.PageEvent = new PageBorderEvent(3f, 20f); // Border thickness and margin

                        doc.Open(); // Open the document for writing

                        // Title with underline and proper spacing
                        Font titleFont = new Font(Font.FontFamily.HELVETICA, 24, Font.BOLD);
                        Chunk titleChunk = new Chunk("Birth Certificate", titleFont);
                        titleChunk.SetUnderline(1f, -2f); // Underline the title
                        Paragraph titleParagraph = new Paragraph(titleChunk)
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 30 // Space after the title
                        };

                        doc.Add(titleParagraph);

                        // Create the table for certificate number and date of issue
                        PdfPTable mainTable = new PdfPTable(2)
                        {
                            WidthPercentage = 100, // The table spans the entire width
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            SpacingBefore = 20 // Space between the title and the table
                        };

                        // Add certificate number and date of issue to the table
                        void AddMainTableRow(string key, string value)
                        {
                            Font cellFont = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);
                            PdfPCell keyCell = new PdfPCell(new Phrase(key, cellFont))
                            {
                                Border = PdfPCell.BOX, // Borders for the cell
                                BorderWidth = 1f,
                                Padding = 10f // Padding within the cell
                            };

                            PdfPCell valueCell = new PdfPCell(new Phrase(value, cellFont))
                            {
                                Border = PdfPCell.BOX,
                                BorderWidth = 1f,
                                Padding = 10f // Padding within the cell
                            };

                            mainTable.AddCell(keyCell); // Add key-value pairs to the table
                            mainTable.AddCell(valueCell);
                        }

                        AddMainTableRow("Certificate Number", certificateNumber); // Add certificate number
                        AddMainTableRow("Date of Issue", issueDate.ToString("dd-MM-yyyy HH:mm:ss")); // Add date of issue

                        doc.Add(mainTable); // Add the first table to the document

                        // Create the second table for additional personal information
                        PdfPTable infoTable = new PdfPTable(2)
                        {
                            WidthPercentage = 100, // The table spans the entire width
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            SpacingBefore = 20 // Space between the tables
                        };

                        // Adding rows for personal information to the second table
                        void AddInfoTableRow(string key, string value)
                        {
                            Font cellFont = new Font(Font.FontFamily.HELVETICA, 12);
                            PdfPCell keyCell = new PdfPCell(new Phrase(key, cellFont))
                            {
                                Border = PdfPCell.BOX,
                                BorderWidth = 1f,
                                Padding = 10f // Padding within the cell
                            };

                            PdfPCell valueCell = new PdfPCell(new Phrase(value, cellFont))
                            {
                                Border = PdfPCell.BOX,
                                BorderWidth = 1f,
                                Padding = 10f
                            };

                            infoTable.AddCell(keyCell); // Add key-value pairs to the second table
                            infoTable.AddCell(valueCell);
                        }

                        // Add personal information to the second table
                        AddInfoTableRow("Child's First Name", childFirstName); // Add child's first name
                        AddInfoTableRow("Child's Last Name", row["D01F03"].ToString()); // Add child's last name
                        AddInfoTableRow("Date of Birth", row["D01F04"].ToString()); // Add date of birth
                        AddInfoTableRow("Place of Birth", row["D01F05"].ToString()); // Add place of birth
                        AddInfoTableRow("Gender", row["D01F06"].ToString()); // Add gender
                        AddInfoTableRow("Parent's Name", row["D01F07"].ToString()); // Add parent's name
                        AddInfoTableRow("Submission Date", row["C01F03"].ToString()); // Add submission date

                        doc.Add(infoTable); // Add the second table to the document

                        // Authorized signature and underline
                        Paragraph signatureParagraph = new Paragraph("Authorized Signature:", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD))
                        {
                            SpacingBefore = 270,
                            Alignment = Element.ALIGN_RIGHT
                        };

                        doc.Add(signatureParagraph); // Add authorized signature section

                        LineSeparator signatureLine = new LineSeparator(1f, 60f, BaseColor.BLACK, Element.ALIGN_RIGHT, -10f); // Signature line
                        doc.Add(new Chunk(signatureLine)); // Add signature line

                        // Insert the certificate record into the database
                        BCT01 certificate = new BCT01
                        {
                            T01F02 = int.Parse(RequestID), // Request ID
                            T01F03 = _path, // Path to the generated certificate
                            T01F04 = issueDate // Certificate issue date
                        };

                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            db.Insert(certificate); // Insert the certificate record into the database

                            BCR01 feildToUpdate = new BCR01
                            {
                                C01F01 = int.Parse(RequestID), // Certificate request ID
                                C01F04 = EnmStatus.A.ToString() // Update the status to approved
                            };

                            db.UpdateOnlyFields<BCR01>(feildToUpdate, fields => new { fields.C01F04 }, where => where.C01F01 == int.Parse(RequestID));
                        }

                        doc.Close(); // Always close the document to save changes
                    }

                    response.Message = _path; // Path to the generated certificate PDF
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response; // Return the response object
        }

        #endregion
    }

    /// <summary>
    /// Custom page event handler for adding borders to PDF pages.
    /// </summary>
    public class PageBorderEvent : PdfPageEventHelper
    {
        #region Private Members
        private readonly float _borderThickness;
        private readonly float _margin;

        #endregion

        /// <summary>
        /// Initializes a new instance of the PageBorderEvent with the specified border thickness and margin.
        /// </summary>
        /// <param name="borderThickness">The thickness of the border to draw.</param>
        /// <param name="margin">The margin within which the border is drawn.</param>
        public PageBorderEvent(float borderThickness, float margin)
        {
            _borderThickness = borderThickness;
            _margin = margin;
        }

        /// <summary>
        /// Draws a border around the page when the page ends.
        /// </summary>
        /// <param name="writer">The PDF writer used to draw the border.</param>
        /// <param name="document">The document object representing the current page.</param>
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte content = writer.DirectContent;
            Rectangle pageSize = document.PageSize;

            // Set the border thickness
            content.SetLineWidth(_borderThickness);

            // Draw a border around the page
            content.Rectangle(
                _margin, // Left margin
                _margin, // Bottom margin
                pageSize.Width - 2 * _margin, // Width of the border
                pageSize.Height - 2 * _margin // Height of the border
            );

            content.Stroke(); // Draw the border
        }
    }
}
