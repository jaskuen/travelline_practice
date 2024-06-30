using Accommodations.Dto;
using Accommodations.Models;

namespace Accommodations.Commands;

public class BookCommand(IBookingService bookingService, BookingDto bookingDto) : ICommand
{
    private Booking? _executedBookingDto;

    public void Execute()
    {
        Currency currency = bookingDto.Currency switch
        {
            CurrencyDto.Usd => Currency.Usd,
            CurrencyDto.Rub => Currency.Rub,
            CurrencyDto.Cny => Currency.Cny,
            _ => throw new ArgumentOutOfRangeException()
        };
        _executedBookingDto = bookingService.Book(bookingDto.UserId, bookingDto.Category, bookingDto.StartDate,
            bookingDto.EndDate, currency);
        Console.WriteLine($"Booking successful: ID {_executedBookingDto!.Id}");
    }

    public void Undo() // убрал из функции рассчет штрафа, поскольку это отмена именно операции, а не брони
    {
        bookingService.CancelBooking(_executedBookingDto.Id);
        Console.WriteLine(
            $"Booking {_executedBookingDto.Id} was canceled. No penalty was taken due to system cancellation.");
    }
}
