namespace ProyectoWeb3C.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public User() { 
            this.Role = "Sin Asignar";
        }
        public User(string Name, string Email, string Password, string Role) {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.Role = Role == "" || Role == null ? "Sin Asignar" : Role;
        }
        [Key]
        public int Id_User { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
