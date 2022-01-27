﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Data.DataModels
{
    public class Vehicle
    {
        private string _vehicleName;
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Make { get; set; }
        [Required]
        [MaxLength(15)]
        public string Model { get; set; }
        [Required]
        [Range (1980,2050)]
        public int ModelYear { get; set; }
        [Required]
        [MaxLength(25)]
        public string Color { get; set; }
        [Required]
        public decimal InvoicePrice { get; set; }
        [Required]
        [ForeignKey(nameof(Dealership))]
        public int DealershipId { get; set; }
        public virtual Dealership Dealership { get; set; }

        public bool InStock { get; set; }


        public string VehicleName
        {
            get
            { _vehicleName = $"{ModelYear} {Make} {Model}";
               return _vehicleName;
            }
            set { _vehicleName = value; }
        }
    }
}
