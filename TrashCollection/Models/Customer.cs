using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollection.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }
       
        [Required]
        public string City { get; set; }
        
        [Required]
        public string State { get; set; }
        
        [Display(Name = "Zip Code")]
        [StringLength(5, MinimumLength = 5)]
        [Required]
        public string ZipCode { get; set; }
        

        [Display(Name = "Pickup Day")]
        public string PickupDay { get; set; }
        
        public string OneTimePickup { get; set; }
        
        public double MonthBalance { get; set; }
        
        public string SuspendStart { get; set; }
        
        public string SuspendEnd { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
