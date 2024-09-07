using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_History.api.Models
{


    [Table("historial")]
    public class HistoryModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Name { get; set; }

        [Column("descripcion")]
        public string Description { get; set; }

        [Column("tabla")]
        public string NameTable { get; set; }


        [Column("relacionfk")]
        public string NameTablaFK { get; set; }


        [Column("valor")]
        public decimal UnitPrice { get; set; }

        [Column("ruta")]
        public string Url { get; set; }

    }
}
