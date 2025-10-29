using ApiRemedio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=remedio.db"));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()    // permite qualquer origem
              .AllowAnyMethod()    // permite GET, POST, PUT, DELETE, etc.
              .AllowAnyHeader();   // permite qualquer header (ex: Content-Type)
    });
});




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

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

app.MapGet("/remedios", async (AppDbContext banco)=> {
    return await banco.Remedios.ToListAsync();
});

app.MapGet("/remedios/{id}", async (AppDbContext banco, int id)=> {
    var remedio = await banco.Remedios.FindAsync(id);
    return remedio is not null ? Results.Ok(remedio) : Results.NotFound("remedio não encontrado!");
});

app.MapDelete("/remedios/{id}", async (AppDbContext banco, int id)=> {
    var remedio = await banco.Remedios.FindAsync(id);
    if (remedio is null) return Results.NotFound("remedio não encontrado!");

    banco.Remedios.Remove(remedio);
    await banco.SaveChangesAsync();
    return Results.NoContent();
});











app.Run();