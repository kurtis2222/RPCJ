using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.IO;

namespace rpcj_pass
{
    class Program
    {
        static string[] passwords =
        {
            "INTR",
            "YMCA",
            "SABR",
            "HELI",
            "BBUS",
            "CMNT",
            "BIGR",
            "HOME",
            "FLIN",
            "DBRN",
            "HEAT",
            "AIRB",
            "DARK",
            "ASOD",
            "PERM",
            "BANK",
            "WOLF",
            "NINA",
            "LEGO",
            "ANAR",
            "WART",
            "BUSD",
            "MOON",
            "CJST",
            "RIPF",
            "CLSH"
        };

        const string filename = "password";

        static void Main(string[] args)
        {
            string data;
            string pass;
            Console.Title = "Rossz PC Játékok Sorozat Jelszó beíró";
            SoundPlayer snd = new SoundPlayer(Properties.Resources._121);
            if (!File.Exists(filename))
            {
                StreamWriter sw = new StreamWriter(filename,false,Encoding.Default);
                sw.Write(Properties.Resources.password);
                sw.Close();
            }
            StreamReader sr = new StreamReader(filename,Encoding.Default);
            data = sr.ReadToEnd();
            sr.Close();

            int i;
            for (i = 0; i < data.Length; i++)
                if (data[i] == 0)
                    break;
            i-=1;

            if(i == -1)
                Console.WriteLine("Jelenleg nincsen jelszavad.");
            else
                Console.WriteLine("A jelenlegi jelszó: " + passwords[i]);
            
            start:
            Console.Write("Kérem a jelszót (4 betű): ");
            pass = Console.ReadLine().ToUpper();
            for (i = 0; i < data.Length; i++)
                if (passwords[i] == pass)
                    break;
            if (i < data.Length)
            {
                StreamWriter sw = new StreamWriter(filename, false, Encoding.Default);
                char[] tmp = data.ToCharArray();
                for (int i2 = 0; i2 <= i; i2++)
                    tmp[i2] = (char)1;
                data = new string(tmp);
                sw.Write(data);
                sw.Close();
                tmp = null;
                snd.Play();
                System.Threading.Thread.Sleep(1000);
                if(i == data.Length-1)
                    Console.WriteLine("A jelszóval az összes pálya elérhető.");
                else
                    Console.WriteLine("A jelszóval a(z) " + (i + 1) +
                        ". pályáig minden pálya elérhető.");
                Console.Write("A folytatáshoz nyomj meg egy billentyűt...");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Helytelen jelszó! Újra?(i/n)");
                if (Console.ReadKey().KeyChar == 'i')
                {
                    Console.Clear();
                    goto start;
                }
            }
        }
    }
}