using lab13v12;

Console.WriteLine("=== Лабораторна 13. Варіант 12 ===\n");

var numbers = new List<int> { 1, 2, 3, 4, 5 };
var squared = FunctionalUtils.Map(numbers, x => x * x);
Console.WriteLine("1. Map (int -> int): " + string.Join(", ", squared));

var words = new List<string> { "apple", "banana", "cherry" };
var wordLengths = FunctionalUtils.Map(words, w => w.Length);
Console.WriteLine("   Map (string -> int): " + string.Join(", ", wordLengths));

var evenNumbers = FunctionalUtils.Filter(numbers, x => x % 2 == 0);
Console.WriteLine("\n2. Filter (int): " + string.Join(", ", evenNumbers));

var products = new List<Product>
{
    new Product { Name = "Laptop", Price = 1500 },
    new Product { Name = "Mouse", Price = 25 },
    new Product { Name = "Keyboard", Price = 75 },
    new Product { Name = "Monitor", Price = 300 }
};
var expensiveProducts = FunctionalUtils.Filter(products, p => p.Price > 100);
Console.WriteLine("   Filter (Product > 100): " + string.Join(", ", expensiveProducts));

var sortedByPrice = FunctionalUtils.OrderBy(products, p => p.Price);
Console.WriteLine("\n3. OrderBy (Product by Price):");
FunctionalUtils.ForEach(sortedByPrice, p => Console.WriteLine("   - " + p));

var sortedWords = FunctionalUtils.OrderBy(words, w => w.Length);
Console.WriteLine("   OrderBy (string by length): " + string.Join(", ", sortedWords));

var reversedNumbers = FunctionalUtils.Reverse(numbers);
Console.WriteLine("\n4. Reverse (int): " + string.Join(", ", reversedNumbers));

Console.WriteLine("\n5. ForEach (вивід Product):");
FunctionalUtils.ForEach(products, p => Console.WriteLine($"   Товар: {p.Name}, Ціна: {p.Price}"));