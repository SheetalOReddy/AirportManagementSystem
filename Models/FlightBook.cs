//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirportManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class FlightBook
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Current location is required")]
        [Display(Name = "Current Location")]
        public string Currentlocation { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Destination is required")]
        public string Destination { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Journey Date is required")]
        [Display(Name = "Journey Date")]
        [DataType(DataType.Date)]
        public string Journeytime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Airways is required")]
        public string Airways { get; set; }
    }
}