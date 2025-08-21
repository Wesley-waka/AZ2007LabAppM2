# Library App

## Description

Library App is a modular C# application for managing library patrons, books, and loans. It features a console interface, core business logic, infrastructure for JSON-based data storage, and unit tests for key services.

## Project Structure

- `AZ2007LabAppM2.sln`
- `readme.txt`
- .vscode/
  - `.vscode/launch.json`
- AccelerateDevGHCopilot/
  - src/
    - Library.ApplicationCore/
      - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Library.ApplicationCore.csproj`
      - Entities/
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Entities/Author.cs`
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Entities/Book.cs`
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Entities/BookItem.cs`
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Entities/Loan.cs`
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Entities/Patron.cs`
      - Enums/
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Enums/EnumHelper.cs`
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Enums/LoanExtensionStatus.cs`
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Enums/LoanReturnStatus.cs`
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Enums/MembershipRenewalStatus.cs`
      - Interfaces/
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Interfaces/ILoanRepository.cs`
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Interfaces/ILoanService.cs`
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Interfaces/IPatronRepository.cs`
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Interfaces/IPatronService.cs`
      - Services/
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Services/LoanService.cs`
        - `AccelerateDevGHCopilot/src/Library.ApplicationCore/Services/PatronService.cs`
    - Library.Console/
      - `AccelerateDevGHCopilot/src/Library.Console/appSettings.json`
      - `AccelerateDevGHCopilot/src/Library.Console/CommonActions.cs`
      - `AccelerateDevGHCopilot/src/Library.Console/ConsoleApp.cs`
      - `AccelerateDevGHCopilot/src/Library.Console/ConsoleState.cs`
      - `AccelerateDevGHCopilot/src/Library.Console/Library.Console.csproj`
      - `AccelerateDevGHCopilot/src/Library.Console/Program.cs`
      - Json/
        - `AccelerateDevGHCopilot/src/Library.Console/Json/Authors.json`
        - `AccelerateDevGHCopilot/src/Library.Console/Json/Books.json`
        - `AccelerateDevGHCopilot/src/Library.Console/Json/BookItems.json`
        - `AccelerateDevGHCopilot/src/Library.Console/Json/Loans.json`
        - `AccelerateDevGHCopilot/src/Library.Console/Json/Patrons.json`
    - Library.Infrastructure/
      - `AccelerateDevGHCopilot/src/Library.Infrastructure/Library.Infrastructure.csproj`
      - Data/
        - `AccelerateDevGHCopilot/src/Library.Infrastructure/Data/JsonData.cs`
        - `AccelerateDevGHCopilot/src/Library.Infrastructure/Data/JsonLoanRepository.cs`
        - `AccelerateDevGHCopilot/src/Library.Infrastructure/Data/JsonPatronRepository.cs`
  - tests/
    - UnitTests/
      - `AccelerateDevGHCopilot/tests/UnitTests/UnitTests.csproj`
      - `AccelerateDevGHCopilot/tests/UnitTests/PatronFactory.cs`
      - `AccelerateDevGHCopilot/tests/UnitTests/LoanFactory.cs`
      - ApplicationCore/
        - PatronService/
          - `AccelerateDevGHCopilot/tests/UnitTests/ApplicationCore/PatronService/RenewMembership.cs`
        - LoanService/
          - `AccelerateDevGHCopilot/tests/UnitTests/ApplicationCore/LoanService/ExtendLoan.cs`
          - `AccelerateDevGHCopilot/tests/UnitTests/ApplicationCore/LoanService/ReturnLoan.cs`

## Key Classes and Interfaces

- **Entities**
  - `Library.ApplicationCore.Entities.Patron`: Represents a library patron.
  - `Library.ApplicationCore.Entities.Loan`: Represents a book loan.
  - `Library.ApplicationCore.Entities.BookItem`: Represents a physical copy of a book.
  - `Library.ApplicationCore.Entities.Book`: Represents a book.
  - `Library.ApplicationCore.Entities.Author`: Represents an author.

- **Enums**
  - `Library.ApplicationCore.Enums.MembershipRenewalStatus`
  - `Library.ApplicationCore.Enums.LoanReturnStatus`
  - `Library.ApplicationCore.Enums.LoanExtensionStatus`
  - `Library.ApplicationCore.Enums.EnumHelper`: Utility for enum descriptions.

- **Interfaces**
  - `Library.ApplicationCore.IPatronRepository`: Patron data access.
  - `Library.ApplicationCore.ILoanRepository`: Loan data access.
  - `IPatronService`: Patron business logic.
  - `ILoanService`: Loan business logic.

- **Services**
  - `PatronService`: Handles patron membership renewal.
  - `LoanService`: Handles loan returns and extensions.

- **Infrastructure**
  - `JsonData`: Loads and saves data from JSON files.
  - `JsonPatronRepository`: Implements patron repository using JSON.
  - `JsonLoanRepository`: Implements loan repository using JSON.

- **Console**
  - `ConsoleApp`: Main console application logic.
  - `Program`: Application entry point.

## Usage

1. **Build the solution**  
   Open the solution file `AZ2007LabAppM2.sln` in Visual Studio or run:
   ```
   dotnet build
   ```

2. **Run the console app**  
   Navigate to the `AccelerateDevGHCopilot/src/Library.Console` directory and run:
   ```
   dotnet run
   ```

3. **Unit Tests**  
   Navigate to the `AccelerateDevGHCopilot/tests/UnitTests` directory and run:
   ```
   dotnet test
   ```

## License

This project is licensed under the MIT License. See LICENSE for details.