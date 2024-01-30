namespace EntityTest.Models
{
    public class StudentsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set;}
        public DepartmentDTO departmentDTO { get; set; }
    }
}
