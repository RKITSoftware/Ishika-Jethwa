namespace TimeTableGenerator.ML.POCO
{
    public class CourseTable
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int CrHrs { get; set; }
        public int RoomTypeID { get; set; }
    }
}
