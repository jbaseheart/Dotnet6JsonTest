var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddNewtonsoftJson(c => 
{ 
    c.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    c.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include;    
    c.SerializerSettings.Error = (sender, args) =>
    {
        var input = args.ErrorContext.OriginalObject;
        // "input.Gender" will default to 0 (the default value)

        args.ErrorContext.Handled = true;
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
