// See https://aka.ms/new-console-template for more information
namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            File.Create("${name}.txt");
            var writer = File.AppendText("${name}.txt");
            writer.WriteLine(grade);
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}