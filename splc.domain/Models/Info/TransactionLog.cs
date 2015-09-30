using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace splc.domain.Models
{
    [Table("Info.WRTransactionLog")]
    public partial class TransactionLog
    {
        [Key]
        public int TransactionId { get; set; }

        [StringLength(50)]
        public string TransactionDate { get; set; }

        [StringLength(255)]
        public string TransactionDescription { get; set; }

        [Column(TypeName = "money")]
        public decimal? TransactionAmount { get; set; }

        [StringLength(5)]
        public string CustomerId { get; set; }
    }
}
