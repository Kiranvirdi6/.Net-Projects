using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRSDALPractice;
namespace SRSConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int op;
            do
            {
                Console.Clear();
                op = getUserOption();

                switch (op)
                {
                    case 0:
                        Console.WriteLine("Thanks for usinG SRS.");
                        break;
                    case 1:
                        addNewStudent();
                        break;
                    case 2:
                        addNewCourse();
                        break;

                    case 3:
                        displayStudent();
                        break;
                    case 4:
                        displayCourses();
                        break;
                    case 5:
                        assignCourseToStudent();
                        break;
                    case 6:
                        enrollStudentToCourse();
                        break;
                    case 7:
                        displayCourseEnrollmentList();
                        break;
                    case 8:
                        displayStudentCourseSelectionList();
                        break;
                    default:
                        Console.WriteLine("Invalid Option Selected");
                        break;
                }
                Console.WriteLine("Press a key to Continue...");
                Console.ReadKey();
            } while (op != 0);
        }

        private static void displayStudentCourseSelectionList()
        {
            throw new NotImplementedException();
        }

        private static void displayCourseEnrollmentList()
        {
            Console.WriteLine("Course Enrollment List");
            using (SRSDBPracticeEntities db = new SRSDBPracticeEntities())
            {
                List<Student> students = db.Students.ToList();
                foreach (Student s in students) {
                    Console.WriteLine($"{s.Id}: {s.FirstName} {s.LastName}");
                    List<Course> courses = s.Courses.ToList();
                    foreach (Course c in courses)
                    {
                        Console.WriteLine($"    {c.Code} {c.Title}");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void enrollStudentToCourse()
        {
            displayStudent();
            Console.WriteLine("Please enter Student ID");
            int sID = Convert.ToInt32(Console.ReadLine());

            displayCourses();
            Console.Write("Plesae enter course Id");
            int cid = Convert.ToInt32(Console.ReadLine());

            using (SRSDBPracticeEntities db = new SRSDBPracticeEntities())
            {
                Course selectedcourse = db.Courses.Where(x => x.Id == cid).First();
                Student studentToEnroll = db.Students.Where(x => x.Id == sID).First();

                selectedcourse.Students.Add(studentToEnroll);
                db.SaveChanges();


            }

      
            
        }

        private static void assignCourseToStudent()
        {
            throw new NotImplementedException();
        }

        private static void displayCourses()
        {
            Console.WriteLine("List of Courses");
            using (SRSDBPracticeEntities db = new SRSDBPracticeEntities())
            {
                var q = from c in db.Courses
                        select c;
                foreach (Course c in q)
                {
                    Console.WriteLine($"{c.Id} {c.Code} {c.Title}");
                }
            }
        }

        private static void displayStudent()
        {
            Console.WriteLine("List of Students");
            using (SRSDBPracticeEntities db = new SRSDBPracticeEntities())
            {
                List<Student> StudentList = db.Students.ToList();
                foreach (Student s in StudentList)
                {
                    Console.WriteLine($"{s.Id} {s.FirstName} {s.LastName}");
                }
            }
        }

        private static void addNewCourse()
        {
            Console.WriteLine("Plesae enter the course Code: ");
            string Code = Console.ReadLine();
            Console.WriteLine("Please enter the course Title: ");
            string Title = Console.ReadLine();

            using (SRSDBPracticeEntities db = new SRSDBPracticeEntities())
            {
                db.Courses.Add(new Course { Title = Title, Code = Code });
                db.SaveChanges();
            }
        }

        private static void addNewStudent()
        {
            Console.Write("Plesee enter your firstname: ");
            string FirstName = Console.ReadLine();
            Console.Write("Plesee enter your Lastname: ");
            string LastName = Console.ReadLine();

            Student s = new Student();
            s.FirstName = FirstName;
            s.LastName = LastName;

            using (SRSDBPracticeEntities db = new SRSDBPracticeEntities())
            {
                db.Students.Add(s);
                db.SaveChanges();
            }


        }

        private static int getUserOption()
        {
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. Add New Course");
            Console.WriteLine();

            Console.WriteLine("3. Display Student");
            Console.WriteLine("4. Display Course");
            Console.WriteLine();

            Console.WriteLine("5. Assign Course to Student");
            Console.WriteLine("6. Enroll Student to Course");
            Console.WriteLine();

            Console.WriteLine("7. Display Course Enrollment List");
            Console.WriteLine("8. Display Student Course Selection List");
            Console.WriteLine();

            Console.WriteLine("0. Exit");
            Console.WriteLine();

            Console.Write("Enter Your Option..");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
