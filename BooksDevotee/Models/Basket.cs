using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksDevotee.Models
{
    public enum BasketStatus
    {
        [Display(Name = "Aktywne")]
        Active = 0,

        [Display(Name = "Anulowane")]
        Canceled = 1,

        [Display(Name = "W transakcji")]
        InTransaction = 2,

        [Display(Name = "Opłacone")]
        Paid = 3,

        [Display(Name = "Wysłane")]
        Sent = 4,

        [Display(Name = "Spakowane")]
        Prepared = 5
    }

    public class Basket
    {
        public int BasketId { get; set; }
        public string ApplicationUserId { get; set; }
        public BasketStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? PreparedDate { get; set; }
        public DateTime? CancelDate { get; set; }

        public ICollection<BasketBook> BasketBooks { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
