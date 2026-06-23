CREATE PROCEDURE sp_GetReservationsPaged AS BEGIN SELECT Id, BookId, MemberId, ReservedAt FROM Reservations; END
