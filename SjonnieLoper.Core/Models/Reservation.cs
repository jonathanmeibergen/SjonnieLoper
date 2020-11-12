using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Core.Models
{
    public class Reservation 
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Display(Name="Product ")]
        public virtual Whiskey Product { get; set; }

        [Display(Name="Id of customer ")]
        [ForeignKey("Customer")]
        [ScaffoldColumn(false)]
        [Required]
        public virtual ApplicationUser User { get; set; }
        //public int CustomerId;
        
        [Required]
        [Display(Name="Date order was placed ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd",
            ApplyFormatInEditMode = true)]
        public DateTime Orderdate { get; set; }
        
        [Display(Name="Name of client ")]
        [Required]
        public string Customer { get; set; }
        
        public Reservation(int id, DateTime time, Customer customer, Whiskey whiskey)
        {
            Id = id;
            Orderdate = time;
            //Customer = customer.UserName;
            //this.Products = new HashSet<Whiskey>();
        }

        public Reservation(Reservation @base)
        {
            //this.Products = new HashSet<Whiskey>();
            Id = @base.Id;
            Orderdate = @base.Orderdate;
            //Customer = @base.Customer;
        }
        
        public Reservation()
        {
            //this.Products = new HashSet<Whiskey>();
        }

    }
}