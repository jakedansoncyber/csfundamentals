using System;
using Xunit;

namespace GradeBook.Tests;

public class TypeTests
{

    public delegate string WriteLogDelegate(string logMessage);

    [Fact]
    public void WriteLogDelegateCanPointToMethod(){
        WriteLogDelegate log = new WriteLogDelegate(ReturnMessage);

        var result = log("Hello!");

        Assert.Equal("Hello!", result);
    }

    string ReturnMessage(string message)
    {
        return message;
    }

    [Fact]
    public void ValuesTypesAlsoPassByValue(){
        var x = GetInt();
        
        Assert.Equal(3, x);
    }

    private object GetInt()
    {
        return 3;
    }

    [Fact] // attribute
    public void CSharpCanPassByRef()
    {
        var book1 = GetBook("Book1");
        SetName(ref book1, "Book2");

        Assert.Equal("Book2", book1.Name);
    }

    private void SetName(ref InMemoryBook book1, string name)
    {
        book1.Name = name;
    }

    [Fact] // attribute
    public void GetBookReturnsDifferentObjects()
    {
        // arrange - Where you put together test data
        var book1 = GetBook("Book1");
        var book2 = GetBook("Book2");
        // act - invoke method to compute a computation

        // assert - assert something about the value that was computed inside of act
        Assert.Equal("Book1", book1.Name);
        Assert.Equal("Book2", book2.Name);
    }

    [Fact] // attribute
    public void TwoVarsCanReferenceSameObject()
    {
        var book1 = GetBook("Book1");
        var book2 = book1;
        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));
    }

    private InMemoryBook GetBook(string name)
    {
        return new InMemoryBook(name);
    }
}