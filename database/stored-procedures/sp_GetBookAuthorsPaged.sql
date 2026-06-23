CREATE PROCEDURE sp_GetBookAuthorsPaged AS BEGIN SELECT Id, BookId, AuthorId FROM BookAuthors; END
