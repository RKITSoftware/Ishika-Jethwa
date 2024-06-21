namespace TimeTableGenerator.ML.POCO
{
    public class LecturerSubjectTable
    {
        public int LecturerSubjectID { get; set; }
        public string SubjectTitle { get; set; }
        public int LecturerID { get; set; }
        public int CourseID { get; set; }
        public bool IsActive { get; set; }
    }
}
