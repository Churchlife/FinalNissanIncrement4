namespace NissanCartTest01.WebUi.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<NissanCartTest01.WebUi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(NissanCartTest01.WebUi.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Genres.AddOrUpdate(p => p.GenreId,

                new Genre (){ Name = "Hatch" },
                new Genre (){ Name = "Sedan" },
                new Genre (){ Name = "Crossover" },
                new Genre (){ Name = "SUV" },
                new Genre (){ Name = "Commercial" },
                new Genre (){ Name = "Sports Coupe" }
                );



            List<Category> cat = context.Categories.ToList();

            foreach (Category y in cat)
            {
                //context.Categories.Remove(y);
            }


            context.Categories.AddOrUpdate(
               p => p.CategoryID,
                new Category() { CategoryName = "Piston" },
               new Category() { CategoryName = "Break pads" },
               new Category() { CategoryName = "Clutch" });

            List<Parts> part = context.Partst.ToList();

            foreach (Parts x in part)
            {
                context.Partst.Remove(x);
            }

            context.Partst.AddOrUpdate(x => x.PartID,
            new Parts() { Vehicle = "X-Trail", PartName = "X21RTU4", CategoryName = "Under Bonnet", ArtUrlImage = "/Content/Images/th_Shift_Knobs.JPG", CategoryId = 1, price = 2300, Quantity = 1 },
            new Parts() { Vehicle = "X-Trail", PartName = "X21RD87", CategoryName = "Under Bonnet", ArtUrlImage = "/Content/Images/NissanIGN Coil+q6G68L._SY355_.jpg", CategoryId = 2, price = 2300, Quantity = 1 },
            new Parts() { Vehicle = "X-Trail", PartName = "X21RTR23", CategoryName = "Chassis", ArtUrlImage = "/Content/Images/th_Shift_Knobs.JPG", CategoryId = 3, price = 6300, Quantity = 1 },
            new Parts() { Vehicle = "Quashqai", PartName = "X21R874", CategoryName = "Wheels", ArtUrlImage = "/Content/Images/WheelNuts.jpg", CategoryId = 1, price = 2000, Quantity = 1 },
            new Parts() { Vehicle = "Quashqai", PartName = "X21Z41Q", CategoryName = "Electrical", ArtUrlImage = "/Content/Images/th_Shift_Knobs.JPG", CategoryId = 2, price = 2100, Quantity = 1 },
            new Parts() { Vehicle = "Quashqai", PartName = "X21RTU4", CategoryName = "Internal", ArtUrlImage = "/Content/Images/steel-piston-rod.jpg", CategoryId = 3, price = 5300, Quantity = 1 },
            new Parts() { Vehicle = "NP200", PartName = "X21RUV29", CategoryName = "External", ArtUrlImage = "/Content/Images/Nissan_Part01.jpg", CategoryId = 1, price = 3000, Quantity = 1 }
            );



            context.VehCats.AddOrUpdate(x => x.VehicleId,
            new VehCat() { Make = "Nissan", GenreId = 1, Name = "Micra", Model = "1.2 Visia + Insync 5 Door (D86V)", Transmission = "Manual", EngineSize = 1.2M, PowerMaximum = 56, TorqueMaximum = 104, MaxSpeed = 166, Acceleration = 13.2M, FuelType = "Petrol", FuelConsumption = 5.2M, C02Emissions = 124, FuelTankCapacity = 41, FuelRange = 789, Segment = "Passenger Car", NumofDoors = 5, NumofSeats = 5, LoadVolume = 265, NumofAirbags = 4, ABS = "Standard", TractionControl = "N/A", EBD = "Standard", StabilityControl = "NO", WarrantyDuration = 3, WarrantyDistance = 100000, ServicePlan = "N/A", ServiceDistance = "N/A", MaintenancePlan = "N/A", MaintenanceDistance = "N/A", Airconditioning = "Standard", Navigation = "NO", RainSensingAutoWipers = "NO", ElectricWindows = "Front", ElectricSeats = "NO", CentralLocking = "Remote", CDPlayer = "CD", DaytimeRunningLights = "NO", OnboardComputer = "NO", ClimateControl = "NO", KeylessAccess = "YES", AutomaticLights = "NO", ElectricMirrors = "NO", PowerSteering = "Standard", BluetoothConnectivity = "NO", LeatherUpholstering = "NO", MultiFunctSteeringWheel = "NO", ParkDistControl = "NO", Price = 159900.00M, AlbumArtUrl = "/Content/Images/Micra1.gif" }


            );

            context.Accessories.AddOrUpdate(x => x.Id,
            new Accessories() { Name = "Carpets", Categories = "Interior", Option = "Standard", Description = "Standard", VehicleName = "Micra", Price = 500M },
            new Accessories() { Name = "Carpets", Categories = "Interior", Option = "Luxury", Description = "Luxury", VehicleName = "Micra", Price = 600M },
            new Accessories() { Name = "Carpets", Categories = "Interior", Option = "Chrome", Description = "Chrome", VehicleName = "Micra", Price = 700M }
            //new Accessories() { Vehicle = "X-Trail", PartName = "X21RD87", CategoryName = "Under Bonnet", CategoryId = 2, price = 2300, Quantity = 1 },
            //new Accessories() { Vehicle = "X-Trail", PartName = "X21RTR23", CategoryName = "Chassis", CategoryId = 3, price = 6300, Quantity = 1 },
            //new Accessories() { Vehicle = "Quashqai", PartName = "X21R874", CategoryName = "Wheels", CategoryId = 1, price = 2000, Quantity = 1 },
            //new Accessories() { Vehicle = "Quashqai", PartName = "X21Z41Q", CategoryName = "Electrical", CategoryId = 2, price = 2100, Quantity = 1 },
            //new Accessories() { Vehicle = "Quashqai", PartName = "X21RTU4", CategoryName = "Internal", CategoryId = 3, price = 5300, Quantity = 1 },
            //new Accessories() { Vehicle = "NP200", PartName = "X21RUV29", CategoryName = "External", CategoryId = 1, price = 3000, Quantity = 1 }

            );
        }
    }
}
