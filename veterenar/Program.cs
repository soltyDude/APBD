using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
//хз что (проблема )
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())//труба
{
    app.UseSwagger();
    app.UseSwaggerUI();//тут
}

// фин поинты визит
app.MapGet("/visits/{animalId}", (int animalId) => 
    Collector.AllMyVis.Where(v => v.AnimalId == animalId).ToList());
app.MapPost("/visits", (Visit visit) =>
{
    Collector.AllMyVis.Add(visit);
    return Results.Created($"/visits/{visit.Id}", visit);
});

// фин поинты живность 
app.MapGet("/animals", () => Collector.AllMyAn);
app.MapGet("/animals/{id}", (int id) => 
    Collector.AllMyAn.FirstOrDefault(a => a.Id == id));
app.MapPost("/animals", (Animal animal) => //тут 
{
    Collector.AllMyAn.Add(animal);
    return Results.Created($"/animals/{animal.Id}", animal);
});
app.MapPut("/animals/{id}", (int id, Animal updatedAnimal) =>
{
    var animal = Collector.AllMyAn.FirstOrDefault(a => a.Id == id);
    if (animal == null) return Results.NotFound();
    animal.Name = updatedAnimal.Name;
    animal.Category = updatedAnimal.Category;
    animal.Weight = updatedAnimal.Weight;
    animal.FurColor = updatedAnimal.FurColor;
    return Results.NoContent();
});
app.MapDelete("/animals/{id}", (int id) =>
{
    var animal = Collector.AllMyAn.FirstOrDefault(a => a.Id == id);
    if (animal == null) return Results.NotFound();
    Collector.AllMyAn.Remove(animal);
    return Results.Ok();
});



app.Run();

// свалка
class Collector
{
    public static List<Animal> AllMyAn { get; } = new();
    public static List<Visit> AllMyVis { get; } = new();
}

//классы
class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Weight { get; set; }
    public string FurColor { get; set; }
}

class Visit
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    public DateTime DateOfVisit { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}