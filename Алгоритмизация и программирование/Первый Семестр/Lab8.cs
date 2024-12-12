using System;
class HelloWorld {
  static void Main() {
      // Лабараторная работа 07.11.2024
      // Задание 1 Убрать лишние пробелы в строке
      
      Console.WriteLine("Введите строку с пробелами");
      string input = Console.ReadLine();
      string[] w = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      string output = string.Join(" ", w);
      Console.WriteLine("Строка без пробелов: " + output);
      Console.WriteLine();
      
      //Задание 2 Выдать слова палиндромы
      
      Console.WriteLine("Введите слова через 1 пробел");
      string palidromswords = Console.ReadLine();
      string[] words = palidromswords.Split(' ');
      Console.WriteLine("Слова палиндромы:");
      for (int i = 0; i < words.Length; i++){
                string word = words[i];
                char[] stringarray = word.ToCharArray();
                Array.Reverse(stringarray);
                string reversedStr = new string(stringarray);
                if(word == reversedStr){
                    Console.WriteLine(word);
                }
        }
        
       //Задание 3 Определить является ли строка палиндромом
        
       Console.WriteLine("Введите предложение");
       string stroka = Console.ReadLine();
       string palidromsstroka = stroka.Replace(" ", "");
       string lowerstroka = palidromsstroka.ToLower();
       char[] stringarr = lowerstroka.ToCharArray();
       Array.Reverse(stringarr);
       string akortssmordilap = new string(stringarr);
       if(akortssmordilap == lowerstroka){
           Console.WriteLine("Эта строка палиндром");
       }
       else{
           Console.WriteLine("Эта строка не палиндром");
       }
        
       // Задание 4 Вывести строки в которых гласных больше чем согласных
       
       Console.WriteLine("Введите количество строк");
       int n = int.Parse(Console.ReadLine());
       string vowels = "аеёиоуыэюя";
       int countvowels = 0;
       for(int i = 0; i<n; i++){
           Console.WriteLine("Введите строку");
           string lines = Console.ReadLine();
           string lowerst = lines.ToLower();
           for(int j = 0; j<lowerst.Length; j++){
              for(int k = 0; k<vowels.Length; k++){
                  if(lowerst[j] == vowels[k]){
                      countvowels++;
                   }
               }
       }
       if(countvowels > lowerst.Length - countvowels){
           Console.WriteLine("В данной строке гласных больше согласных");
           Console.WriteLine();
       }
       else{
           Console.WriteLine("В данной строке гласных меньше согласных");
           Console.WriteLine();
       }
       countvowels = 0;
       }
  }
}