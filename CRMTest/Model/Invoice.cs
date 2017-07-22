namespace CRMTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        public long Company_ID { get; set; }
    }
}
