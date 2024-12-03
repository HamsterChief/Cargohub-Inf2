﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MyEFCoreProject.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241127090934_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Api_Key", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("App")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Api_Keys");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contact_Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contact_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contact_Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Zip_Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Item_Id")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Item_Reference")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Locations")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Total_Allocated")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Total_Available")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Total_Expected")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Total_On_Hand")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Total_Ordered")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Item", b =>
                {
                    b.Property<string>("UId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Commodity_Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Item_Group")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Item_Line")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Item_Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model_Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Pack_Order_Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Short_Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Supplier_Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Supplier_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Supplier_Part_Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Unit_Order_Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Unit_Purchase_Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Upc_Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("TEXT");

                    b.HasKey("UId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Item_Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Item_Groups");
                });

            modelBuilder.Entity("Item_Line", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Item_Lines");
                });

            modelBuilder.Entity("Item_Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Item_Types");
                });

            modelBuilder.Entity("Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("TEXT");

                    b.Property<int>("Warehouse_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bill_To")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Items")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Order_Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Order_Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Picking_Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference_Extra")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Request_Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Ship_To")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Shipment_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Shipping_Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Source_Id")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Total_Amount")
                        .HasColumnType("REAL");

                    b.Property<double>("Total_Discount")
                        .HasColumnType("REAL");

                    b.Property<double>("Total_Surcharge")
                        .HasColumnType("REAL");

                    b.Property<double>("Total_Tax")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("TEXT");

                    b.Property<int>("Warehouse_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Carrier_Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Carrier_Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Items")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Order_Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Payment_Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Request_Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Service_Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Shipment_Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Shipment_Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Shipment_Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Source_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Total_Package_Count")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Total_Package_Weight")
                        .HasColumnType("REAL");

                    b.Property<string>("Transfer_Mode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address_Extra")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contact_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Zip_Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Items")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Transfer_From")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Transfer_Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Transfer_To")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });
#pragma warning restore 612, 618
        }
    }
}
