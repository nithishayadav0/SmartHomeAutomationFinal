using SmartHomeAutomation.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartHomeAutomation.Repositories;
using SmartHomeAutomation.Services;
using System.Text;
using SmartHomeAutomation.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<DeviceRepository>();
builder.Services.AddScoped<DeviceService>();
builder.Services.AddScoped<EnergyMonthlyUsageService>();
builder.Services.AddSingleton<JWTTOKENService>();

builder.Services.AddSingleton<EnergyUsageBackgroundService>();
builder.Services.AddHostedService<EnergyUsageBackgroundService>();
//builder.Services.AddHostedService<DeviceMonitoringService>();
builder.Services.AddSingleton<AutomationMonitoringService>();
builder.Services.AddHostedService<AutomationMonitoringService>();
builder.Services.AddSingleton<EnergyUsageService>();
builder.Services.AddHostedService<EnergyUsageService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHostedService<EnergyUsageService>();
builder.Services.AddSignalR();
builder.Services.AddSingleton<SignalRService>();
builder.Services.AddScoped<IAutomationRepository, AutomationRepository>();
builder.Services.AddScoped<IAutomationService, AutomationService>();
builder.Services.AddScoped<IDeviceMaintenanceRepository, DeviceMaintenanceRepository>();
builder.Services.AddScoped<IDeviceMaintenanceService, DeviceMaintenanceService>();
builder.Services.AddScoped<IGlobalAutomationRepository, GlobalAutomationRepository>();
builder.Services.AddScoped<IGlobalAutomationService, GlobalAutomationService>();
builder.Services.AddScoped<ISecurityRepository, SecurityRepository>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<ISettingRepository, SettingRepository>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddSingleton<DeviceSpeechMonitorService>();
builder.Services.AddHostedService<DeviceSpeechMonitorService>();
builder.Services.AddSingleton<SecurityDeviceService>();
builder.Services.AddHostedService<SecurityDeviceService>();


// Add controllers with specific JSON settings
builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.MaxDepth = 64; 
    });

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()  // Allow requests from any origin
              .AllowAnyMethod()  // Allow all HTTP methods (GET, POST, etc.)
              .AllowAnyHeader(); // Allow all headers
    });
});

// Configure JWT authentication
var jwtval = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtval["Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtval["Issuer"],
        ValidAudience = jwtval["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Add authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Homeowner", policy => policy.RequireRole("Homeowner"));
    options.AddPolicy("Guest", policy => policy.RequireRole("Guest"));
    options.AddPolicy("All", policy => policy.RequireRole("Administrator", "Homeowner","Guest", "DeviceTechnician"));
    options.AddPolicy("Administrator", policy => policy.RequireRole("Administrator"));
    options.AddPolicy("DeviceTechnician", policy => policy.RequireRole("Administrator"));

});

// Configure Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext
builder.Services.AddDbContext<SmartHomeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.MapHub<AlertHub>("/alertHub");

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
