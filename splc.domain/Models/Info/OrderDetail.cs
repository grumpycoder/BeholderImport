using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace splc.domain.Models
{
    [Table("Info.WROrderDetails")]
    public partial class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        [StringLength(50)]
        public string ProductId { get; set; }

        public DateTime? DateSold { get; set; }

        public double? SaleCnt { get; set; }

        [Column(TypeName = "money")]
        public decimal? SalePrice { get; set; }

        public virtual Order Order { get; set; }
    }
}
