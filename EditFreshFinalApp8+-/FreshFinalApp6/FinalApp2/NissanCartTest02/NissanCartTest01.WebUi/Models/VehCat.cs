using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NissanCartTest01.WebUi.Models
{
    [Bind(Exclude = "VehicleId")]
    public class VehCat
    {
        
        [Key]
        [ScaffoldColumn(false)]
        public int VehicleId { get; set; }

        [DisplayName("Genre")]
        public int GenreId { get; set; }

        [DisplayName("Artist")]
        public int ArtistId { get; set; }

        
        public string Make { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Transmission { get; set; }

        //Engine
        public decimal EngineSize { get; set; }
        public int PowerMaximum { get; set; }
        public int TorqueMaximum { get; set; }
        public int MaxSpeed { get; set; }
        public decimal Acceleration { get; set; }

        //Fuel
        public string FuelType { get; set; }
        public decimal FuelConsumption { get; set; }
        public decimal C02Emissions { get; set; }
        public decimal FuelTankCapacity { get; set; }
        public decimal FuelRange { get; set; }

        //Body Type
        public string Segment { get; set; }
        public int NumofDoors { get; set; }
        public int NumofSeats { get; set; }
        public int LoadVolume { get; set; }

        //Safety
        public int NumofAirbags { get; set; }
        public string ABS { get; set; }
        public string TractionControl { get; set; }
        public string EBD { get; set; }
        public string StabilityControl { get; set; }

        //Warranty
        public int WarrantyDuration { get; set; }
        public decimal WarrantyDistance { get; set; }

        //Service
        public string ServicePlan { get; set; }
        public string ServiceDistance { get; set; }
        public string MaintenancePlan { get; set; }
        public string MaintenanceDistance { get; set; }

        //Interior
        public string Airconditioning { get; set; }
        public string Navigation { get; set; }
        public string RainSensingAutoWipers { get; set; }
        public string ElectricWindows { get; set; }
        public string ElectricSeats { get; set; }
        public string CentralLocking { get; set; }
        public string CDPlayer { get; set; }
        public string DaytimeRunningLights { get; set; }
        public string OnboardComputer { get; set; }
        public string ClimateControl { get; set; }
        public string KeylessAccess { get; set; }
        public string AutomaticLights { get; set; }
        public string ElectricMirrors { get; set; }
        public string PowerSteering { get; set; }
        public string BluetoothConnectivity { get; set; }
        public string LeatherUpholstering { get; set; }
        public string MultiFunctSteeringWheel { get; set; }
        public string ParkDistControl { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(10000.01, 3000000.00,
            ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        public virtual Genre Genre { get; set; }
 
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}