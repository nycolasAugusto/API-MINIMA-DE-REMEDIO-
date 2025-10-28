using ApiRemedio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=remedio.db"));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapPost("/remedios", async (AppDbContext banco , RemedioEntidade remedioRecebido) =>{
    banco.Remedios.Add(remedioRecebido);
    await banco.SaveChangesAsync();
    return  Results.Created($"/remedios/{remedioRecebido.Id}", remedioRecebido);


});









app.Run();