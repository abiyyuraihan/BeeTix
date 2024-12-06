using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Backend.Dtos.Ticket;
using SE_Backend.Models;

namespace SE_Backend.Mappers
{
    public static class TicketMappers
    {
        public static TicketDto ToTicketDto(this Ticket ticket){
            return new TicketDto{
                Id = ticket.Id,
                Class = ticket.Class,
                price = ticket.price,
            };
        }
    }
}