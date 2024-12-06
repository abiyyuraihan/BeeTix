using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Backend.Dtos.Booking;
using SE_Backend.Models;

namespace SE_Backend.Mappers
{
    public static class BookingMappers
    {
        public static BookingDto ToBookingDto(this Booking bookingModel){
            return new BookingDto{
                Id = bookingModel.Id,
                NumberOfTickets = bookingModel.NumberOfTickets,
                TotalCost = bookingModel.TotalCost,
                Tickets = bookingModel.Tickets.Select(c => c.ToTicketDto()).ToList()
            };
        }

        public static Booking ToBookingFromCreateDTO(this CreateBookingDto theaterDto){
            return new Booking
            {
                NumberOfTickets = theaterDto.NumberOfTickets,
                TotalCost = theaterDto.TotalCost,
            };
        }
    }
}