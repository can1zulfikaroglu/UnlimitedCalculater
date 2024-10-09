using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Collections;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Reflection.Emit;
class HesapMakinesi
{
  
    static void Main()
    {
        string sayi1;
        string sayi2;
        string x = "";
        string y;
        int boyutx;
        int boyuty;
        char xeleman;
        char yeleman;
        int i;
        int j;
        int barx;
        int bary;
        int sonuc = 0;
        int elde = 0;
        bool eldekontrol = false;
        int sayi;
        int eldelisonuc;
        int kacsifir;
        string islem;
        bool komsu = false;//çıkarma için
        bool yanliscikarma = false;//çıkarma için
        ArrayList results = new ArrayList();
        void CikarmaKuralları()
        {
            if (i == j)
            {    //ilk basamak
                if (j == boyuty)
                {
                    //1. sayı 2.sinden büyük ise
                    if (barx >= bary)
                    {
                        sonuc = barx - bary;
                        results.Add(sonuc);
                        komsu = false;
                    }
                    else
                    {
                        sonuc = (barx + 10) - bary;
                        results.Add(sonuc);
                        komsu = true;
                    }
                }
                //son basamak
                else if (j == 1)
                {
                    if (barx >= bary)
                    {
                        if (komsu == true)
                        {
                            sonuc = barx - bary - 1;
                            results.Add(sonuc);
                            komsu = false;
                        }
                        else
                        {
                            sonuc = barx - bary;
                            results.Add(sonuc);
                            komsu = false;
                        }
                    }
                    // alttaki sayının son basamağı büyük olursa!!
                    else
                    {
                        yanliscikarma = true;
                    }
                }
                //ara basamaklar
                else
                {
                    if (barx >= bary)
                    {
                        if (komsu == true)
                        {
                            sonuc = barx - bary - 1;
                            results.Add(sonuc);
                            komsu = false;
                        }
                        else
                        {
                            sonuc = barx - bary;
                            results.Add(sonuc);
                        }
                    }
                    else
                    {
                        if (komsu == true)
                        {
                            sonuc = (barx + 10) - bary - 1;
                            results.Add(sonuc);
                            komsu = true;
                        }
                        else
                        {
                            sonuc = (barx + 10) - bary;
                            results.Add(sonuc);
                            komsu = true;
                        }
                    }
                }
            }

        }
        void cikarmaIslemi()
        {
            for (i = boyutx; i > 0; i--)
            {
                xeleman = x[i - 1];
                barx = Convert.ToInt32(new string(xeleman, 1)); //char integer dönüşümü
                for (j = boyuty; j > 0; j--)
                {
                    yeleman = y[j - 1];
                    bary = Convert.ToInt32(new string(yeleman, 1));
                    //aynı basamakta olduğumuzun kontrolü
                    CikarmaKuralları();
                }
                //dış for
            }
        }
        void toplamaIslem()
        {
            for (i = boyutx; i > 0; i--)
            {
                xeleman = x[i - 1];
                barx = Convert.ToInt32(new string(xeleman, 1));//char verisini integera dönüştürdük
                for (j = boyuty; j > 0; j--)
                {
                    yeleman = y[j - 1];
                    bary = Convert.ToInt32(new string(yeleman, 1));
                    //sayı boyutları eşit ise
                    if (i == j)
                    {   //elde kontrol
                        if (bary + barx <= 9)
                        {
                            if (eldekontrol == true)
                            {
                                if (bary + barx == 9)
                                {
                                    results.Add(0);
                                    eldekontrol = true;
                                }
                                else
                                {
                                    sonuc = bary + barx;
                                    eldelisonuc = sonuc + 1;
                                    results.Add(eldelisonuc);
                                    eldekontrol = false;
                                }
                            }
                            else
                            {
                                sonuc = bary + barx;
                                results.Add(sonuc);
                                eldekontrol = false;
                            }
                        }
                        //basamak eldeli olursa
                        else
                        {
                            elde = (bary + barx) / 10;
                            sonuc = (bary + barx) % 10;
                            sayi = bary + barx;
                            //İlk Basamak
                            if (j == boyuty)
                            {
                                results.Add(sonuc);
                                eldekontrol = true;
                            }
                            //Son Basamak
                            else if (j == 1)
                            {
                                if (eldekontrol == true)
                                {
                                    eldelisonuc = sayi + 1;
                                    results.Add(eldelisonuc);
                                }
                                else
                                {
                                    results.Add(sayi);
                                    eldekontrol = true;
                                }
                            }
                            //diğer basamaklar
                            else
                            {
                                if (eldekontrol == true)
                                {
                                    eldelisonuc = sonuc + 1;
                                    results.Add(eldelisonuc);
                                    eldekontrol = true;
                                }
                                else
                                {
                                    results.Add(sonuc);
                                    eldekontrol = true;
                                }
                            }
                        }
                    }

                }
                //dış döngü 
            }
        }
        void toplama()
        {
            x = sayi1;
            y = sayi2;
            boyutx = x.Length; // sayıların uzunluklarını boyutx ve boyuty değiş
            boyuty = y.Length;
            if (boyutx == boyuty)//sayı boyutlarını kontrol ettik
            {
                toplamaIslem();
            }
            //sayı boyutları eşit değilse
            else
            {   //basamak farkı kontrolu
                if (boyutx > boyuty)
                {
                    kacsifir = boyutx - boyuty;
                    for (int i = 0; i < kacsifir; i++)
                    {
                        y = "0" + y;
                    }
                }
                else
                {
                    kacsifir = boyuty - boyutx;
                    for (int i = 0; i < kacsifir; i++)
                    {
                        x = "0" + x;
                    }
                }
                boyutx = x.Length;
                boyuty = y.Length;
                toplamaIslem();
            }
            for (i = results.Count - 1; i >= 0; i--)
            {
                Console.Write(results[i]);
            }
        }
        void cikarma()
        {
            x = sayi1;
            y = sayi2;
            boyutx = x.Length;
            boyuty = y.Length;
            //sayı boyutu kontrolü
            if (boyutx == boyuty)
            {
                cikarmaIslemi();
            }
            //sayı boyutu farklı ise
            else
            {   //basamak farkı kontrolu
                if (boyutx > boyuty)
                {
                    kacsifir = boyutx - boyuty;
                    for (int i = 0; i < kacsifir; i++)
                    {
                        y = "0" + y;
                    }
                }
                else
                {
                    kacsifir = boyuty - boyutx;
                    for (int i = 0; i < kacsifir; i++)
                    {
                        x = "0" + x;
                    }
                }
                boyutx = x.Length;
                boyuty = y.Length;
                cikarmaIslemi();
            }
            if(yanliscikarma==false)
            {
                for (i = results.Count - 1; i >= 0; i--)
                {
                    Console.Write(results[i]);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("1. sayı 2. sayıdan küçük olamaz");
            }
        }
        static string Carpma(string sayi1, string sayi2)
        {
            int n = sayi1.Length;
            int m = sayi2.Length;
            int[] sonuc = new int[n + m];

            // Her basamak için çarpma işlemi
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    int carpim = (sayi1[i] - '0') * (sayi2[j] - '0');

                    int toplam = carpim + sonuc[i + j + 1];

                    sonuc[i + j + 1] = toplam % 10;
                    sonuc[i + j] += toplam / 10;
                }
            }

            // Sonucu birleştirme
            string carpimStr = "";
            foreach (int num in sonuc)
            {
                if (!(carpimStr.Length == 0 && num == 0))
                {
                    carpimStr += num;
                }
            }
            Console.WriteLine(carpimStr);
            return carpimStr.Length == 0 ? "0" : carpimStr;
        }
        static string bolme(string sayi1, string sayi2)
        {
            
            BigInteger dividendValue = BigInteger.Parse(sayi1);
            BigInteger divisorValue = BigInteger.Parse(sayi2);
            string quotient = "";
            string remainder = "";
            // Bölme işlemi için algoritmayı uygula
            foreach (char digit in sayi1)
            {
                remainder += digit;
                if (BigInteger.Parse(remainder) >= divisorValue)
                {
                    BigInteger result = BigInteger.Parse(remainder) / divisorValue;
                    quotient += result.ToString();
                    // Kalanı güncelle
                    remainder = (BigInteger.Parse(remainder) % divisorValue).ToString();
                }
                // Bölme işlemi yapılamıyorsa sıfır ekleyerek devam et
                else
                {
                    quotient += "0";
                }
            }
            //0ları silmek için
            for (int i = 0; i < quotient.Length;)
            {
                if (quotient[i] == '0')
                {
                    quotient = quotient.Remove(i, 1);
                }
                else
                {
                    break; 
                }
            }
            Console.WriteLine(quotient);
            return quotient;
        }
        Console.WriteLine("yapmak istediğiniz işlemi seçiniz");
        Console.WriteLine("toplama için +");
        Console.WriteLine("çıkarma için -");
        Console.WriteLine("çarpma için *");
        Console.WriteLine("bölme için /");
        islem = Console.ReadLine();
        Console.WriteLine("1. sayıyı giriniz \n");
        sayi1 = Console.ReadLine();
        Console.WriteLine("2. sayıyı giriniz \n");
        sayi2 = Console.ReadLine();
        switch (islem)
        {
            case "+":
                toplama();
                break;
            case "-":
                cikarma();
                break;
            case "*":
                Console.WriteLine("carpmaya girdi");
                string carpim = Carpma(sayi1, sayi2);
                break;
            case "/":
                bolme(sayi1,sayi2);
                break;
        }
    }
}