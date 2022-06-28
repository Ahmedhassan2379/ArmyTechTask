namespace ArmyTechTask.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Branch")]
    public partial class Branch
    {
        public Branch()
        {
            Cashiers = new HashSet<Cashier>();
            InvoiceHeaders = new HashSet<InvoiceHeader>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string BranchName { get; set; }

        public int CityID { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cashier> Cashiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; }
    }
}
