using System;
using Xunit;

namespace GradeBook.Tests;

public class BookTests
{
    [Fact] // attribute
    public void BookCalculatesAnAverageGrade()
    {
        // arrange - Where you put together test data
        var book = new InMemoryBook("Jake");
        book.AddGrade(89.1);
        book.AddGrade(100);
        book.AddGrade(70.1);


        // act - invoke method to compute a computation
        //var result = book.ShowStatistics();
        Statistics stats = book.GetStatistics();
        // assert - assert something about the value that was computed inside of act
        Assert.Equal(86.40, stats.Average);
    }
}