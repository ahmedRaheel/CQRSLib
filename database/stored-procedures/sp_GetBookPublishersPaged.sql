CREATE PROCEDURE sp_GetBookPublishersPaged AS BEGIN SELECT Id, BookId, PublisherId FROM BookPublishers; END
