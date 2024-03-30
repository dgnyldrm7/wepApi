using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wepApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//Connnection string yazalým!
builder.Services.AddDbContext<ProductContext>(options =>
{
    var config = builder.Configuration;
    var ConnectionString = config.GetConnectionString("database");
    options.UseSqlite(ConnectionString);
});

//Identity için eklemeleri buraya yazarýz!  //Context sýnýfýmýzý Stores içersin yazarýz!
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ProductContext>();

//Þimdi de Identity Configure'larýný burada ekleyebiliriz!
//Ýdentity ile kýsýtlamalarý burada ekleriz!!!!
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
