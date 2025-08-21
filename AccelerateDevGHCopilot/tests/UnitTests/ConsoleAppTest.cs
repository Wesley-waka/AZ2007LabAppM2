using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Library.ApplicationCore;
using Library.ApplicationCore.Entities;
using Library.ApplicationCore.Enums;
// using Library.ConsoleApp;
// If ConsoleApp is in a different namespace, update the using statement accordingly.
// For example, if ConsoleApp is in Library.Console, use:
// using Library.Console;
// using Library.Console;


[Fact]
public async Task LoanDetails_ReturnsLoanDetails_WhenExtendLoanedBook()
{
    var loan = new Loan
    {
        Id = 1,
        DueDate = DateTime.Today.AddDays(7),
        BookItem = new BookItem { Book = new Book { Title = "Book1", Author = new Author { Name = "Author1" } } }
    };
    var patron = new Patron { Id = 2, Name = "Patron2", Loans = new List<Loan> { loan } };

    var loanServiceMock = new Mock<ILoanService>();
    loanServiceMock.Setup(s => s.ExtendLoan(loan.Id)).ReturnsAsync(LoanStatus.Success);

    var patronRepoMock = new Mock<IPatronRepository>();
    patronRepoMock.Setup(r => r.GetPatron(patron.Id)).ReturnsAsync(patron);

    var loanRepoMock = new Mock<ILoanRepository>();
    loanRepoMock.Setup(r => r.GetLoan(loan.Id)).ReturnsAsync(loan);

    var app = CreateConsoleApp(patronRepoMock, loanRepoMock, loanServiceMock);

    // Set required fields via reflection
    typeof(ConsoleApp).GetField("selectedLoanDetails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
        .SetValue(app, loan);
    typeof(ConsoleApp).GetField("selectedPatronDetails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
        .SetValue(app, patron);

    // Patch Console.ReadLine to simulate "e" for ExtendLoanedBook
    var originalIn = Console.In;
    try
    {
        var sr = new System.IO.StringReader("e\n");
        Console.SetIn(sr);

        var method = app.GetType().GetMethod("LoanDetails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var task = (Task<ConsoleState>)method.Invoke(app, null);
        var state = await task;
        Assert.Equal(ConsoleState.LoanDetails, state);
    }
    finally
    {
        Console.SetIn(originalIn);
    }
}

[Fact]
public async Task LoanDetails_ReturnsLoanDetails_WhenReturnLoanedBook()
{
    var loan = new Loan
    {
        Id = 1,
        DueDate = DateTime.Today.AddDays(7),
        BookItem = new BookItem { Book = new Book { Title = "Book1", Author = new Author { Name = "Author1" } } }
    };
    var patron = new Patron { Id = 2, Name = "Patron2", Loans = new List<Loan> { loan } };

    var loanServiceMock = new Mock<ILoanService>();
    loanServiceMock.Setup(s => s.ReturnLoan(loan.Id)).ReturnsAsync(LoanStatus.Success);

    var patronRepoMock = new Mock<IPatronRepository>();
    patronRepoMock.Setup(r => r.GetPatron(patron.Id)).ReturnsAsync(patron);

    var loanRepoMock = new Mock<ILoanRepository>();
    loanRepoMock.Setup(r => r.GetLoan(loan.Id)).ReturnsAsync(loan);

    var app = CreateConsoleApp(patronRepoMock, loanRepoMock, loanServiceMock);

    typeof(ConsoleApp).GetField("selectedLoanDetails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
        .SetValue(app, loan);
    typeof(ConsoleApp).GetField("selectedPatronDetails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
        .SetValue(app, patron);

    var originalIn = Console.In;
    try
    {
        var sr = new System.IO.StringReader("r\n");
        Console.SetIn(sr);

        var method = app.GetType().GetMethod("LoanDetails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var task = (Task<ConsoleState>)method.Invoke(app, null);
        var state = await task;
        Assert.Equal(ConsoleState.LoanDetails, state);
    }
    finally
    {
        Console.SetIn(originalIn);
    }
}

[Fact]
public async Task LoanDetails_ReturnsQuit_WhenQuitSelected()
{
    var loan = new Loan
    {
        Id = 1,
        DueDate = DateTime.Today.AddDays(7),
        BookItem = new BookItem { Book = new Book { Title = "Book1", Author = new Author { Name = "Author1" } } }
    };
    var patron = new Patron { Id = 2, Name = "Patron2", Loans = new List<Loan> { loan } };

    var app = CreateConsoleApp();

    typeof(ConsoleApp).GetField("selectedLoanDetails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
        .SetValue(app, loan);
    typeof(ConsoleApp).GetField("selectedPatronDetails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
        .SetValue(app, patron);

    var originalIn = Console.In;
    try
    {
        var sr = new System.IO.StringReader("q\n");
        Console.SetIn(sr);

        var method = app.GetType().GetMethod("LoanDetails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var task = (Task<ConsoleState>)method.Invoke(app, null);
        var state = await task;
        Assert.Equal(ConsoleState.Quit, state);
    }
    finally
    {
        Console.SetIn(originalIn);
    }
}

[Fact]
public async Task LoanDetails_ReturnsPatronSearch_WhenSearchPatronsSelected()
{
    var loan = new Loan
    {
        Id = 1,
        DueDate = DateTime.Today.AddDays(7),
        BookItem = new BookItem { Book = new Book { Title = "Book1", Author = new Author { Name = "Author1" } } }
    };
    var patron = new Patron { Id = 2, Name = "Patron2", Loans = new List<Loan> { loan } };

    var app = CreateConsoleApp();

    typeof(ConsoleApp).GetField("selectedLoanDetails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
        .SetValue(app, loan);
    typeof(ConsoleApp).GetField("selectedPatronDetails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
        .SetValue(app, patron);

    var originalIn = Console.In;
    try
    {
        var sr = new System.IO.StringReader("s\n");
        Console.SetIn(sr);

        var method = app.GetType().GetMethod("LoanDetails", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var task = (Task<ConsoleState>)method.Invoke(app, null);
        var state = await task;
        Assert.Equal(ConsoleState.PatronSearch, state);
    }
    finally
    {
        Console.SetIn(originalIn);
    }
}
