using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace splc.domain.Models
{
    [Table("Info.WRCustomerSubscriberMember")]
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            Transactions = new HashSet<TransactionLog>();
        }

        [StringLength(36)]
        public string Lastname { get; set; }

        [StringLength(18)]
        public string Firstname { get; set; }

        public int? DOB { get; set; }

        [StringLength(18)]
        public string Suffix { get; set; }

        [StringLength(35)]
        public string Addr1 { get; set; }

        [StringLength(32)]
        public string Addr2 { get; set; }

        [StringLength(24)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [StringLength(5)]
        public string Zip { get; set; }

        [StringLength(4)]
        public string Zip4 { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        public string Email { get; set; }

        [StringLength(25)]
        public string Fax { get; set; }

        [StringLength(25)]
        public string CreditCardNo { get; set; }

        [StringLength(10)]
        public string ExpDate { get; set; }

        [Key]
        [StringLength(5)]
        public string CustomerId { get; set; }

        public string Info { get; set; }

        public int? LastTransactionId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<TransactionLog> Transactions { get; set; }
    }
}
