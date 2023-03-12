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

            CounWordsInText(filePath);

            Console.ReadKey();
        }

        static void CounWordsInText(string filePath)
        {
            string str = string.Empty;
            using (StreamReader sr = File.OpenText(filePath))
            {
                str = sr.ReadToEnd().ToUpper().Replace("-", string.Empty);

                var noPunctuationText = new string(str.Where(c => !char.IsPunctuation(c)).ToArray());

                char[] delimiters = new char[] { ' ', '\r', '\n' };

                var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
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
                Console.WriteLine($"10 наиболее частых слов в тексте из директории {filePath}");
                //отсортированный список
                foreach (var item in dictionary.OrderByDescending(x => x.Value).Take(10))
                {
                    Console.WriteLine($"слово {item} раз");
                }
                sr.Close();
            }
        }
    }
}
