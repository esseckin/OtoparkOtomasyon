using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otopark_Otomasyon
{
    class Program
    {
        static DateTime[] otoparktakiler = new DateTime[100];
        static void Main(string[] args)
        {
            int index = 0, sayac = 0; ;
            char secc = ' ';
            do
            {
                basadon: Console.Clear();
                Console.WriteLine("1-arac giris");
                Console.WriteLine("2-arac cıkıs");
                Console.WriteLine("3-listele");
                int secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        AracGiris(otoparktakiler, index);
                        index++;
                        sayac = index;
                        break;
                    case 2:
                        Console.WriteLine("hangi aracın cıkmasını istiyorsunuz: (1-{0})", index);
                        int araccıkıs = Convert.ToInt32(Console.ReadLine());
                        AracCikis(otoparktakiler, araccıkıs);
                        break;
                    case 3:
                        AracListele(otoparktakiler, sayac);
                        break;
                    default: goto basadon;

                }
                Console.WriteLine("Devam etmek istiyor musunuz?(e/h)");
                secc = Convert.ToChar(Console.ReadLine());

            } while (secc == 'e');

        }
        static void AracGiris(DateTime[] otoparktakiler, int index)
        {
            if (index == 100)
            {
                Console.WriteLine("Otopark dolu giremezsiniz.");
            }
            else
            {
                Console.WriteLine("lutfen saat giriniz:");
                otoparktakiler[index] = Convert.ToDateTime(Console.ReadLine());
            }

        }

        static void AracCikis(DateTime[] otoparktakiler, int araccıkıs)
        {
            double ucret = 5;
            Console.WriteLine("Cıkıs saatinizi (saat:dakika formatında) giriniz");
            DateTime cıkıssaati = Convert.ToDateTime(Console.ReadLine());

            TimeSpan hesap = cıkıssaati.Subtract(otoparktakiler[araccıkıs - 1]);
            int a = (int)hesap.Hours;

            if (a <= 1)
            {
                ucret = 5;
            }
            else
            {
                ucret = 5;
                for (int i = 1; i < a; i++)
                {
                    ucret += ucret * 20 / 100;
                }
            }
            Console.WriteLine(araccıkıs + " nemaralı araç " + a + "saat otoparkta kalmıstır.Ucretiniz: " + ucret);
        }
        static void AracListele(DateTime[] otoparktakiler, int sayac)
        {
            int[] dizi = new int[sayac];
            if (sayac == 0)
            {
                Console.WriteLine("otopark bos");
            }
            for (int i = 0; i <= sayac; i++)
            {
                Console.WriteLine((i + 1) + ". arac saat " + otoparktakiler[i] + "  giriş yaptı");

            }


        }
    }

}

