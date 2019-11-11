using System;

namespace Composit
{
    // Summary:
    // Összetett objektumok ábrázolása fa-szerkezettel.
    // Egyedi összetevők és összetett összetevők összerakása és egységes módon való kezelése.
    class Program
    {
        static void Main(string[] args)
        {
            // 1. TODO: Computer and its parts

            #region 2. Részvények és részvénycsomagok

            IShares erste = new Shares("Erste Biztos Befektetés részvénycsomag");

            // Shares
            IShare otp = new Share("OTP", 10_000);
            IShare mol = new Share("MOL", 5_500);
            IShare richter = new Share("Richter", 9_000);

            IShare mvm = new Share("MVM", 12_000);
            IShare ge = new Share("GE", 11_000);
            IShares city = new Shares("City Bank Befektetési Alapok részvénycsomag");

            // Compose
            city.Add(mvm);
            city.Add(ge);

            erste.Add(otp);
            erste.Add(mol);
            erste.Add(city);
            erste.Add(richter);

            Console.WriteLine(erste);
            Console.WriteLine();

            #endregion

            #region 3. Ház és építőelemei, autó vagy bármilyen gép és alkatrészei
                        
            ICompositItem lámpatest = new CompositItem("lámpatest");
            lámpatest.Add(new Item("burkolat", 1000, 150, DateTime.Now.AddYears(10)));
            lámpatest.Add(new Item("kapcsoló", 100, 10, DateTime.Now.AddYears(10)));

            ICompositItem vezeték = new CompositItem("vezeték");
            vezeték.Add(new Item("burkolat", 10, 5, DateTime.Now.AddYears(20)));
            vezeték.Add(new Item("rézdrót", 55, 125, DateTime.Now.AddYears(100)));

            ICompositItem villanykörte = new CompositItem("villanykörte");
            villanykörte.Add(new Item("foglalat", 20, 40, DateTime.Now.AddYears(5)));
            villanykörte.Add(new Item("üvegbúra", 220, 140, DateTime.Now.AddYears(3)));
            villanykörte.Add(new Item("izzó", 190, 2, DateTime.Now.AddYears(2)));

            ICompositItem lámpa = new CompositItem("lámpa");
            lámpa.Add(lámpatest);
            lámpa.Add(vezeték);
            lámpa.Add(villanykörte);


            Console.WriteLine(lámpa);

            #endregion
        }
    }
}

