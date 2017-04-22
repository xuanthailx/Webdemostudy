namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CostDetail")]
    public partial class CostDetail
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Reason { get; set; }

        public int? Amount { get; set; }
    }
}
