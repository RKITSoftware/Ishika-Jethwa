using ServiceStack.OrmLite;
using System.Data;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.BL.Context
{
    public class BLImplementationHandler<T> : IGenInterface<T> where T : class
    {
        /// <summary>
        /// The current user object.
        /// </summary>
        private T objT;

        /// <summary>
        /// ORM Lite connection factory for database connections.
        /// </summary>
        private readonly OrmLiteConnectionFactory _dbFactory;

        /// <summary>
        /// Constructor for BLUSR01Handler for connection factory and userRepository.
        /// </summary>
        /// <param name="dbFactory">ORM Lite connection factory.</param>
        /// <param name="userrepository">Interface For User Related Data operation</param>
        public BLImplementationHandler(OrmLiteConnectionFactory dbFactory)
        {

            _dbFactory = dbFactory;
        }
        public enmOperation Operation { get; set; }

        public Response GetAll()
        {
            Response response = new Response();
            DataSet dtResult;
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                dtResult = db.Select<T>().ConvertToDataSet();
            }

            if (dtResult.Tables.Count == 0 || dtResult.Tables[0].Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "Not Found";
            }
            response.Data = dtResult;
            return response;
        }

        public Response GetbyID(int id)
        {
            Response response = new Response();
            DataSet dtResult;
            List<T> result;
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                result = new List<T> { db.SingleById<T>(id) }; // Fetch the single entity and wrap it in a list

            }
            if (result.FirstOrDefault() == null)
            {
                response.IsSuccess = false;
                response.Message = "Not Found";
                return response;
            }
            dtResult = result.ConvertToDataSet<T>();

            response.Data = dtResult;
            return response;
        }

        public Response Save()
        {
            Response response = new Response();
            if (Operation == enmOperation.I)
            {
                using (IDbConnection db = _dbFactory.OpenDbConnection())
                {
                    db.Insert(objT);
                }
                response.Message = enmOperation.I.GetMessage();
            }
            else
            {
                using (IDbConnection db = _dbFactory.OpenDbConnection())
                {
                    db.Update(objT);
                }
                response.Message = enmOperation.U.GetMessage();
            }
            return response;
        }

        public Response Validate(T obj)
        {
            Response response = new Response();
            var type = obj.GetType();
            objT = Activator.CreateInstance<T>();
            objT = obj;
            int count;
            switch (type.Name)
            {

                case "SessionTable":
                    SessionTable objSession = obj as SessionTable;
                    if (Operation == enmOperation.I)
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((SessionTable p) => p.Title == objSession.Title);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = "Duplicate entry found";
                        }
                    }
                    else
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((SessionTable p) => p.Title == objSession.Title && p.SessionID != objSession.SessionID);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = $"does not exist";
                        }
                    }

                    break;

                case "DayTable":
                    DayTable objDay = obj as DayTable;
                    if (Operation == enmOperation.I)
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((DayTable p) => p.Name == objDay.Name);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = "Duplicate entry found";
                        }
                    }
                    else
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((DayTable p) => p.Name == objDay.Name && p.DayID != objDay.DayID);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = $"does not exist";
                        }
                    }
                    break;


                case "LabTable":
                    LabTable objLab = obj as LabTable;
                    if (Operation == enmOperation.I)
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((LabTable p) => p.LabNo == objLab.LabNo);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = "Duplicate entry found";
                        }
                    }
                    else
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((LabTable p) => p.LabNo == objLab.LabNo && p.LabId != objLab.LabId);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = $"does not exist";
                        }
                    }
                    break;

                case "LecturerTable":
                    LecturerTable objLecturer = obj as LecturerTable;
                    if (Operation == enmOperation.I)
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((LecturerTable p) => p.FullName == objLecturer.FullName || p.ContactNo == objLecturer.ContactNo);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = "Duplicate entry found";
                        }
                    }
                    else
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((LecturerTable p) => p.FullName == objLecturer.FullName || p.ContactNo == objLecturer.ContactNo && p.LecturerId != objLecturer.LecturerId);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = $"does not exist";
                        }
                    }
                    break;

                case "ProgramTable":
                    ProgramTable objProgram = obj as ProgramTable;
                    if (Operation == enmOperation.I)
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((ProgramTable p) => p.Name == objProgram.Name);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = "Duplicate entry found";
                        }
                    }
                    else
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((ProgramTable p) => p.Name == objProgram.Name && p.ProgramId != objProgram.ProgramId);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = $"does not exist";
                        }
                    }
                    break;

                case "RoomTable":
                    RoomTable objRoom = obj as RoomTable;
                    if (Operation == enmOperation.I)
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((RoomTable p) => p.RoomNo == objRoom.RoomNo);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = "Duplicate entry found";
                        }
                    }
                    else
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((RoomTable p) => p.RoomNo == objRoom.RoomNo && p.RoomId != objRoom.RoomId);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = $"does not exist";
                        }
                    }
                    break;

                case "SemesterTable":
                    SemesterTable objSemester = obj as SemesterTable;
                    if (Operation == enmOperation.I)
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((SemesterTable p) => p.SemesterName == objSemester.SemesterName);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = "Duplicate entry found";
                        }
                    }
                    else
                    {
                        using (IDbConnection db = _dbFactory.OpenDbConnection())
                        {
                            count = (int)db.Count((SemesterTable p) => p.SemesterName == objSemester.SemesterName && p.SemesterId != objSemester.SemesterId);
                        }
                        if (count > 0)
                        {
                            response.IsSuccess = false;
                            response.Message = $"does not exist";
                        }
                    }
                    break;



            }

            return response;
        }

        public Response ValidateOnDelete(int id)
        {
            T count;
            Response response = new Response();
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                count = db.SingleById<T>(id);
            }
            if (count == null)
            {

                response.IsSuccess = false;
                response.Message = $"This Id = {id} not Exist";


            }
            return response;
        }
        public Response DeletebyID(int id)
        {
            int rowsAffected;
            Response response = new Response();
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                rowsAffected = db.DeleteById<T>(id);
            }
            if (rowsAffected == 0)
            {
                response.IsSuccess = false;
                response.Message = $"ID {id} does not exist";
            }
            else
            {
                response.Message = enmOperation.D.GetMessage();
            }

            return response;
        }
    }
}
