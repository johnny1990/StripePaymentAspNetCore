using Contract;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Models;
using Repository;
using Stripe;
using Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IService, Service>();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(new Guid().ToString()));


var app = builder.Build();
AddData(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


static void AddData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<AppDbContext>();

    var t1 = new TShirt
    {
        Id = new Guid("tn2bd844-55hd-4cf3-a21a-53ea0cd9c200"),
        Description = "Polo Shirt",
        Price = "20.20"
    };

    var t2 = new TShirt
    {
        Id = new Guid("117366b8-3541-4af8-8726-860d698e26a2"),
        Description = "Long Shirt",
        Price = "22.99"
    };

    var t3 = new TShirt
    {
        Id = new Guid("66ff5116-bcaa-4061-85b2-6f58fbb6db25"),
        Description = "Green Shirt",
        Price = "30.40"
    };

    var t4 = new TShirt
    {
        Id = new Guid("cd5879dd-9754-4ed2-b44c-488f533243ef"),
        Description = "",
        Price = "19.00"
    };

    var t5 = new TShirt
    {
        Id = new Guid("d32e0829-55fa-4c44-b54f-f345c123af99"),
        Description = "",
        Price = "30.00"
    };

    db.TShirts.Add(t1);
    db.TShirts.Add(t2);
    db.TShirts.Add(t3);
    db.TShirts.Add(t4);
    db.TShirts.Add(t5);

    db.SaveChanges();
}
