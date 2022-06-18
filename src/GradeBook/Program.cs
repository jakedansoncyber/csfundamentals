// See https://aka.ms/new-console-template for more information

namespace GradeBook;
class Program
{

    static void Main(string[] args)
    {
        var book = new DiskBook("GradeBook");
        book.GradeAdded += OnGradeAdded;

        EnterGrades(book);

        var stats = book.GetStatistics();

        Console.WriteLine($"The average grade is {stats.Average}");
        Console.WriteLine($"The highest grade is {stats.High}");
        Console.WriteLine($"The lowest grade is {stats.Low}");
    }

    private static void EnterGrades(Book book)
    {
        while (true)
        {
            Console.WriteLine("Enter a grade into your gradebook:");
            Console.WriteLine("or press 'q' to quit");
            var input = Console.ReadLine();
            if (input == "q")
            {
                break;
            }

            try
            {
                book.AddGrade(double.Parse(input));
            }
            catch (System.FormatException formatException)
            {
                Console.WriteLine(formatException.Message);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException);
            }
            finally
            {
                Console.WriteLine("**");
            }

        }
    }

    static void OnGradeAdded(object sender, EventArgs e){
        Console.WriteLine("A Grade Was Added");
    }
}