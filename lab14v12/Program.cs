using lab14v12;

Console.WriteLine("=== Лабораторна 14. Варіант 12: Обробка зображень ===\n");

// ==========================================
// 1. HashSet: Унікальні назви файлів
// ==========================================
Console.WriteLine("--- 1. HashSet: Унікальні назви файлів ---");
var uniqueFiles = new HashSet<string>();

// Додаємо файли (деякі з дублікатами)
uniqueFiles.Add("photo1.jpg");
uniqueFiles.Add("photo2.png");
uniqueFiles.Add("photo1.jpg"); // Дублікат не додасться
uniqueFiles.Add("landscape.jpeg");

Console.WriteLine($"Кількість унікальних файлів: {uniqueFiles.Count}");
Console.WriteLine("Файли у HashSet:");
foreach (var file in uniqueFiles)
{
    Console.WriteLine($" - {file}");
}

// Перевірка наявності
string checkFile = "photo2.png";
Console.WriteLine($"Чи є файл '{checkFile}' у колекції? -> {uniqueFiles.Contains(checkFile)}");

// Видалення
uniqueFiles.Remove("landscape.jpeg");
Console.WriteLine($"Після видалення 'landscape.jpeg' залишилось файлів: {uniqueFiles.Count}\n");


// ==========================================
// 2. Queue: Черга зображень на обробку (FIFO)
// ==========================================
Console.WriteLine("--- 2. Queue: Черга зображень на обробку ---");
var processingQueue = new Queue<ImageFile>();

// Додаємо в чергу (Enqueue)
processingQueue.Enqueue(new ImageFile("cat", "jpg"));
processingQueue.Enqueue(new ImageFile("dog", "png"));
processingQueue.Enqueue(new ImageFile("nature", "jpeg"));

Console.WriteLine($"У черзі на обробку: {processingQueue.Count} зображень.");

var nextToProcess = processingQueue.Peek();
Console.WriteLine($"Наступне на обробку (Peek): {nextToProcess}");

while (processingQueue.Count > 0)
{
    var current = processingQueue.Dequeue();
    Console.WriteLine($"Оброблено: {current}. Залишилось в черзі: {processingQueue.Count}");
}
Console.WriteLine();


Console.WriteLine("--- 3. Stack: Історія фільтрів (Undo) ---");
var filterHistory = new Stack<string>();

filterHistory.Push("Зміна розміру (Resize)");
filterHistory.Push("Чорно-білий (Grayscale)");
filterHistory.Push("Розмиття (Blur)");

Console.WriteLine($"В історії фільтрів: {filterHistory.Count} дій.");

Console.WriteLine($"Останній застосований фільтр (Peek): {filterHistory.Peek()}");

Console.WriteLine("\nПочинаємо Undo:");
while (filterHistory.Count > 0)
{
    var undoneFilter = filterHistory.Pop();
    Console.WriteLine($"Скасовано фільтр: {undoneFilter}. Залишилось в історії: {filterHistory.Count}");
}