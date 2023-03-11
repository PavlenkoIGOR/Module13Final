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

            //// читаем весь файл с рабочего стола в строку текста
            //string text = File.ReadAllText(filePath);

            string str = string.Empty;

            using (StreamReader sr = File.OpenText(filePath))
            {
                txtWatch.Start();

                while ((str = sr.ReadLine()) != null)
                {
                    textList.Add(str);
                }
                txtWatch.Stop(); //имеет значение, где установлен .Stop()
                sr.Close();
            }
            Console.WriteLine($"время потрачено для добавления в List: {txtWatch.ElapsedMilliseconds} ms.");

            txtWatch.Restart();

            str = string.Empty;
            using (StreamReader sr2 = File.OpenText(filePath))
            {
                txtWatch.Start();
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