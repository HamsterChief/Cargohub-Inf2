using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEFCoreProject.Migrations
{
    /// <inheritdoc />
    public partial class ChangedShipmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Warehouses",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Warehouses",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Warehouses",
                newName: "province");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Warehouses",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Warehouses",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Warehouses",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "Warehouses",
                newName: "contact");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Warehouses",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Warehouses",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Warehouses",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Warehouses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Transfers",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Transfer_To",
                table: "Transfers",
                newName: "transfer_to");

            migrationBuilder.RenameColumn(
                name: "Transfer_Status",
                table: "Transfers",
                newName: "transfer_status");

            migrationBuilder.RenameColumn(
                name: "Transfer_From",
                table: "Transfers",
                newName: "transfer_from");

            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "Transfers",
                newName: "reference");

            migrationBuilder.RenameColumn(
                name: "Items",
                table: "Transfers",
                newName: "items");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Transfers",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Transfers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Zip_Code",
                table: "Suppliers",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Suppliers",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "Suppliers",
                newName: "reference");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Suppliers",
                newName: "province");

            migrationBuilder.RenameColumn(
                name: "Phonenumber",
                table: "Suppliers",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Suppliers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Suppliers",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Suppliers",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Contact_Name",
                table: "Suppliers",
                newName: "contact_name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Suppliers",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Suppliers",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address_Extra",
                table: "Suppliers",
                newName: "address_extra");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Suppliers",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Suppliers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Shipments",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Transfer_Mode",
                table: "Shipments",
                newName: "transfer_mode");

            migrationBuilder.RenameColumn(
                name: "Total_Package_Weight",
                table: "Shipments",
                newName: "total_package_weight");

            migrationBuilder.RenameColumn(
                name: "Total_Package_Count",
                table: "Shipments",
                newName: "total_package_count");

            migrationBuilder.RenameColumn(
                name: "Source_Id",
                table: "Shipments",
                newName: "source_id");

            migrationBuilder.RenameColumn(
                name: "Shipment_Type",
                table: "Shipments",
                newName: "shipment_type");

            migrationBuilder.RenameColumn(
                name: "Shipment_Status",
                table: "Shipments",
                newName: "shipment_status");

            migrationBuilder.RenameColumn(
                name: "Shipment_Date",
                table: "Shipments",
                newName: "shipment_date");

            migrationBuilder.RenameColumn(
                name: "Service_Code",
                table: "Shipments",
                newName: "service_code");

            migrationBuilder.RenameColumn(
                name: "Request_Date",
                table: "Shipments",
                newName: "request_date");

            migrationBuilder.RenameColumn(
                name: "Payment_Type",
                table: "Shipments",
                newName: "payment_type");

            migrationBuilder.RenameColumn(
                name: "Order_Id",
                table: "Shipments",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "Order_Date",
                table: "Shipments",
                newName: "order_date");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Shipments",
                newName: "notes");

            migrationBuilder.RenameColumn(
                name: "Items",
                table: "Shipments",
                newName: "items");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Shipments",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Carrier_Description",
                table: "Shipments",
                newName: "carrier_description");

            migrationBuilder.RenameColumn(
                name: "Carrier_Code",
                table: "Shipments",
                newName: "carrier_code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Shipments",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "transfer_mode",
                table: "Shipments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "shipment_type",
                table: "Shipments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "shipment_status",
                table: "Shipments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "shipment_date",
                table: "Shipments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "service_code",
                table: "Shipments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "request_date",
                table: "Shipments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "payment_type",
                table: "Shipments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "order_date",
                table: "Shipments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "notes",
                table: "Shipments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "items",
                table: "Shipments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "carrier_description",
                table: "Shipments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "carrier_code",
                table: "Shipments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "zip",
                table: "Warehouses",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Warehouses",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "province",
                table: "Warehouses",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Warehouses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Warehouses",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Warehouses",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "contact",
                table: "Warehouses",
                newName: "Contact");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Warehouses",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Warehouses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Warehouses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Warehouses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Transfers",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "transfer_to",
                table: "Transfers",
                newName: "Transfer_To");

            migrationBuilder.RenameColumn(
                name: "transfer_status",
                table: "Transfers",
                newName: "Transfer_Status");

            migrationBuilder.RenameColumn(
                name: "transfer_from",
                table: "Transfers",
                newName: "Transfer_From");

            migrationBuilder.RenameColumn(
                name: "reference",
                table: "Transfers",
                newName: "Reference");

            migrationBuilder.RenameColumn(
                name: "items",
                table: "Transfers",
                newName: "Items");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Transfers",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Transfers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "zip_code",
                table: "Suppliers",
                newName: "Zip_Code");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Suppliers",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "reference",
                table: "Suppliers",
                newName: "Reference");

            migrationBuilder.RenameColumn(
                name: "province",
                table: "Suppliers",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "Suppliers",
                newName: "Phonenumber");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Suppliers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Suppliers",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Suppliers",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "contact_name",
                table: "Suppliers",
                newName: "Contact_Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Suppliers",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Suppliers",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address_extra",
                table: "Suppliers",
                newName: "Address_Extra");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Suppliers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Suppliers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Shipments",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "transfer_mode",
                table: "Shipments",
                newName: "Transfer_Mode");

            migrationBuilder.RenameColumn(
                name: "total_package_weight",
                table: "Shipments",
                newName: "Total_Package_Weight");

            migrationBuilder.RenameColumn(
                name: "total_package_count",
                table: "Shipments",
                newName: "Total_Package_Count");

            migrationBuilder.RenameColumn(
                name: "source_id",
                table: "Shipments",
                newName: "Source_Id");

            migrationBuilder.RenameColumn(
                name: "shipment_type",
                table: "Shipments",
                newName: "Shipment_Type");

            migrationBuilder.RenameColumn(
                name: "shipment_status",
                table: "Shipments",
                newName: "Shipment_Status");

            migrationBuilder.RenameColumn(
                name: "shipment_date",
                table: "Shipments",
                newName: "Shipment_Date");

            migrationBuilder.RenameColumn(
                name: "service_code",
                table: "Shipments",
                newName: "Service_Code");

            migrationBuilder.RenameColumn(
                name: "request_date",
                table: "Shipments",
                newName: "Request_Date");

            migrationBuilder.RenameColumn(
                name: "payment_type",
                table: "Shipments",
                newName: "Payment_Type");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "Shipments",
                newName: "Order_Id");

            migrationBuilder.RenameColumn(
                name: "order_date",
                table: "Shipments",
                newName: "Order_Date");

            migrationBuilder.RenameColumn(
                name: "notes",
                table: "Shipments",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "items",
                table: "Shipments",
                newName: "Items");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Shipments",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "carrier_description",
                table: "Shipments",
                newName: "Carrier_Description");

            migrationBuilder.RenameColumn(
                name: "carrier_code",
                table: "Shipments",
                newName: "Carrier_Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Shipments",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Transfer_Mode",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Shipment_Type",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Shipment_Status",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Shipment_Date",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Service_Code",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Request_Date",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Payment_Type",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Order_Date",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Items",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Carrier_Description",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Carrier_Code",
                table: "Shipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
