using System;

// Лабараторная работа 10 27.11.2024
class MyClass{
    private int value1; 
    private int value2;

    public MyClass(){
        value1 = 0;
        value2 = 0;
    }

    public MyClass(int val1){
        value1 = val1;
        value2 = 0;
    }

    public MyClass(int val1, int val2){
        value1 = val1;
        value2 = val2;
    }

    public int Sum(){
        return value1 + value2;
    }

    public int Multiply(){
        return value1 * value2;
    }

    public int Subtract(){
        return value1 - value2;
    }

    public string Divide(){
        if (value2 == 0){
            return "Ошибка: деление на ноль!";
        }
        return ((double)value1 / value2).ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyClass obj1 = new MyClass();
        MyClass obj2 = new MyClass(10);
        MyClass obj3 = new MyClass(20, 5);

        Console.WriteLine($"Объект 1:");
        Console.WriteLine($"Сумма: {obj1.Sum()}, Разность: {obj1.Subtract()}, Умножение: {obj1.Multiply()}, Деление: {obj1.Divide()}");

        Console.WriteLine("\nОбъект 2:");
        Console.WriteLine($"Сумма: {obj2.Sum()}, Разность: {obj2.Subtract()}, Умножение: {obj2.Multiply()}, Деление: {obj2.Divide()}");

        Console.WriteLine("\nОбъект 3:");
        Console.WriteLine($"Сумма: {obj3.Sum()}, Разность: {obj3.Subtract()}, Умножение: {obj3.Multiply()}, Деление: {obj3.Divide()}");
    }
}
