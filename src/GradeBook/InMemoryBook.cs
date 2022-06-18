using System.Collections.Generic;
using System;
namespace GradeBook;

public delegate void GradeAddedDelegate(object sender, EventArgs args); // delegate

public interface IBook{
    void AddGrade(double grade);
    Statistics GetStatistics();
    string Name { get; }
    event GradeAddedDelegate GradeAdded;
}
public class InMemoryBook : Book
{

    // Constructor
    public InMemoryBook(string name) : base(name)
    {
        grades = new List<double>();
        
    }
    public override void AddGrade(double grade){
        grades.Add(grade);
        if(GradeAdded != null)
        {
            GradeAdded(this, new EventArgs());
        }
    }
    
    public override event GradeAddedDelegate GradeAdded; // event
    
    public override Statistics GetStatistics(){
        var stats = new Statistics();
        stats.Low = double.MaxValue;
        stats.High = double.MinValue;
        double average = 0.0;
        foreach (double grade in grades){
            average += grade;
            if(grade > stats.High){
                stats.High = grade;
            }
            if(grade < stats.Low){
                stats.Low = grade;
            }
        }
        average /= grades.Count();
        stats.Average = average;
        return stats;
    }
    private List<double> grades;


    public const string CATEGORY = "Allows you to read only and never be changed";
    readonly string category = "Science"; // read only that allows you to only assign it during a constructor i.e. when an object is created.
                                          // OBV YOU CAN STILL ASSIGN IT AT VARIABLE ASSIGNMENT

    // public string Name // properties   OLD WAY OF DOING GETTERS AND SETTERS
    // {
    //     get
    //     {
    //         return name;
    //     }
    //     set
    //     {   
    //         if(!String.IsNullOrEmpty(value))
    //         {
    //         name = value;

    //         }
    //     }
    // }
    // private string name;
}