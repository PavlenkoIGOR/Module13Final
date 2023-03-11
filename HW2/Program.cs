using System.Text.RegularExpressions;
using System.Linq;

namespace HW2
{
    internal class Program
    {
        public static Dictionary<string, int> dictionary = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            string[] path = { @"d:\", "для SF", "Text_HW2.txt" };
            string filePath = Path.Combine(path);
            string str = string.Empty;
 
            using (StreamReader sr = File.OpenText(filePath))
            {
                str = sr.ReadToEnd().Replace("-", string.Empty);
                //Для того чтобы убрать из текста знаки пунктуации используем следующий фрагмент кода: 
                var noPunctuationText = new string(str.Where(c => !char.IsPunctuation(c)).ToArray());

                // Сохраняем символы-разделители в массив
                char[] delimiters = new char[] { ' ', '\r', '\n'};

                //создание массива из слов с разбитием строки из текста, удаляя ранее перечисленные символы-разделители
                var words = str.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (!dictionary.ContainsKey(word))//проверка есть ли в dictionary слово с заданными Key и Value
                    {
                        dictionary.Add(word, 1);       //если нет - записываем
                    }
                    else
                    {
                        dictionary[word]++;             //если есть - увеличиваем Value на 1
                    }
                }
                //отсортированный список
                //var sortedDictionary = dictionary.OrderByDescending(x => x.Value).Take(10); //сортировка по значению по убыванию
                                                                                           //значения.оставляютмя 10 первых значения
                foreach (var item in dictionary.OrderByDescending(x => x.Value).Take(10))
                {
                    Console.WriteLine(item);
                }
                sr.Close();
            }
            Console.ReadKey();
        }
    }
}
