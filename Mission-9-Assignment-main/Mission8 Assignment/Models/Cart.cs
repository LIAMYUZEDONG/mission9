using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookProject.Models
{
    public class Cart
    {
    [Key]
    [BindNever]
    public int CartId { get; set; }

    [BindNever]
    public ICollection<BasketLineItem> Lines { get; set; }

    [Required(ErrorMessage =" Please Enter a name: ")]
    public string Name { get; set; }

    [Required(ErrorMessage = " Please Enter the first address line: ")]
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }


    [Required(ErrorMessage = " Please Enter a city name: ")]
    public string City { get; set; }

    [Required(ErrorMessage = " Please Enter a state: ")]
    public string state { get; set; }
    public string Zip { get; set; }


    [Required(ErrorMessage = " Please Enter a country: ")]
    public string country { get; set; }

    [Required(ErrorMessage = " Please Enter a credit/debit card number: ")]
    public string card { get; set; }

    [Required(ErrorMessage = " Please Enter the security number: ")]
    public string scuritynumber { get; set; }




    }
}
