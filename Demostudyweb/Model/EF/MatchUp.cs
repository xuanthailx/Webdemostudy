namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatchUp")]
    public partial class MatchUp
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        public int GameID { get; set; }

        public int? Team1 { get; set; }

        public int? Team2 { get; set; }

        public int? Score1 { get; set; }

        public int? Score2 { get; set; }

        public int? TeamWin { get; set; }

        public virtual Time Time1 { get; set; }
    }
}
