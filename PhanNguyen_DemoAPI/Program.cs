using Microsoft.EntityFrameworkCore;
using PhanNguyen_DemoAPI;
using PhanNguyen_DemoAPI.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Security.Cryptography;
using PhanNguyen_DemoAPI.Repositories;
using PhanNguyen_DemoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver =
        new DefaultContractResolver();
    options.SerializerSettings.ReferenceLoopHandling =
        ReferenceLoopHandling.Ignore;
});
builder.Services.AddTransient<Seed>();

//Add DI
AddDI(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => 
policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

//builder.Services.AddDbContext<DataContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

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

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }

}

void AddDI(IServiceCollection services)
{
    #region NhanVien
    services.AddScoped<NhanVienRepository>();
    services.AddScoped<INhanVienService, NhanVienService>();
    #endregion

    #region PhanCong
    services.AddScoped<PhanCongRepository>();
    services.AddScoped<IPhanCongService, PhanCongService>();
    #endregion

    #region DuAn
    services.AddScoped<DuAnRepository>();
    services.AddScoped<IDuAnService, DuAnService>();
    #endregion

    #region BaoHiem
    services.AddScoped<BaoHiemRepository>();
    services.AddScoped<IBaoHiemService, BaoHiemService>();
    #endregion

    #region PhongBan
    services.AddScoped<PhongBanRepository>();
    services.AddScoped<IPhongBanService, PhongBanService>();
    #endregion

    services.AddAutoMapper(typeof(Program).Assembly);
}
