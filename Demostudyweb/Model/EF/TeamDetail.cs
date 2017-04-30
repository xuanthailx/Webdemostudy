namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeamDetail")]
    public partial class TeamDetail
    {
        public int ID { get; set; }

        public int TeamID { get; set; }

        public int StudentID { get; set; }

        public int CheckIn { get; set; }

        public virtual Student Student { get; set; }

        public virtual Team Team { get; set; }
    }
}
