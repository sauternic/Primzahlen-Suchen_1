using System.Diagnostics;
using System;

//Programm_rein_Dezimal.cs
namespace Primzahlen
{
    class CPrimzahlen
    {
        //Reine Info:
        //21 Stellen :  100000000000000000000
        //16 Stellen:   1000000000000000
        //14 Stellen:   10000000000000
        //Max Uint64 =  18446744073709551615;
        //Max decimal = 79228162514264337593543950335M;

        //Field
        static Stopwatch s = new Stopwatch();
        static int P_Nr = 0;


        //Viel zu langsam schon bei 16 Stellen wartet man ewigs!!! :((((
        static void Main()
        {
            Decimal anfang = 0;
            Decimal ende = 0;

            Console.Write("\n   Programm_rein_Dezimal\n\n");
            Console.Write("\n\n   Primzahlenauflisten!\n\n");
            Console.Write("\n   Untere Grenze Eingeben? ");
            anfang = Convert.ToDecimal(Console.ReadLine());

            Console.Write("   Obere  Grenze Eingeben? ");
            ende = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();//Leerzeile

            SuchePrimzahlen(anfang, ende);
        }

        //Noch ohne Parallel.For!
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void SuchePrimzahlen(Decimal anfang, Decimal ende)
        {
            label1:
            //Aeussere Schleife Ersetzt Hand Eingabe.
            for (; anfang <= ende; anfang++)
            {
                //Orientierung wo gerade ist?
                //Console.WriteLine("Bin hier am Rechnen: {0:#,#}", anfang);

                //Kein Flaschenhals!! :O
                ulong Wurzel_anfang = (ulong)Math.Pow(Convert.ToDouble(anfang), 0.5);

                s.Start();

                //Primzahlen Engine! :)
                for (ulong x = 2; x <= Wurzel_anfang; x++)
                {
                    //Wenn mod == 0 ist keine Primzahl
                    //Dezimal Modulo langsam wie ne Kuh! :(
                    if (anfang % x == 0)
                    {
                        //Schleife erhöht über label1 anfang nicht:
                        ++anfang;
                        goto label1;
                    }
                }

                //1 und 0 rausputzen! ;)
                if (anfang == 1 || anfang == 0)
                    continue;

                s.Stop();
                TimeSpan timeSpan = s.Elapsed;

                ++P_Nr;

                //Ausgabe
                string ausgString = String.Format("\nPrimzahl {0} :)  {1:#,#}\n", P_Nr, anfang);
                ausgString += String.Format("Time: {0}h {1}m {2}s {3}ms\n", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

                Console.WriteLine(ausgString);
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
            }
            Console.WriteLine("Fertig! :)");
            Console.WriteLine("\n\tCopyright © Nicolas Sauter");
            Console.ReadLine();
        }
    }
}
