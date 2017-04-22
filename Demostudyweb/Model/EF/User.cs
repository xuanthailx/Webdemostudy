namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public string Password { get; set; }

        [StringLength(1)]
        public string Role { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        public long ID { get; set; }

        public virtual Email Email1 { get; set; }
    }
}
