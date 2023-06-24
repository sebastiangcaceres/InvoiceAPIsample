using System.ComponentModel.DataAnnotations;

namespace InvoiceAPIsample.Models
{
    public class Invoices
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Customer Full Name
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// Issue Date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Currency code i.e. EUR
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// Total invoice amount
        /// </summary>
        public decimal Total { get; set; }

    }
}
