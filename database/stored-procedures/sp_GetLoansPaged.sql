CREATE PROCEDURE sp_GetLoansPaged AS BEGIN SELECT Id, BookId, MemberId, LoanDate, DueDate FROM Loans; END
