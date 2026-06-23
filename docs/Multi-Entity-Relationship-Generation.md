# Multi-entity relationship generation

This solution contains relationship-aware generation for entities, DTOs, EF Core configuration, repositories, services, and join entities.

| Source | Type | Target | FK / Join |
|---|---|---|---|
| Book | ManyToMany | Publisher | BookPublisher |
| Book | ManyToMany | Author | BookAuthor |
| Book | ManyToMany | Category | BookCategory |
| Book | OneToMany | Loan | BookId |
| Book | OneToMany | Reservation | BookId |
| Book | OneToMany | BookPublisher | BookId |
| Book | OneToMany | BookAuthor | BookId |
| Book | OneToMany | BookCategory | BookId |
| Author | OneToMany | BookAuthor | AuthorId |
| Category | OneToMany | BookCategory | CategoryId |
| Publisher | OneToMany | BookPublisher | PublisherId |
| Member | OneToMany | Loan | MemberId |
| Member | OneToMany | Reservation | MemberId |
| Loan | OneToOne | Fine | LoanId |
| Loan | ManyToOne | Book | BookId |
| Loan | ManyToOne | Member | MemberId |
| Reservation | ManyToOne | Book | BookId |
| Reservation | ManyToOne | Member | MemberId |
| Fine | OneToOne | Loan | LoanId |
| BookPublisher | ManyToOne | Book | BookId |
| BookPublisher | ManyToOne | Publisher | PublisherId |
| BookAuthor | ManyToOne | Book | BookId |
| BookAuthor | ManyToOne | Author | AuthorId |
| BookCategory | ManyToOne | Book | BookId |
| BookCategory | ManyToOne | Category | CategoryId |