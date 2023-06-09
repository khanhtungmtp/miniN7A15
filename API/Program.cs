using API._Validators;
using API.Configuration;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddControllers(options =>
// {
//     options.Filters.Add<AddValidationFilter>();
// })
//     .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
//     .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddControllers(opt => opt.Filters.Add<AddValidationFilter>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddFluentValidationConfig();


// add register services
builder.Services.AddDepedencyInjectionConfig();
// add database
builder.Services.AddDatabaseConfig(builder.Configuration);
// add cord
builder.Services.AddCors(opt => opt.AddPolicy("AllowOrigin", policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// add automapper
builder.Services.AddAutoMapper(typeof(AddAutoMapperProfilesConfig));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
