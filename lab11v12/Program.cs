using lab11v12;

var repo = new InMemoryRepository<Car>();

repo.Add(new Car { Brand = "Toyota",  Model = "Camry",   Year = 2020 });
repo.Add(new Car { Brand = "BMW",     Model = "X5",      Year = 2022 });
repo.Add(new Car { Brand = "Tesla",   Model = "Model 3", Year = 2023 });

Console.WriteLine("=== All cars ===");
foreach (var c in repo.GetAll())
    Console.WriteLine($"  #{c.Id} {c.Brand} {c.Model} ({c.Year})");

Console.WriteLine($"\nGetById(2): {repo.GetById(2)?.Brand} {repo.GetById(2)?.Model}");

var bmw = repo.GetById(2)!;
bmw.Year = 2023;
repo.Update(bmw);
Console.WriteLine($"Updated #2 year: {repo.GetById(2)!.Year}");

repo.Delete(3);
Console.WriteLine($"\nAfter Delete(3), count = {repo.GetAll().Count()}");
