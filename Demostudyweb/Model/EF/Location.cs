namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        public int ID { get; set; }

        [Column("Location")]
        [StringLength(50)]
        public string Location1 { get; set; }
    }
}
