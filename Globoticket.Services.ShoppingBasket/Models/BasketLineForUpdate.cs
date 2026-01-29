using System.ComponentModel.DataAnnotations;

namespace Globoticket.Services.ShoppingBasket.Models
{
    public class BasketLineForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
