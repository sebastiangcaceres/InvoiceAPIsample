using System.ComponentModel.DataAnnotations;

namespace InvoiceAPIsample.Models
{
    public class InvoiceLines
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Line Amount
        /// </summary>
        public decimal Amount { get; set; }
    }
}
