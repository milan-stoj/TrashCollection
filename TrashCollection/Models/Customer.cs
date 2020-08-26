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
        public DayOfWeek PickupDay { get; set; }

        [Display(Name = "One Time Pickup")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OneTimePickup { get; set; }
        public bool PendingOneTimePickup { get; set; }
        
        [DataType(DataType.Currency)]
        public double MonthBalance { get; set; }

        [Display(Name = "Last Pickup Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastPickup { get; set; }

        [Display(Name = "Suspend Start")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SuspendStart { get; set; }

        [Display(Name = "Suspend End")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SuspendEnd { get; set; }

        public bool ServiceSuspended { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
