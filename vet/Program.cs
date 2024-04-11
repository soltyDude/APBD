using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
//хз но вроде инициализация фабрики
var builder = WebApplication.CreateBuilder(args);

// добавка в контейнер
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



//труба
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// фин поинт визиты 
app.MapGet("/visits/{animalId}", (int animalId) => 
    Sorage.AllMyVis.Where(v => v.AnimalId == animalId).ToList());
app.MapPost("/visits", (Visit visit) =>
{
    Sorage.AllMyVis.Add(visit);
    return Results.Created($"/visits/{visit.Id}", visit);
});
// фин поинты (проблемы)
app.MapGet("/animals", () => Sorage.AllMyAn);
app.MapGet("/animals/{id}", (int id) => 
    Sorage.AllMyAn.FirstOrDefault(a => a.Id == id));
app.MapPost("/animals", (Animals animal) => 
{
    Sorage.AllMyAn.Add(animal);
    return Results.Created($"/animals/{animal.Id}", animal);
});
app.MapPut("/animals/{id}", (int id, Animals updatedAnimal) =>
{
    var animal = Sorage.AllMyAn.FirstOrDefault(a => a.Id == id);
    if (animal == null) return Results.NotFound();
    animal.Name = updatedAnimal.Name;
    animal.Type = updatedAnimal.Type;
    animal.Weight = updatedAnimal.Weight;
    animal.HareColor = updatedAnimal.HareColor;
    return Results.NoContent();
});
app.MapDelete("/animals/{id}", (int id) =>
{
    var animal = Sorage.AllMyAn.FirstOrDefault(a => a.Id == id);
    if (animal == null) return Results.NotFound();
    Sorage.AllMyAn.Remove(animal);
    return Results.Ok();
});



app.Run();

//храню свалка
class Sorage
{
    public static List<Animals> AllMyAn { get; } = new();
    public static List<Visit> AllMyVis { get; } = new();
}

class Animals
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public double Weight { get; set; }
    public string HareColor { get; set; }
}

class Visit
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    public DateTime DateOfVisit { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}