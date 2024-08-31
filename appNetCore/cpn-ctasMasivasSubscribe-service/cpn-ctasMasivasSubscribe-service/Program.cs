using cpn_ctasMasivasSubscribe_service.MQ;
using cpn_ctasMasivasSubscribe_service.Services;

var builder = WebApplication.CreateBuilder(args);


// Leer la configuración de RabbitMQ desde appsettings.json
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("rabbitmq"));



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<RabbitMQListenerService>();

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
