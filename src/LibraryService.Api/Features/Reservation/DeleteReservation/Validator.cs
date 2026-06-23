using FluentValidation;

namespace LibraryService.Api.Features.Reservation.DeleteReservation;
public sealed class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
{
    public DeleteReservationCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}