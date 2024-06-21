namespace TimeTableGenerator.ML.POCO
{
    public class ProgramSemesterTable
    {
        public int ProgramSemesterID { get; set; }
        public string Title { get; set; }
        public int ProgramID { get; set; }
        public int SemesterID { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }
        public int SessionID { get; set; }
    }
}
