
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AcmsAPI
{
    class AuthOptions
    {
        public const string ISSUER = "ACMSAuthServer"; // �������� ������
        public const string AUDIENCE = "ACMSAuthClient"; // ����������� ������
        const string KEY = "mysupersecret_secretsecretsecretkey!123";
        
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<Entities.Access�ontrol�ndManagementInformationSystemContext>();

            builder.Services.AddMvcCore().AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    // ���������, ����� �� �������������� �������� ��� ��������� ������
                                    ValidateIssuer = true,
                                    // ������, �������������� ��������
                                    ValidIssuer = AuthOptions.ISSUER,
                                    // ����� �� �������������� ����������� ������
                                    ValidateAudience = true,
                                    // ��������� ����������� ������
                                    ValidAudience = AuthOptions.AUDIENCE,
                                    // ����� �� �������������� ����� �������������
                                    ValidateLifetime = true,
                                    // ��������� ����� ������������
                                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                                    // ��������� ����� ������������
                                    ValidateIssuerSigningKey = false,
                                };
                            });
            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDeveloperExceptionPage();

            app.MapControllers();

            app.Run();
        }
    }
    
}
