using System.Linq;

namespace EntityTest.Models
{


    public interface IStudents
    {
        IEnumerable<StudentsDTO> GetUsers();
        void AddUsers(StudentsDTO users);
        void RemoveUsers(int id);
        void UpdateUser(int id, StudentsDTO user);
    }





    public class Students: IStudents
    {
        private readonly StudentsDb _dbContext;
        public Students(StudentsDb dbContext)
        {
            _dbContext = dbContext;
        }



        public IEnumerable<StudentsDTO> GetUsers()
        {
            return _dbContext.Studentsdbset.ToList();
        }




        public void AddUsers(StudentsDTO users)
        {
            _dbContext.Studentsdbset.Add(users);
            _dbContext.SaveChanges();
        }


        public void RemoveUsers(int id)
        {
            var user= _dbContext.Studentsdbset.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _dbContext.Studentsdbset.Remove(user); 
                _dbContext.SaveChanges();
            }
        }


        public void UpdateUser(int id, StudentsDTO user)
        {
            var Updateuser = _dbContext.Studentsdbset.FirstOrDefault(x => x.Id == id);
            if (Updateuser != null)
            {
                Updateuser.Name= user.Name;
                Updateuser.Age= user.Age;
                _dbContext.SaveChanges();
            }
        }
    }
}
