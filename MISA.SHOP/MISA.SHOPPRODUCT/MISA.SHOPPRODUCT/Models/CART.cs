namespace MISA.SHOPPRODUCT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CART")]
    public partial class CART
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int IDCE { get; set; }

        public int IDPD { get; set; }

        public int? SELLNUMBER { get; set; }

        public DateTime? DATEBUY { get; set; }

        public int? STATUSCLIENT { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
