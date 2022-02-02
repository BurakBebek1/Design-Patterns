using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher burak = new Teacher(mediator);
            burak.Name = "Burak";

            mediator.Teacher = burak;

            Student bugra = new Student(mediator);
            bugra.Name = "Bugra";

            Student omer = new Student(mediator);
            omer.Name = "Bugra";

            mediator.Students = new List<Student> { bugra, omer };

            burak.SendNewImageUrl("slide1.jpg");
            burak.RecieveQuestion("is it true?", bugra);

            Console.ReadLine();
        }
    }

    internal abstract class CourseMember
    {
        protected Mediator Mediator;

        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    internal class Teacher : CourseMember
    {
        public string Name { get; set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from a {0},{1}", student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide: {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0}, [1}", student.Name, answer);
        }
    }

    internal class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("Student receive image: {0}", url);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student received answer {0}", answer);
        }
    }

    internal class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}