# LibraryService generation summary

Architecture: `VerticalSlice`
API style: `MinimalApi`
Persistence: `DapperReadEfWrite`

## Entities
- `Book` → table `Books`
  - ManyToMany → `Publisher`
  - ManyToMany → `Author`
  - ManyToMany → `Category`
  - OneToMany → `Loan`
  - OneToMany → `Reservation`
  - OneToMany → `BookPublisher`
  - OneToMany → `BookAuthor`
  - OneToMany → `BookCategory`
- `Author` → table `Authors`
  - OneToMany → `BookAuthor`
- `Category` → table `Categories`
  - OneToMany → `BookCategory`
- `Publisher` → table `Publishers`
  - OneToMany → `BookPublisher`
- `Member` → table `Members`
  - OneToMany → `Loan`
  - OneToMany → `Reservation`
- `Loan` → table `Loans`
  - OneToOne → `Fine`
  - ManyToOne → `Book`
  - ManyToOne → `Member`
- `Reservation` → table `Reservations`
  - ManyToOne → `Book`
  - ManyToOne → `Member`
- `Fine` → table `Fines`
  - OneToOne → `Loan`
- `BookPublisher` → table `BookPublishers`
  - ManyToOne → `Book`
  - ManyToOne → `Publisher`
- `BookAuthor` → table `BookAuthors`
  - ManyToOne → `Book`
  - ManyToOne → `Author`
- `BookCategory` → table `BookCategories`
  - ManyToOne → `Book`
  - ManyToOne → `Category`

Generated files: `349`

## Quality gates
- Build validation enabled
- Architecture rules enabled
- ADR output enabled
- Environment appsettings generated