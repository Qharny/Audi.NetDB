using Audit.Core;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    //StrconfigFile = "appsettings.Development.json";
    app.UseSwagger();
    app.UseSwaggerUI();
}

var configuration = builder.Configuration;

Audit.Core.Configuration.Setup()
    .UseSqlServer(config => config
    .ConnectionString((string)configuration.GetConnectionString("DBConn"))
    .Schema("dbo")
    .TableName("Events")
    .IdColumnName("EventId")
    .JsonColumnName("JsonData")
    .LastUpdatedColumnName("LastUpdatedDate")
    //.CustomColumn("MerchantId", ev => 4)
    .CustomColumn("EventType", ev => ev.EventType)
    .CustomColumn("UserId", ev => ev.Environment.UserName));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

