using System.Diagnostics;

namespace Module13.HW1
{
    internal class Program
    {
        static List<string> textList = new List<string>();
        static LinkedList<string> textLinkedList = new LinkedList<string>();
        static void Main(string[] args)
        {
            var txtWatch = new Stopwatch();

            string[] path = { @"d:\", "для SF", "Text1hw1_13.txt" };
            string filePath = Path.Combine(path);



            string str = string.Empty;
            txtWatch.Start();
            using (StreamReader sr = File.OpenText(filePath))
            {
                while ((str = sr.ReadLine()) != null)
                {
                    textList.Add(str);
                }
                txtWatch.Stop(); //имеет значение, где установлен .Stop()
                sr.Close();
            }
            Console.WriteLine($"время потрачено для добавления в List: {txtWatch.ElapsedMilliseconds} ms.");

            txtWatch.Restart();
            txtWatch.Start();
            //а вот так быстрее:
            //// читаем весь файл в массов строк текста
            string [] text = File.ReadAllLines(filePath);
            foreach (var word in text)
            {
                textList.Add(word);
            }
            Console.WriteLine($"время потрачено для добавления в List (через добавление в массив): {txtWatch.ElapsedMilliseconds} ms.");

            txtWatch.Restart();

            str = string.Empty;

            txtWatch.Start();
            using (StreamReader sr2 = File.OpenText(filePath))
            {
                
                while ((str = sr2.ReadLine()) != null)
                {
                    textLinkedList.AddLast(str);
                }
                txtWatch.Stop();
                sr2.Close();
            }
            Console.WriteLine($"время потрачено для добавления в LinkedList: {txtWatch.ElapsedMilliseconds} ms.");
            Console.ReadLine();
        }
    }
}
///
///Считывание из файла на локальном жестком диске очень долгая операция по сравнению со вставкой в список (даже если это ssd). 
///Лучше считать этот файл в оперативную память и потом делать вставки по одной. Так станет более заметная разница. 40-50тыс 
///вставок даст приличный результат. Считать из файла можно сразу в массив минуя конвертацию используя ReadAllLine.