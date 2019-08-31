using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNETEncryption
{
    class Program
    {
        static string key;
        static int sloznost;
        static string text;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ключь  [не меньше трёх символов]");
            key = Console.ReadLine();
            Console.Clear();
            Consol();
        }
        public static void Consol()
        {
            Console.WriteLine("Введите сложность ключа [целое число] не меньше 6");
            sloznost = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Для зашифровки: 1");
            Console.WriteLine("Для расшифровки: 2");
            int select = Int32.Parse(Console.ReadLine());
            if (select != default)
            {
                if (select == 1)
                {
                    Console.WriteLine("Введите текст");
                    text = Console.ReadLine();
                    TheEndCoding.Encrypt(key, text);
                }
                else if (select == 2)
                {
                    Console.WriteLine("Введите текст");
                    TheEndCoding.Decrypt(key, Console.ReadLine());
                }
            }
        }
        class TheEndCoding
        {
            private static string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ1234567890 !@#$%^&*()_+№;%:?*()~";
            private static int key = default;
            public static void Encrypt(string key, string text)
            {
                SetKey(key);
                List<char> alph_ru_ru_list = new List<char>();
                List<string> DoubleCode = new List<string>();
                foreach (char ch in alph)
                {
                    alph_ru_ru_list.Add(ch);
                }
                Random rand = new Random(TheEndCoding.key);
                string done = "";

                for (int j = 0; j < alph_ru_ru_list.Count; j++)
                {
                    for (int i = 0; i < sloznost; i++)
                    {
                        done += rand.Next(0, 9);
                    }
                    DoubleCode.Add(done);
                    done = "";
                }
                string CriptText = "";
                for (int j = 0; j < text.Length; j++)
                {
                    for (int i = 0; i < alph_ru_ru_list.Count; i++)
                    {
                        if (text[j] == alph_ru_ru_list[i])
                            CriptText = CriptText += DoubleCode[i];
                    }
                }

                Console.WriteLine("Крипт:");
                Console.WriteLine(CriptText);
                Consol();
            }
            public static void Decrypt(string key, string text)
            {
                SetKey(key);
                List<char> alph_ru_ru_list = new List<char>();
                List<string> DoubleCode = new List<string>();
                foreach (char ch in alph)
                {
                    alph_ru_ru_list.Add(ch);
                }
                Random rand = new Random(TheEndCoding.key);
                string done = "";

                for (int j = 0; j < alph_ru_ru_list.Count; j++)
                {
                    for (int i = 0; i < sloznost; i++)
                    {
                        done += rand.Next(0, 9);
                    }
                    DoubleCode.Add(done);
                    done = "";
                }
                string buffer = "";
                List<string> CriptCode = new List<string>();

                foreach (char i in text)
                {
                    buffer = buffer += i;
                    if (buffer.Length >= sloznost)
                    {
                        CriptCode.Add(buffer);
                        buffer = "";
                    }
                }

                string CriptText = "";
                for (int j = 0; j < CriptCode.Count; j++)
                {
                    for (int i = 0; i < DoubleCode.Count; i++)
                    {
                        if (CriptCode[j] == DoubleCode[i])
                            CriptText = CriptText += alph_ru_ru_list[i];
                    }
                }

                Console.WriteLine("Крипт:");
                Console.WriteLine(CriptText);
                Consol();
            }
            private static void SetKey(string key)
            {
                int dokey = default;
                dokey = key.Length;
                dokey = dokey += Int32.Parse(key);
                dokey = dokey * key.Length;

                int dokeytwo = dokey;
                dokeytwo = (dokey * (key.Length * dokeytwo));
                dokeytwo = dokeytwo - DateTime.Now.Month;

                TheEndCoding.key = dokeytwo;
            }
        }
    }
}
