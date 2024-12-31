using Microsoft.EntityFrameworkCore;
using InsurancePolicyApi.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()  
              .WithMethods("GET", "POST", "PUT", "DELETE")  
              .WithHeaders("Content-Type", "Authorization", "departmentcode", "username", "branchCode", "costCenterCode", "MemberCode");  // Allow specific headers including 'departmentcode'
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins"); 

app.UseAuthorization();

app.MapControllers();

app.Run();
