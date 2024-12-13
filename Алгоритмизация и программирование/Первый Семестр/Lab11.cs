using System;
using System.Collections.Generic;
using System.Linq;

namespace Studentsr{
    class Program{
        class Student{
            public string FullName { get; set; }
            public int BirthYear { get; set; }
            public string MotherName { get; set; }
            public string FatherName { get; set; }
            public string Address { get; set; }
        }

        static List<Student> students = new List<Student>();

        static void Main(string[] args){
            while (true){
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Заполнить данные ученика");
                Console.WriteLine("2. Изменить данные ученика");
                Console.WriteLine("3. Найти учеников по первой букве ФИО");
                Console.WriteLine("4. Найти учеников по улице");
                Console.WriteLine("5. Найти учеников по году рождения");
                Console.WriteLine("6. Выход");
                Console.Write("Введите номер: ");

                string vibor = Console.ReadLine();

                switch (vibor){
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        ModifyStudent();
                        break;
                    case "3":
                        FirstLetter();
                        break;
                    case "4":
                        Street();
                        break;
                    case "5":
                        Year();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте снова.");
                        break;
                }
            }
        }

        static void AddStudent(){
            Console.Write("Введите ФИО ученика: ");
            string fullName = Console.ReadLine();

            Console.Write("Введите год рождения: ");
            int birthYear = int.Parse(Console.ReadLine());

            Console.Write("Введите ФИО мамы (можно пропустить): ");
            string motherName = Console.ReadLine();

            Console.Write("Введите ФИО папы (можно пропустить): ");
            string fatherName = Console.ReadLine();

            Console.Write("Введите адрес (улица, дом, квартира): ");
            string address = Console.ReadLine();

            students.Add(new Student{
                FullName = fullName,
                BirthYear = birthYear,
                MotherName = motherName,
                FatherName = fatherName,
                Address = address
            });

            Console.WriteLine("Ученик успешно добавлен.");
        }

        static void ModifyStudent(){
            Console.Write("Введите ФИО ученика для изменения: ");
            string fullName = Console.ReadLine();

            Student student = null;
            foreach (var s in students){
                if (s.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase)){
                    student = s;
                    break;
                }
            }

            if (student == null){
                Console.WriteLine("Ученик с таким ФИО не найден.");
                return;
            }

            Console.Write("Введите новое ФИО ученика: ");
            student.FullName = Console.ReadLine();

            Console.Write("Введите новый год рождения: ");
            student.BirthYear = int.Parse(Console.ReadLine());

            Console.Write("Введите новое ФИО мамы (можно пропустить): ");
            student.MotherName = Console.ReadLine();

            Console.Write("Введите новое ФИО папы (можно пропустить): ");
            student.FatherName = Console.ReadLine();

            Console.Write("Введите новый адрес (улица, дом, квартира): ");
            student.Address = Console.ReadLine();

            Console.WriteLine("Данные ученика успешно изменены.");
        }

        static void FirstLetter(){
            Console.Write("Введите первую букву ФИО: ");
            char firstLetter = char.Parse(Console.ReadLine());

            var result = new List<Student>();
            foreach (var student in students){
                if (student.FullName.StartsWith(firstLetter.ToString(), StringComparison.OrdinalIgnoreCase)){
                    result.Add(student);
                }
            }

            if (result.Count == 0){
                Console.WriteLine("Учеников с указанной буквой ФИО не найдено.");
                return;
            }

            Console.WriteLine("Найденные ученики:");
            foreach (var student in result){
                Console.WriteLine(student.FullName);
            }
        }

        static void Street(){
            Console.Write("Введите название улицы: ");
            string street = Console.ReadLine();

            var result = new List<Student>();
            foreach (var student in students){
                if (student.Address != null && student.Address.IndexOf(street, StringComparison.OrdinalIgnoreCase) >= 0){
                    result.Add(student);
                }
            }

            if (result.Count == 0){
                Console.WriteLine("Учеников, проживающих на указанной улице, не найдено.");
                return;
            }

            Console.WriteLine("Найденные ученики:");
            foreach (var student in result){
                Console.WriteLine(student.FullName);
            }
        }

        static void Year(){
            Console.Write("Введите год рождения: ");
            int year = int.Parse(Console.ReadLine());

            var result = new List<Student>();
            foreach (var student in students){
                if (student.BirthYear == year){
                    result.Add(student);
                }
            }

            if (result.Count == 0){
                Console.WriteLine("Учеников с указанным годом рождения не найдено.");
                return;
            }

            Console.WriteLine("Найденные ученики:");
            foreach (var student in result){
                Console.WriteLine(student.FullName, student.BirthYear);
            }
        }
    }
}
