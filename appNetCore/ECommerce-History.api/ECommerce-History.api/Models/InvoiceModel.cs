using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_History.api.Models
{
    [Table("factura")]
    public class InvoiceModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("cantidad")]
        public decimal Amount { get; set; }

        [Column("clienteid")]
        public int CustomerId { get; set; }

        [Column("nombrecompleto")]
        public string Fullname { get; set; }
    }
}
