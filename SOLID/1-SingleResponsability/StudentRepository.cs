using System.Text;

namespace SingleResponsability
{
    // administrar los datos para el modelo Student
    public class StudentRepository
    {
        private static FakeStorage<Student> storage;

        public StudentRepository()
        {
            storage = new FakeStorage<Student>();
            InitData();
        }

        private void InitData()
        {
            storage.Add(new Student(1, "Pepito Pérez", new List<double>() { 3, 4.5 }));
            storage.Add(new Student(2, "Mariana Lopera", new List<double>() { 4, 5 }));
            storage.Add(new Student(1, "Pepito Pérez", new List<double>() { 3, 4.5 }));
        }

        public IEnumerable<Student> GetAll()
        {
            return storage.GetAll();

        }
    }
}