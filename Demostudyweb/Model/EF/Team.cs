namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Team")]
    public partial class Team
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? GameID { get; set; }

        public int? StudentID { get; set; }

        public int? ClassID { get; set; }

        public virtual Class Class { get; set; }

        public virtual Game Game { get; set; }
    }
}
