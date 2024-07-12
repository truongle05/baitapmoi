using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main()
    {
        // Tạo một Dictionary mẫu với kiểu giá trị là double
        Dictionary<string, double> dictionary = new Dictionary<string, double>
        {
            { "Item1", 123.456 },
            { "Item2", 789.101 },
            { "Item3", 112.131 }
        };

        // Tên file CSV
        string fileName = "output_with_header.csv";

        // Ghi Dictionary vào file CSV với header
        WriteDictionaryToCsv(fileName, dictionary);

        Console.WriteLine($"Dictionary da duoc ghi thanh cong vao file: {fileName}");
    }

    public static void WriteDictionaryToCsv(string fileName, Dictionary<string, double> dictionary)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // Viết header
                writer.WriteLine("Key,Value");

                // Viết dữ liệu
                foreach (var kvp in dictionary)
                {
                    writer.WriteLine($"{kvp.Key},{kvp.Value}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Loi: {ex.Message}");
        }
    }
}
