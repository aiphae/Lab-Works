using Newtonsoft.Json;

var example = new Dictionary<int, int>();
var random = new Random();

// Рандомна генерація словника
for (var i = 0; i < random.Next(50); i++)
{
    int randomKey;
    do
    {
        randomKey = random.Next(0, 1000);
    } while (example.ContainsKey(randomKey));
    example.Add(randomKey, random.Next(0, 100));
}

// Найбільший та найменший ключ
int maxKey = int.MinValue, minKey = int.MaxValue;
foreach (var key in example.Keys)
{
    if (key > maxKey) maxKey = key;
    if (key < minKey) minKey = key;
}

// Видалення елемента з найбільшим ключем, заміна значення найменшного ключа
int tempValue = example[maxKey];
example.Remove(maxKey);
example[minKey] = tempValue;

// Запис у JSON
string json = JsonConvert.SerializeObject(example);
string path = "../../../example.json";
File.WriteAllText(path, json);
Console.WriteLine(json);

Console.ReadKey();