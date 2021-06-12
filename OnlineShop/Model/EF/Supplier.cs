namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SupplierID { get; set; }

        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(40)]
        public string ContactName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(15)]
        public string Fax { get; set; }
    }
}
