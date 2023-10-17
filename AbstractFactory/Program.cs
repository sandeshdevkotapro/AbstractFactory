using System;

namespace DesignPatterns
{
    // Singleton pattern for Printer class
    public sealed class Printer
    {
        private Printer() { }
        private static Printer? instance;

        public static Printer GetInstance()
        {
            if (instance == null)
            {
                instance = new Printer();
            }
            return instance;
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }
    }

    // Interface for different exam types
    public interface IExam
    {
        void Conduct();
        void Evaluate();
        void PublishResults();
    }

    // MathExam class
    public class MathExam : IExam
    {
        public void Conduct()
        {
            Printer.GetInstance().Print("Conducting Math Exam");
        }

        public void Evaluate()
        {
            Printer.GetInstance().Print("Evaluating Math Exam");
        }

        public void PublishResults()
        {
            Printer.GetInstance().Print("Publishing Math Exam Results");
        }
    }

    // ScienceExam class
    public class ScienceExam : IExam
    {
        public void Conduct()
        {
            Printer.GetInstance().Print("Conducting Science Exam");
        }

        public void Evaluate()
        {
            Printer.GetInstance().Print("Evaluating Science Exam");
        }

        public void PublishResults()
        {
            Printer.GetInstance().Print("Publishing Science Exam Results");
        }
    }

    // ProgrammingExam class
    public class ProgrammingExam : IExam
    {
        public void Conduct()
        {
            Printer.GetInstance().Print("Conducting Programming Exam");
        }

        public void Evaluate()
        {
            Printer.GetInstance().Print("Evaluating Programming Exam");
        }

        public void PublishResults()
        {
            Printer.GetInstance().Print("Publishing Programming Exam Results");
        }
    }

    // Abstract Factory for creating different exam types
    public interface IExamFactory
    {
        IExam CreateExam(string examType);
    }

    // Concrete ExamFactory class
    public class ExamFactory : IExamFactory
    {
        public IExam CreateExam(string examType)
        {
            switch (examType)
            {
                case "Math":
                    return new MathExam();
                case "Science":
                    return new ScienceExam();
                case "Programming":
                    return new ProgrammingExam();
                default:
                    throw new ArgumentException("Invalid exam type");
            }
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize Printer using Singleton pattern
            Printer printer = Printer.GetInstance();

            // Test that the created Printer works by calling the Print method
            printer.Print("This is a test message.");

            // Ensure that only one Printer instance is used throughout the application
            Printer anotherPrinter = Printer.GetInstance();
            Console.WriteLine($"Are the two printer instances the same? {printer == anotherPrinter}");

            // Use Abstract Factory to create different types of exams
            IExamFactory examFactory = new ExamFactory();
            IExam mathExam = examFactory.CreateExam("Math");
            IExam scienceExam = examFactory.CreateExam("Science");
            IExam programmingExam = examFactory.CreateExam("Programming");

            // Call methods on the created exams
            mathExam.Conduct();
            scienceExam.Conduct();
            programmingExam.Conduct();
        }
    }
}