namespace TimeTableGenerator.ML.POCO
{
    public class ProgramSemesterSubjectTable
    {
        public int ProgramSemesterSubjectID { get; set; }
        public string SSTitle { get; set; }
        public int ProgramSemesterID { get; set; }
        public int LecturerSubjectID { get; set; }
        public bool IsSubjectActive { get; set; }
    }
}
