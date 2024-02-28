using System.Text;
class Student
{
    public string LastName;
    public string FirstName;
    public string MiddleName;
    public int BirthYear;
    public int Course;
    public string Group;
    public Dictionary<string, int> Grades;

    public double AverageGrade()
    {
        return Grades.Values.Average();
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        List<Student> students = new List<Student>
        {
            new()
            {
                LastName = "Овчинніков", FirstName = "Костянтин", MiddleName = "Ігорович", BirthYear = 2006, Course = 1, 
                Group = "ІК-32", Grades = new Dictionary<string, int>
                {
                    { "Вища математика", 59}, { "Англійська мова", 58},
                    { "Програмування", 57}, { "Теорія алгоритмів", 56}, { "Фізика", 55}
                }
            },
            new()
            {
                LastName = "Мейстер", FirstName = "Кирило", MiddleName = "Артурович", BirthYear = 2006, Course = 2,
                Group = "ІК-34", Grades = new Dictionary<string, int>
                {
                    { "Вища математика", 80}, { "Англійська мова", 85},
                    { "Програмування", 90}, { "Теорія алгоритмів", 80}, { "Фізика", 85}
                }
            },
            new()
            {
                LastName = "Дмитрук", FirstName = "Андрій", MiddleName = "Андрійович", BirthYear = 2006, Course = 2,
                Group = "ІК-31", Grades = new Dictionary<string, int>
                {
                    { "Вища математика", 80}, { "Англійська мова", 85},
                    { "Програмування", 90}, { "Теорія алгоритмів", 80}, { "Фізика", 85}
                }
            },
            new()
            {
                LastName = "Ясинський", FirstName = "Максим", MiddleName = "Батькович", BirthYear = 2006, Course = 2,
                Group = "ІК-31", Grades = new Dictionary<string, int>
                {
                    { "Вища математика", 90}, { "Англійська мова", 100},
                    { "Програмування", 50}, { "Теорія алгоритмів", 55}, { "Фізика", 58}
                }
            },
            new()
            {
                LastName = "Швець", FirstName = "Андрій", MiddleName = "Володимирович", BirthYear = 2006, Course = 1,
                Group = "ІК-34", Grades = new Dictionary<string, int>
                {
                    { "Вища математика", 85}, { "Англійська мова", 87},
                    { "Програмування", 90}, { "Теорія алгоритмів", 89}, { "Фізика", 88}
                }
            },
            new()
            {
                LastName = "Котенко", FirstName = "Вадим", MiddleName = "Іванович", BirthYear = 2006, Course = 1,
                Group = "ІК-32", Grades = new Dictionary<string, int>
                {
                    { "Вища математика", 90}, { "Англійська мова", 100},
                    { "Програмування", 66}, { "Теорія алгоритмів", 77}, { "Фізика", 88}
                }
            }
        };
    
        // Відсортований список студентів за курсом та прізвищем
        var sortedStudents = students.OrderBy(student => student.Course).ThenBy(student => student.LastName);
        Console.WriteLine("Список студентів:");
        foreach (var student in sortedStudents)
            Console.WriteLine($"{student.LastName} {student.FirstName} {student.MiddleName}, Курс {student.Course}, Група {student.Group}");
        
        // Групування за групою
        var groupedByGroup = students.GroupBy(student => student.Group);
        
        // Середній бал кожної групи з кожного предмету
        foreach (var group in groupedByGroup)
        {
            Dictionary<string, double> averageGrades = new Dictionary<string, double>();
            foreach (var student in group)
            {
                foreach (var subject in student.Grades)
                {
                    if (!averageGrades.ContainsKey(subject.Key))
                        averageGrades.Add(subject.Key, subject.Value);
                    else
                        averageGrades[subject.Key] += subject.Value;
                }
            }
            
            Console.WriteLine($"\nСередні бали групи {group.Key}:");
            foreach (var subject in averageGrades)
                Console.WriteLine($"{subject.Key}: {subject.Value / group.Count()}");
        }
        
        // Найстарший та наймолодший студенти
        var oldestStudent = students.OrderByDescending(student => student.BirthYear).First();
        var youngestStudent = students.OrderByDescending(student => student.BirthYear).Last();
        Console.WriteLine($"\nНайстарший студент: {oldestStudent.LastName} {oldestStudent.FirstName}, Група {oldestStudent.Group}");
        Console.WriteLine($"Наймолодший студент: {youngestStudent.LastName} {youngestStudent.FirstName}, Група {youngestStudent.Group}");
        
        // Найуспішніший студент
        foreach (var group in groupedByGroup)
        {
            Dictionary<Student, double> averageGrades = new Dictionary<Student, double>();
            foreach (var student in group)
                averageGrades.Add(student, student.AverageGrade());

            var bestStudent = averageGrades.MaxBy(x => x.Value);
            Console.WriteLine($"\nНайуспішніший студент {group.Key}: {bestStudent.Key.LastName} {bestStudent.Key.FirstName}\n" +
                              $"Середній бал: {bestStudent.Value}");
        }
        
        Console.ReadKey();
    }
}