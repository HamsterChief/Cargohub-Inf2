﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MyEFCoreProject.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("address")
                        .HasColumnType("TEXT");

                    b.Property<string>("city")
                        .HasColumnType("TEXT");

                    b.Property<string>("contact_email")
                        .HasColumnType("TEXT");

                    b.Property<string>("contact_name")
                        .HasColumnType("TEXT");

                    b.Property<string>("contact_phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("province")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("zip_code")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

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

                    b.PrimitiveCollection<string>("Locations")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference")
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

                    b.ToTable("Inventorys");
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

                    b.Property<string>("Bill_To")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created_At")
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

                    b.Property<string>("Ship_To")
                        .IsRequired()
                        .HasColumnType("TEXT");

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

                    b.Property<string>("items")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shipment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("carrier_code")
                        .HasColumnType("TEXT");

                    b.Property<string>("carrier_description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("items")
                        .HasColumnType("TEXT");

                    b.Property<string>("notes")
                        .HasColumnType("TEXT");

                    b.Property<string>("order_date")
                        .HasColumnType("TEXT");

                    b.Property<int>("order_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("payment_type")
                        .HasColumnType("TEXT");

                    b.Property<string>("request_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("service_code")
                        .HasColumnType("TEXT");

                    b.Property<string>("shipment_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("shipment_status")
                        .HasColumnType("TEXT");

                    b.Property<string>("shipment_type")
                        .HasColumnType("TEXT");

                    b.Property<int>("source_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("total_package_count")
                        .HasColumnType("INTEGER");

                    b.Property<double>("total_package_weight")
                        .HasColumnType("REAL");

                    b.Property<string>("transfer_mode")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("Supplier", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("address_extra")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("contact_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phonenumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("province")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("reference")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("zip_code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Transfer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("items")
                        .HasColumnType("TEXT");

                    b.Property<string>("reference")
                        .HasColumnType("TEXT");

                    b.Property<string>("transfer_from")
                        .HasColumnType("TEXT");

                    b.Property<string>("transfer_status")
                        .HasColumnType("TEXT");

                    b.Property<string>("transfer_to")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("Warehouse", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("contact")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("province")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("zip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Warehouses");
                });
#pragma warning restore 612, 618
        }
    }
}
