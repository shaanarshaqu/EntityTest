namespace EntityTest.Models
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Dep { get; set; }
        public List<StudentsDTO> Students { get; set; }
    }
}
