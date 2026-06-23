CREATE TABLE Reservations (
    Id uniqueidentifier NOT NULL,
    BookId uniqueidentifier NOT NULL,
    MemberId uniqueidentifier NOT NULL,
    ReservedAt datetime2 NOT NULL
);
