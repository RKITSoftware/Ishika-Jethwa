using Microsoft.AspNetCore.Mvc;
using ActionMethod.BAL;
using ActionMethod.MAL;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;

namespace ActionMethod.Controllers
{
    /// <summary>
    /// Controller for managing TODO items.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoItemService _todoItemService;

        /// <summary>
        /// Constructor for TodoItemsController.
        /// </summary>
        /// <param name="todoItemService">The service for managing TODO items.</param>
        public TodoItemsController(TodoItemService todoItemService)
        {
            _todoItemService = todoItemService; 
        }

        /// <summary>
        /// Retrieves all TODO items.
        /// </summary>
        /// <returns>The list of TODO items.</returns>
        [HttpGet,Route("Getall")]
        public ActionResult<IEnumerable<TodoItem>> Getall()
        {
            var todoItems = _todoItemService.GetAllTodoItems();
            return Ok(todoItems);
        }

        /// <summary>
        /// Retrieves a specific TODO item by ID.
        /// </summary>
        /// <param name="id">The ID of the TODO item to retrieve.</param>
        /// <returns>The TODO item with the specified ID.</returns>
        [HttpGet("{id:int}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var todoItem = _todoItemService.GetTodoItemById(id);
            if (todoItem == null)
                return NotFound();

            return Ok(todoItem);
        }

        /// <summary>
        /// Creates a new TODO item.
        /// </summary>
        /// <param name="todoItem">The TODO item to create.</param>
        /// <returns>The created TODO item.</returns>
        [HttpPost]
        public RedirectResult Post([FromBody] TodoItem todoItem)
        {
            _todoItemService.AddTodoItem(todoItem);
            return Redirect("/api/TodoItems/Getall");
           
        }

        /// <summary>
        /// Updates an existing TODO item.
        /// </summary>
        /// <param name="id">The ID of the TODO item to update.</param>
        /// <param name="updatedTodoItem">The updated TODO item.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TodoItem updatedTodoItem)
        {
            var isUpdated = _todoItemService.UpdateTodoItem(id, updatedTodoItem);
            if (!isUpdated)
                return null;

            return Content("Update Successfully", "text/plain");
        }

        /// <summary>
        /// Deletes a TODO item.
        /// </summary>
        /// <param name="id">The ID of the TODO item to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _todoItemService.DeleteTodoItem(id);
            if (!isDeleted)
                return NotFound();

            return Ok("Delete Successfully");
        }


        /// <summary>
        /// Returns a PDF file containing the list of TODO items.
        /// </summary>
        /// <returns>A PDF file containing the list of TODO items.</returns>
        [HttpGet("pdf")]
        public IActionResult DownloadPdfFile()
        {
            try
            {
                // Generate the PDF content
                byte[] pdfBytes = GeneratePdfBytes();

                // Check if PDF content is valid
                if (pdfBytes == null || pdfBytes.Length == 0)
                {
                    // Log error
                    Console.WriteLine("Error: Generated PDF content is null or empty.");
                    return NotFound();
                }

                string filePath = "TodoItems.pdf";
                System.IO.File.WriteAllBytes(filePath, pdfBytes);
                return File(pdfBytes, "application/pdf", "TodoItems.pdf");
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error generating PDF: {ex.Message}");
                return StatusCode(500, "Error generating PDF");
            }
        }
        private byte[] GeneratePdfBytes()
        {
            try
            {
                // Create a MemoryStream to hold the PDF content
                MemoryStream memoryStream = new MemoryStream();

                // Create a PdfWriter to write to the MemoryStream
                PdfWriter writer = new PdfWriter(memoryStream);

                // Create a PdfDocument with the PdfWriter
                PdfDocument pdf = new PdfDocument(writer);

                // Create a iTextSharp Document
                iText.Layout.Document document = new iText.Layout.Document(pdf);

                // Add content to the document
                Paragraph header = new Paragraph("TODO items:");
                document.Add(header);

                // Add TODO items to the document
                foreach (var todoItem in _todoItemService.GetAllTodoItems())
                {
                    Paragraph item = new Paragraph($"- {todoItem.Title}");
                    document.Add(item);
                }

                // Close the document
                document.Close();

                // Return the PDF content as a byte array
                return memoryStream.ToArray();
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error generating PDF: {ex.Message}");
                throw; // Rethrow the exception for further handling
            }
        }

    }
}
