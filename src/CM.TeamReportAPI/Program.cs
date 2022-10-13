using CM.TeamReport.Domain.Services;
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamReportAPI.Configurations;
using CM.TeamReportAPI.MapperStore;
using CM.TeamRepots.DataLayer.Interfaces;
using CM.TeamRepots.DataLayer.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CM.TeamRepots.DataLayer.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddTransient<IReportsService, ReportsService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UsersRepository>();
builder.Services.AddScoped<ILeaderSevice, LeaderService>();
builder.Services.AddScoped<IReportsRepository, ReportsRepository>();
builder.Services.AddScoped<ILeaderRepository, LeaderRepository>();
builder.Services.AddScoped<ITeamRepository, TeamsRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
    .AddJwtBearer(jwt =>
    {
        var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime =  true,

        };
    });



var app = builder.Build();

app.UseCors(builder =>
{
    builder.SetIsOriginAllowed(origin => true)
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
});

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
