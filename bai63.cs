using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Program
{
    public static bool WriteDictionaryToJsonFile(Dictionary<string, string> dictionary, string fileName)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(dictionary);
            File.WriteAllText(fileName, jsonString);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false;
        }
    }

    public static void Main()
    {
        var sampleDictionary = new Dictionary<string, string>
        {
            { "Key1", "Value1" },
            { "Key2", "Value2" },
            { "Key3", "Value3" }
        };

        string fileName = "output.json";
        bool result = WriteDictionaryToJsonFile(sampleDictionary, fileName);

        if (result)
        {
            Console.WriteLine($"Dictionary was successfully written to {fileName}");
        }
        else
        {
            Console.WriteLine("An error occurred while writing the dictionary to the file.");
        }
    }
}
