using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SehirOyunuv1._00
{
    class ArrayveArrayListDonusturucu
    {
        public ArrayList ArrayiArrayListeDonustur(string[] veriler)
        {
            ArrayList donus = new ArrayList();
            for (int i = 0; i < veriler.Length; i++)
            {
                donus.Add(veriler[i]);
            }
            return donus;
        }

        public string[] ArrayListiArrayaDonustur(ArrayList veriler)
        {
            string[] donus = new string[veriler.Count];
            int sayi = 0;
            foreach (string veri in veriler)
            {
                donus[sayi] = veri;
                sayi++;
            }
            return donus;
        }
    }
}
