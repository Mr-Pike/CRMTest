namespace CRMTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Address_line_1 { get; set; }

        [StringLength(255)]
        public string Address_line_2 { get; set; }

        [Required]
        [StringLength(32)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        public short? Country_ID { get; set; }

        [StringLength(9)]
        public string Siren { get; set; }

        [Required]
        [StringLength(14)]
        public string Phone { get; set; }

        [StringLength(14)]
        public string Fax { get; set; }

        [Required]
        [StringLength(255)]
        public string Mail { get; set; }

        public virtual Country Country { get; set; }
    }
}
