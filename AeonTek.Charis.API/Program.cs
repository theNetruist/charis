
using AeonTek.Charis.API.Data;
using AeonTek.Charis.API.Data.Enums;
using AeonTek.Charis.API.Logic;

namespace AeonTek.Charis.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCharisLogic();
            builder.Services.AddCharisData(
                DatabaseType.Sqlite,
                $"Data Source={Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Charis.db")}");

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();
            });
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
        }
    }
}