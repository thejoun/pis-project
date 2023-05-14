using MySqlConnector;
using UserTimelineService.Repository;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var connectionString = builder.Configuration.GetConnectionString("Default") ?? string.Empty;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddTransient<MySqlConnection>(_ => new MySqlConnection(connectionString));
services.AddSingleton<IPostRepository, MySqlPostRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "UserTimelineService v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();