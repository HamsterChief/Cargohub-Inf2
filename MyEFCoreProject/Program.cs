using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("sqlite")));
=======
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:80");

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlite")));
>>>>>>> C#-Cargohub

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IItem_GroupService, Item_GroupService>();
builder.Services.AddScoped<IItem_LineService, Item_LineService>();
builder.Services.AddScoped<IItem_TypeService, Item_TypeService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ITransferService, TransferService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

<<<<<<< HEAD
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseSession();

app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

// Add authorization middleware if required
// app.UseAuthorization(); 
// to run on the ssh: 
// cd Cargohub-inf2 ->
// cd MyEFCoreProject ->
// nohup dotnet run --urls "http://0.0.0.0:5072" > output.log 2>&1 &

app.Urls.Add("http://localhost:80");

=======
// Add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cargohub API",
        Version = "v1",
        Description = "API Documentation for the new Cargohub API",
        Contact = new OpenApiContact
        {
            Name = "Cargohub"
        }
    });
});

var app = builder.Build();

app.UseMiddleware<ApiKeyMiddleware>();

app.UseSession();

app.UseRouting();

// Enable Swagger
if (app.Environment.IsDevelopment() || true) // Allow Swagger in all environments
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Serve Swagger UI at /api/v1 instead of /swagger
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");  // Correct the endpoint path
        c.RoutePrefix = "swagger";  // This ensures Swagger UI is at the root path /api/v1
    });
}
// Add authorization middleware if required
// app.UseAuthorization(); 

app.MapControllers();

>>>>>>> C#-Cargohub
app.Run();
