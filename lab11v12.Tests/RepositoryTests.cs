using lab11v12;
using Xunit;

namespace lab11v12.Tests;

public class InMemoryRepositoryTests
{
    private static Car C(string brand = "Test", string model = "Model", int year = 2020)
        => new() { Brand = brand, Model = model, Year = year };

    [Fact]
    public void Add_ShouldAddItemAndAssignId()
    {
        var repo = new InMemoryRepository<Car>();
        var car = C("Toyota", "Camry", 2020);

        repo.Add(car);

        Assert.Equal(1, car.Id);
        Assert.Single(repo.GetAll());
    }

    [Fact]
    public void Add_MultipleItems_AssignsUniqueIds()
    {
        var repo = new InMemoryRepository<Car>();
        repo.Add(C("A")); repo.Add(C("B")); repo.Add(C("C"));

        Assert.Equal(3, repo.GetAll().Count());
        Assert.Equal(new[] { 1, 2, 3 }, repo.GetAll().Select(c => c.Id));
    }

    [Fact]
    public void GetById_ExistingId_ReturnsItem()
    {
        var repo = new InMemoryRepository<Car>();
        var car = C("BMW", "X5", 2022);
        repo.Add(car);

        var found = repo.GetById(car.Id);

        Assert.NotNull(found);
        Assert.Equal("BMW", found!.Brand);
        Assert.Equal("X5", found.Model);
    }

    [Fact]
    public void GetById_NonExistingId_ReturnsNull()
    {
        var repo = new InMemoryRepository<Car>();
        repo.Add(C());

        Assert.Null(repo.GetById(999));
    }

    [Fact]
    public void GetAll_Empty_ReturnsEmpty()
    {
        var repo = new InMemoryRepository<Car>();
        Assert.Empty(repo.GetAll());
    }

    [Fact]
    public void GetAll_ReturnsAllItems()
    {
        var repo = new InMemoryRepository<Car>();
        repo.Add(C("A")); repo.Add(C("B"));

        Assert.Equal(2, repo.GetAll().Count());
    }

    [Fact]
    public void Update_Existing_UpdatesFields()
    {
        var repo = new InMemoryRepository<Car>();
        var car = C("Old", "OldModel", 2000);
        repo.Add(car);

        car.Brand = "New";
        car.Model = "NewModel";
        car.Year = 2024;
        repo.Update(car);

        var updated = repo.GetById(car.Id)!;
        Assert.Equal("New", updated.Brand);
        Assert.Equal("NewModel", updated.Model);
        Assert.Equal(2024, updated.Year);
    }

    [Fact]
    public void Update_NonExisting_Throws()
    {
        var repo = new InMemoryRepository<Car>();
        var ghost = C();
        ghost.Id = 999;

        Assert.Throws<InvalidOperationException>(() => repo.Update(ghost));
    }

    [Fact]
    public void Delete_Existing_Removes()
    {
        var repo = new InMemoryRepository<Car>();
        var car = C();
        repo.Add(car);

        repo.Delete(car.Id);

        Assert.Null(repo.GetById(car.Id));
        Assert.Empty(repo.GetAll());
    }

    [Fact]
    public void Delete_NonExisting_Throws()
    {
        var repo = new InMemoryRepository<Car>();
        Assert.Throws<InvalidOperationException>(() => repo.Delete(999));
    }
}