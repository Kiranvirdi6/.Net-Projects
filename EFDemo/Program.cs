using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student List");
            using (StudentDBEntities db = new StudentDBEntities())
            {
          
                List<Student> StudentList = db.Students.ToList();
                foreach (Student s in StudentList)
                {
                 
                    Console.WriteLine($"{s.FirstName} { s.LastName}");
                }
                Console.ReadKey();
            }
        }
    }
}
