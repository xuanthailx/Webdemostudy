namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BudgetsDetail
    {
        public int ID { get; set; }

        public int? BudgetsID { get; set; }

        public int? GameID { get; set; }

        public virtual Budget Budget { get; set; }

        public virtual Game Game { get; set; }
    }
}
