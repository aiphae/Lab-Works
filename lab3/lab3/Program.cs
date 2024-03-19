using Newtonsoft.Json;

class StringArray
{
    [JsonProperty]
    private string[] Array { get; set; }
    [JsonProperty]
    private int Length { get; set; }
    
    public StringArray(int length)
    {
        Length = length;
        Array = new string[Length];
    }
    
    public string GetString(int index)
    {
        if (index < 0 || index >= Length) throw new IndexOutOfRangeException("Некоректний індекс");
        return Array[index];
    }
    
    public void SetString(int index, string str)
    {
        if (index < 0 || index >= Length) throw new IndexOutOfRangeException("Некоректний індекс");
        Array[index] = str;
    }
    
    // Повертає новий об'єкт класу, що містить строки масивів обох об'єктів 
    public StringArray Concatenate(StringArray b)
    {
        StringArray newArray = new StringArray(Length + b.Length);
        System.Array.Copy(Array, 0, newArray.Array, 0, Length);
        System.Array.Copy(b.Array, 0, newArray.Array, Length, b.Length);

        return newArray;
    }
    
    // Об'єднує два масиви, розширяє за потреби даний масив та додає до нього унікальні строки з масиву b
    public void Merge(StringArray b)
    {
        List<string> temp = new List<string>(Array);
        foreach (string str in b.Array) if (!Array.Contains(str)) temp.Add(str);

        Length = temp.Count;
        Array = temp.ToArray();
    }
    
    public void PrintString(int index)
    {
        if (index < 0 || index >= Length) throw new IndexOutOfRangeException("Некоректний індекс");
        Console.WriteLine(Array[index]);
    }
    
    public void Print()
    {
        foreach (var str in Array) Console.WriteLine(str);
    }
}

class Program
{
    static void Main()
    {
        // Створення двох об'єктів класу StringArray
        var array1 = new StringArray(2);
        array1.SetString(0, "Hello");
        array1.SetString(1, "World");
        array1.Print();

        var array2 = new StringArray(5);
        array2.SetString(0,"123");
        array2.SetString(1, "456");
        array2.SetString(2, "Kornaga");
        array2.SetString(3, "FICT");
        array2.SetString(4, "789");
        Console.WriteLine();
        array2.Print();
        
        // Серіалізація у JSON та десереалізація
        SaveToJson(array2, "../../../array.json");
        var array3 = LoadFromJson("../../../array.json");
        
        var array4 = array2.Concatenate(array1);
        Console.WriteLine("\nОб'єднання двох масивів");
        array4.Print();

        var array5 = new StringArray(3);
        array5.SetString(0, "1");
        array5.SetString(1, "FICT");
        array5.SetString(2, "Kornaga");
        
        array5.Merge(array2);
        Console.WriteLine("\nВключення другого масиву в перший");
        array5.Print();

        Console.ReadKey();
    }

    static void SaveToJson(StringArray obj, string filePath)
    {
        var json = JsonConvert.SerializeObject(obj);
        File.WriteAllText(filePath, json);
    }

    static StringArray LoadFromJson(string filePath)
    {
        if (!File.Exists(filePath)) throw new FileNotFoundException("Файл не знайдено");
        var json = File.ReadAllText(filePath);
        var obj = JsonConvert.DeserializeObject<StringArray>(json);
        
        return obj;
    }
}