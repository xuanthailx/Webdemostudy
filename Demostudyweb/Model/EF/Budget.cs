namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Budget
    {
        [StringLength(200)]
        public string Description { get; set; }

        public int ID { get; set; }

        public int Amount { get; set; }

        public virtual BudgetsDetail BudgetsDetail { get; set; }
    }
}
