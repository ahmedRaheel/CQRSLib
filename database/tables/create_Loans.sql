CREATE TABLE Loans (
    Id uniqueidentifier NOT NULL,
    BookId uniqueidentifier NOT NULL,
    MemberId uniqueidentifier NOT NULL,
    LoanDate datetime2 NOT NULL,
    DueDate datetime2 NOT NULL
);
