using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // Tên file CSV
        string fileName = "input.csv";

        // Đọc file CSV vào mảng 2 chiều
        double[,] array = ReadCsvToArray(fileName, out bool hasHeader);

        // Kiểm tra và in kết quả
        if (array != null)
        {
            Console.WriteLine($"File CSV {(hasHeader ? "co" : "khong co")} header.");
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            Console.WriteLine("Mang 2 chieu:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Da xay ra loi khi doc file CSV hoac file rong.");
        }
    }

    public static double[,] ReadCsvToArray(string fileName, out bool hasHeader)
    {
        try
        {
            var lines = File.ReadAllLines(fileName);

            if (lines.Length == 0)
            {
                hasHeader = false;
                return null; // File rỗng
            }

            // Xác định có header hay không
            hasHeader = IsHeader(lines[0]);
            int startIndex = hasHeader ? 1 : 0;

            var data = new List<List<double>>();

            for (int i = startIndex; i < lines.Length; i++)
            {
                var values = lines[i].Split(',').Select(v => double.Parse(v)).ToList();
                data.Add(values);
            }

            if (data.Count == 0 || data[0].Count == 0)
            {
                return null; // Không có dữ liệu
            }

            int numRows = data.Count;
            int numCols = data[0].Count;
            double[,] array = new double[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    array[i, j] = data[i][j];
                }
            }

            return array;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Loi: {ex.Message}");
            hasHeader = false;
            return null;
        }
    }

    private static bool IsHeader(string line)
    {
        // Cách đơn giản để xác định nếu dòng có vẻ như là header
        // Đây chỉ là một ví dụ, bạn có thể thay đổi logic nếu cần
        return line.Split(',').All(s => !double.TryParse(s, out _));
    }
}
