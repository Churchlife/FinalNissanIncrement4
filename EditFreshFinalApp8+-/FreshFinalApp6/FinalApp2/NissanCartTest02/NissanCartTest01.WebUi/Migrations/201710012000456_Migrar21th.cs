namespace NissanCartTest01.WebUi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrar21th : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Categories = c.String(),
                        Name = c.String(),
                        Option = c.String(),
                        Description = c.String(),
                        VehicleName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookIns",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        RegId = c.String(nullable: false, maxLength: 10),
                        Date = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Status = c.String(maxLength: 60),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        VehicleId = c.Int(nullable: false),
                        AccessoriesL = c.String(),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Accessories_Id = c.Int(),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Accessories", t => t.Accessories_Id)
                .ForeignKey("dbo.VehCats", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.Accessories_Id);
            
            CreateTable(
                "dbo.VehCats",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                        Make = c.String(),
                        Type = c.String(),
                        Name = c.String(),
                        Model = c.String(),
                        Transmission = c.String(),
                        EngineSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PowerMaximum = c.Int(nullable: false),
                        TorqueMaximum = c.Int(nullable: false),
                        MaxSpeed = c.Int(nullable: false),
                        Acceleration = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FuelType = c.String(),
                        FuelConsumption = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C02Emissions = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FuelTankCapacity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FuelRange = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Segment = c.String(),
                        NumofDoors = c.Int(nullable: false),
                        NumofSeats = c.Int(nullable: false),
                        LoadVolume = c.Int(nullable: false),
                        NumofAirbags = c.Int(nullable: false),
                        ABS = c.String(),
                        TractionControl = c.String(),
                        EBD = c.String(),
                        StabilityControl = c.String(),
                        WarrantyDuration = c.Int(nullable: false),
                        WarrantyDistance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServicePlan = c.String(),
                        ServiceDistance = c.String(),
                        MaintenancePlan = c.String(),
                        MaintenanceDistance = c.String(),
                        Airconditioning = c.String(),
                        Navigation = c.String(),
                        RainSensingAutoWipers = c.String(),
                        ElectricWindows = c.String(),
                        ElectricSeats = c.String(),
                        CentralLocking = c.String(),
                        CDPlayer = c.String(),
                        DaytimeRunningLights = c.String(),
                        OnboardComputer = c.String(),
                        ClimateControl = c.String(),
                        KeylessAccess = c.String(),
                        AutomaticLights = c.String(),
                        ElectricMirrors = c.String(),
                        PowerSteering = c.String(),
                        BluetoothConnectivity = c.String(),
                        LeatherUpholstering = c.String(),
                        MultiFunctSteeringWheel = c.String(),
                        ParkDistControl = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlbumArtUrl = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders1", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.VehCats", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Orders1",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 160),
                        LastName = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 24),
                        Email = c.String(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartID = c.Int(nullable: false, identity: true),
                        Vehicle = c.String(),
                        PartName = c.String(),
                        CategoryName = c.String(),
                        ArtUrlImage = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartID)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Parent = c.Int(),
                        created = c.String(),
                        fullname = c.String(),
                        content = c.String(),
                        modified = c.String(),
                        JobCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.JobCards", t => t.JobCardId, cascadeDelete: true)
                .Index(t => t.JobCardId);
            
            CreateTable(
                "dbo.JobCards",
                c => new
                    {
                        JobCardId = c.Int(nullable: false, identity: true),
                        Techfaults = c.String(),
                        Userfaults = c.String(),
                        Possession = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Progress = c.String(),
                        RegId = c.String(maxLength: 10),
                        VinNumber = c.String(maxLength: 17),
                        StaffId = c.Int(nullable: false),
                        ForemanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobCardId)
                .ForeignKey("dbo.Foremen", t => t.ForemanId, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => new { t.VinNumber, t.RegId })
                .Index(t => new { t.VinNumber, t.RegId })
                .Index(t => t.StaffId)
                .Index(t => t.ForemanId);
            
            CreateTable(
                "dbo.Foremen",
                c => new
                    {
                        ForemanId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        username = c.String(),
                    })
                .PrimaryKey(t => t.ForemanId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        username = c.String(),
                    })
                .PrimaryKey(t => t.StaffId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VinNumber = c.String(nullable: false, maxLength: 17),
                        RegId = c.String(nullable: false, maxLength: 10),
                        Make = c.String(),
                        Model = c.String(),
                        Type = c.String(),
                        Year = c.Int(nullable: false),
                        Colour = c.String(nullable: false),
                        Mileage = c.Int(nullable: false),
                        ID_Number = c.String(nullable: false, maxLength: 14),
                    })
                .PrimaryKey(t => new { t.VinNumber, t.RegId })
                .ForeignKey("dbo.Customers", t => t.ID_Number, cascadeDelete: true)
                .Index(t => t.ID_Number);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID_Number = c.String(nullable: false, maxLength: 14),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        EmailAddress = c.String(),
                        ContactNumber = c.String(nullable: false, maxLength: 10),
                        Physical_Address = c.String(nullable: false),
                        Postal_Address = c.String(),
                    })
                .PrimaryKey(t => t.ID_Number);
            
            CreateTable(
                "dbo.EmailFormModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromName = c.String(nullable: false),
                        FromEmail = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faults",
                c => new
                    {
                        FaultId = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Fault = c.String(),
                        Checked = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        p = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FaultId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        partID = c.Int(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                        status = c.String(),
                        JobCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.JobCards", t => t.JobCardId, cascadeDelete: true)
                .Index(t => t.JobCardId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        FinanceApproval = c.String(),
                        FinanceCompany = c.String(),
                        FinanceStatus = c.String(),
                        ID_Number = c.String(maxLength: 14),
                        SaleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Customers", t => t.ID_Number)
                .ForeignKey("dbo.VehicleForSales", t => t.SaleID, cascadeDelete: true)
                .Index(t => t.ID_Number)
                .Index(t => t.SaleID);
            
            CreateTable(
                "dbo.VehicleForSales",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        PaymentPlan = c.String(),
                        MonthlyPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthlyPaymentDate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegristrationYear = c.String(),
                        status = c.String(),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.Orders1", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.RegisterViewModels",
                c => new
                    {
                        Uid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Uid);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        Pass = c.String(),
                        Reason = c.String(),
                        BetweenTime = c.Time(precision: 7),
                        rating = c.Int(nullable: false),
                        type = c.String(),
                        commission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StaffID = c.Int(nullable: false),
                        JobCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.JobCards", t => t.JobCardId, cascadeDelete: true)
                .Index(t => t.JobCardId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Services", "JobCardId", "dbo.JobCards");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Payments", "SaleID", "dbo.VehicleForSales");
            DropForeignKey("dbo.VehicleForSales", "OrderId", "dbo.Orders1");
            DropForeignKey("dbo.Payments", "ID_Number", "dbo.Customers");
            DropForeignKey("dbo.Orders", "JobCardId", "dbo.JobCards");
            DropForeignKey("dbo.Comments", "JobCardId", "dbo.JobCards");
            DropForeignKey("dbo.JobCards", new[] { "VinNumber", "RegId" }, "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "ID_Number", "dbo.Customers");
            DropForeignKey("dbo.JobCards", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.JobCards", "ForemanId", "dbo.Foremen");
            DropForeignKey("dbo.Parts", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Carts", "VehicleId", "dbo.VehCats");
            DropForeignKey("dbo.OrderDetails", "VehicleId", "dbo.VehCats");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders1");
            DropForeignKey("dbo.VehCats", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Carts", "Accessories_Id", "dbo.Accessories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Services", new[] { "JobCardId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.VehicleForSales", new[] { "OrderId" });
            DropIndex("dbo.Payments", new[] { "SaleID" });
            DropIndex("dbo.Payments", new[] { "ID_Number" });
            DropIndex("dbo.Orders", new[] { "JobCardId" });
            DropIndex("dbo.Vehicles", new[] { "ID_Number" });
            DropIndex("dbo.JobCards", new[] { "ForemanId" });
            DropIndex("dbo.JobCards", new[] { "StaffId" });
            DropIndex("dbo.JobCards", new[] { "VinNumber", "RegId" });
            DropIndex("dbo.Comments", new[] { "JobCardId" });
            DropIndex("dbo.Parts", new[] { "CategoryId" });
            DropIndex("dbo.OrderDetails", new[] { "VehicleId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.VehCats", new[] { "GenreId" });
            DropIndex("dbo.Carts", new[] { "Accessories_Id" });
            DropIndex("dbo.Carts", new[] { "VehicleId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Services");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RegisterViewModels");
            DropTable("dbo.VehicleForSales");
            DropTable("dbo.Payments");
            DropTable("dbo.Orders");
            DropTable("dbo.Faults");
            DropTable("dbo.EmailFormModels");
            DropTable("dbo.Customers");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Staffs");
            DropTable("dbo.Foremen");
            DropTable("dbo.JobCards");
            DropTable("dbo.Comments");
            DropTable("dbo.Parts");
            DropTable("dbo.Categories");
            DropTable("dbo.Orders1");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Genres");
            DropTable("dbo.VehCats");
            DropTable("dbo.Carts");
            DropTable("dbo.BookIns");
            DropTable("dbo.Appointments");
            DropTable("dbo.Accessories");
        }
    }
}
