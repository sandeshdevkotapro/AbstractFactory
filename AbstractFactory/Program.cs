namespace DesignPatterns
{
    // Class for Printer
    // TODO#1: Convert to use Singleton pattern
    public class Printer
    {
        private static Printer? _instance;
        private Printer()
        {
            // Private constructor.
        }
        public static Printer Instance()
        {
            if (_instance == null)
            {
                _instance = new Printer();
            }
            return _instance;
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
            // Output: print out the string message 
        }
    }

    // Class template for Exam classes
    // TODO#2: Convert to use Abstract Factory pattern
    // Create an Exam interface and an Abstract Factory to manage the creation of different exam types.
    //Exam interface 
    public interface IExam
    {
        void Conduct();
        void Evaluate();
        void PublishResults();
    }
    // Create a abstract factory for exams
    public abstract class ExamFactory
    {
        public abstract IExam CreateExam();
    }

    //Concrete factory implementation of exams
    public class MathExam : IExam
    {
        public void Conduct()
        {
            
            Printer.Instance().Print("Conducting Math Exam");
            // Output: "Conducting Math Exam", should use Printer class to print the message
        }

        public void Evaluate()
        {
            // Output: "Evaluating Math Exam", should use Printer class to print the message
            Printer.Instance().Print("Evaluating Math Exam");
        }

        public void PublishResults()
        {
            // Output: "Publishing Math Exam Results", should use Printer class to print the message
            Printer.Instance().Print("Publishing Math Exam Results \n");
        }
    }
    //Concrete factory for maths exams:
    public class MathExamFactory : ExamFactory
    {
        public override IExam CreateExam()
        {
            return new MathExam();
        }
    }


    // TODO#5: Add new ScienceExam class
    //Concrete factory implementation of exams
    public class ScienceExam : IExam
    {
        public void Conduct()
        {

            Printer.Instance().Print("Conducting Science Exam");
            // Output: "Conducting Math Exam", should use Printer class to print the message
        }

        public void Evaluate()
        {
            // Output: "Evaluating Math Exam", should use Printer class to print the message
            Printer.Instance().Print("Evaluating Science Exam");
        }

        public void PublishResults()
        {
            // Output: "Publishing Math Exam Results", should use Printer class to print the message
            Printer.Instance().Print("Publishing Science Exam Results \n");
        }
    }
    //Concrete factory for science exams:
    public class ScienceExamFactory : ExamFactory
    {
        public override IExam CreateExam()
        {
            return new ScienceExam();
        }
    }

    // TODO#6: Add another ProgrammingExam class
    //Concrete factory implementation of exams
    public class ProgrammingExam : IExam
    {
        public void Conduct()
        {

            Printer.Instance().Print("Conducting Programming Exam");
            // Output: "Conducting Math Exam", should use Printer class to print the message
        }

        public void Evaluate()
        {
            // Output: "Evaluating Math Exam", should use Printer class to print the message
            Printer.Instance().Print("Evaluating Programming Exam");
        }

        public void PublishResults()
        {
            // Output: "Publishing programming Exam Results", should use Printer class to print the message
            Printer.Instance().Print("Publishing Programming Exam Results \n");
        }
    }
    //Concrete factory for programming exams:
    public class ProgrammingExamFactory : ExamFactory
    {
        public override IExam CreateExam()
        {
            return new ProgrammingExam();
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // TODO#7: Initialize Printer that uses Singleton pattern
            Printer p1 = Printer.Instance();
           
           
            // TODO#8: Test that the created Printer works, by calling the Print method
            p1.Print("This is a test message");


            // TODO#9: Ensure that only one Printer instance is used throughout the application.
            //         Try to create new Printer object and compare the two objects to check,
            //         that the new printer object is the same instance
            Printer p2 = Printer.Instance();
            bool isSameInstance = ReferenceEquals(p1, p2);
            Console.WriteLine("It is same instance: " + isSameInstance); //Gives true if it's same instance false if it's not.

            // TODO#10: Use Abstract Factory to create different types of exams.
            ExamFactory mathExamFactory = new MathExamFactory();
            IExam mathExam = mathExamFactory.CreateExam();
            mathExam.Conduct();
            mathExam.Evaluate();
            mathExam.PublishResults();

            ExamFactory scienceExamFactory = new ScienceExamFactory();
            IExam scienceExam = scienceExamFactory.CreateExam();
            scienceExam.Conduct();
            scienceExam.Evaluate();
            scienceExam.PublishResults();

            ExamFactory programmingExamFactory = new ProgrammingExamFactory();
            IExam progExam = programmingExamFactory.CreateExam();
            progExam.Conduct();
            progExam.Evaluate();
            progExam.PublishResults();
        }
    }

}
