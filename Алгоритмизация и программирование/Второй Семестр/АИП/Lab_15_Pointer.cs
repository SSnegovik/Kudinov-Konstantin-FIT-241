using System;

//Лабораторная работа 15 16.05.2025

class Program
{
    unsafe static void Main()
    {
        Console.WriteLine("Введите размер массива:");
        int size = int.Parse(Console.ReadLine());

        int* ptrArray = stackalloc int[size];

        Console.WriteLine("Введите элементы массива:");
        for (int index = 0; index < size; index++)
        {
            Console.Write($"Элемент №{index + 1}: ");
            *(ptrArray + index) = int.Parse(Console.ReadLine());
        }

        int countEvenNumbers = 0;
        for (int index = 0; index < size; index++)
        {
            if (*(ptrArray + index) % 2 == 0)
                countEvenNumbers++;
        }

        Console.WriteLine($"Количество чётных элементов: {countEvenNumbers}");
    }
}
