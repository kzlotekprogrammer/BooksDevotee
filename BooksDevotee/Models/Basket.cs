using System;
using System.Collections.Generic;

namespace BooksDevotee.Models
{
    public enum Status
    {
        New,
        Canceled,
        Paid
    }

    public class Basket
    {
        public int BasketId { get; set; }
        public string ApplicationUserId { get; set; }
        public Status Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public List<BasketBook> BasketBooks { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
