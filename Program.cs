using SpringCoAccountAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "SpringCoAPI", Version = "v1" });
});

builder.Services.AddDbContext<SpringCoDbContext>(options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:SpringCoDbContext").Value));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GDPR Consent API v1"));
    //app.UseExceptionHandler("/Home/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpringCoAPI"));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();