using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace splc.domain.Models
{
    [Table("Info.WROrders")]
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int OrderId { get; set; }

        [StringLength(5)]
        public string CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }

        [StringLength(30)]
        public string PurchaseOrderNumber { get; set; }

        [StringLength(50)]
        public string ShipName { get; set; }

        [StringLength(35)]
        public string ShipAddress1 { get; set; }

        [StringLength(32)]
        public string ShipAddress2 { get; set; }

        [StringLength(50)]
        public string ShipCity { get; set; }

        [StringLength(50)]
        public string ShipState { get; set; }

        [StringLength(20)]
        public string ShipPostalCode { get; set; }

        [StringLength(50)]
        public string SCreditCardNo { get; set; }

        [StringLength(50)]
        public string SExpDate { get; set; }

        [StringLength(60)]
        public string SChargeStatus { get; set; }

        public bool Bookstore { get; set; }

        public bool Foreign { get; set; }

        [Column(TypeName = "money")]
        public decimal? AmtPaid { get; set; }

        [StringLength(80)]
        public string Message1 { get; set; }

        [StringLength(80)]
        public string Message2 { get; set; }

        [StringLength(80)]
        public string Message3 { get; set; }

        [StringLength(80)]
        public string Message4 { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
