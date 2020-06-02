namespace RESTEventVisitor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Profile")]
    public partial class Profile
    {
        [Key]
        [Column(Order = 0)]
        public int Profile_Id { get; set; }


        [Column(Order = 1)]
        [StringLength(50)]
        public string Profile_Firstname { get; set; }


        [Column(Order = 2)]
        [StringLength(50)]
        public string Profile_Lastname { get; set; }


        [Column(Order = 3, TypeName = "date")]
        public DateTime Profile_Birthday { get; set; }


        [Column(Order = 4)]
        [StringLength(10)]
        public string Profile_Role { get; set; }


        [Column(Order = 5)]
        [StringLength(50)]
        public string Profile_PhoneNr { get; set; }


        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Profile_User_Id { get; set; }


        [Column(Order = 7)]
        [StringLength(255)]
        public string Profile_Email { get; set; }
    }
}
