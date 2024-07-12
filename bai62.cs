using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Program
{
    public static Dictionary<string, string> ReadDictionaryFromJsonFile(string fileName)
    {
        try
        {
            string jsonString = File.ReadAllText(fileName);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
            return dictionary;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }

    public static void Main()
    {
        string fileName = "output.json";
        var dictionary = ReadDictionaryFromJsonFile(fileName);

        if (dictionary != null)
        {
            Console.WriteLine("Dictionary read from file:");
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
        else
        {
            Console.WriteLine("An error occurred while reading the dictionary from the file.");
        }
    }
}
