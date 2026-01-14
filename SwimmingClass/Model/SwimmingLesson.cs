namespace SwimmingClass.Model
{
    public class SwimmingLesson
    {
        public int Id { get; set; }  // <== chave primária
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public DateTime Schedule { get; set; }
    }
}
