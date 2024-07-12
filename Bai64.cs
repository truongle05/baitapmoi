// See httpusing System;
using System.IO;

public class Program
{
    public static void Main()
    {
        // Tạo một mảng 2 chiều các số thực mẫu
        float[,] array = {
            { 1.1f, 2.2f, 3.3f },
            { 4.4f, 5.5f, 6.6f },
            { 7.7f, 8.8f, 9.9f }
        };

        // Tên file CSV
        string fileName = "output.csv";

        // Ghi mảng 2 chiều vào file CSV
        WriteArrayToCsv(fileName, array);

        Console.WriteLine($"Mang da duoc ghi thanh cong vao file: {fileName}");
    }

    public static void WriteArrayToCsv(string fileName, float[,] array)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                int rows = array.GetLength(0);
                int columns = array.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        writer.Write(array[i, j]);
                        if (j < columns - 1)
                        {
                            writer.Write(","); // Thêm dấu phân cách giữa các cột
                        }
                    }
                    writer.WriteLine(); // Thêm dòng mới sau mỗi hàng
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Loi: {ex.Message}");
        }
    }
}
