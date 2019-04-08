using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SehirOyunuv1._00
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] sehirler = { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Artvin", "Ardahan", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkâri", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Şanlıurfa", "Şırnak", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };
        ArrayList sehirler2 = new ArrayList();
        string[] veriler = { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Artvin", "Ardahan", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkâri", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Şanlıurfa", "Şırnak", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };
        bool gOyun = false;
        int indexler = 0;
        int rastgelesayi = 0;
        ArrayveArrayListDonusturucu donusturucu = new ArrayveArrayListDonusturucu();
        int gSaniye = 20;
        int gPuan = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            sehirler2 = donusturucu.ArrayiArrayListeDonustur(sehirler);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Başlat")
            {
                gPuan = 0;
                label4.Text = "Puan: 0";
                label2.Text = "";
                gSaniye = 20;
                timer1.Enabled = true;
                gOyun = true;
                button1.Text = "Onayla";
                Random rastgele = new Random();
                rastgelesayi = rastgele.Next(0, sehirler.Length - 1);
                label1.Text = sehirler[rastgelesayi];
                textBox1.Text = sehirler[rastgelesayi].Substring(sehirler[rastgelesayi].Length - 1).ToUpper();
                sehirler2.RemoveAt(rastgelesayi);
                string sonharf = (sehirler[rastgelesayi].Substring(sehirler[rastgelesayi].Length - 1).ToUpper());
                int cikan = 0;
                foreach (string kontrol in sehirler2)
                {
                    if (sonharf == kontrol.Substring(0, 1))
                    {
                        cikan++;
                    }
                }

                if (cikan == 0)
                {
                    timer1.Enabled = false;
                    gSaniye = 20;
                    button1.Text = "Başlat";
                    gOyun = false;
                    label1.Text = "Şehir";
                    textBox1.Text = "";
                    sehirler2.Clear();
                    sehirler2 = donusturucu.ArrayiArrayListeDonustur(sehirler);
                    label2.Text = "Çok şansızsınız ne yazık ki. \"" + sehirler[rastgelesayi].Substring(sehirler[rastgelesayi].Length - 1).ToUpper() + "\" harfi ile başlayan şehir bulunmamaktadır.";
                }
                else
                {
                    label2.Text = "Oyun başlatıldı. \"" + sehirler[rastgelesayi].Substring(sehirler[rastgelesayi].Length - 1).ToUpper() + "\" harfi ile başlayan bir şehir bulun. Başarılar...";
                }
            }
            else if (button1.Text == "Onayla")
            {
                gSaniye = 20;
                timer1.Enabled = true;
                string ilkgirilen = textBox1.Text.Substring(0, 1).ToUpper();
                string girilen = ilkgirilen + textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                indexler = sehirler2.IndexOf(girilen);
                int eklenen = 0;
                if (indexler != -1)
                {
                    if (int.Parse(label3.Text) > 0 && int.Parse(label3.Text) <= 2)
                    {
                        gPuan += 1;
                        eklenen = 1;
                        label4.Text = "Puan: " + gPuan.ToString();
                    }
                    else if (int.Parse(label3.Text) > 2 && int.Parse(label3.Text) <= 4)
                    {
                        gPuan += 2;
                        eklenen = 2;
                        label4.Text = "Puan: " + gPuan.ToString();
                    }
                    else if (int.Parse(label3.Text) > 4 && int.Parse(label3.Text) <= 6)
                    {
                        gPuan += 4;
                        eklenen = 4;
                        label4.Text = "Puan: " + gPuan.ToString();
                    }
                    else if (int.Parse(label3.Text) > 6 && int.Parse(label3.Text) <= 8)
                    {
                        gPuan += 5;
                        eklenen = 5;
                        label4.Text = "Puan: " + gPuan.ToString();
                    }
                    else if (int.Parse(label3.Text) > 8 && int.Parse(label3.Text) <= 10)
                    {
                        gPuan += 7;
                        eklenen = 7;
                        label4.Text = "Puan: " + gPuan.ToString();
                    }
                    else if (int.Parse(label3.Text) > 10 && int.Parse(label3.Text) <= 12)
                    {
                        gPuan += 9;
                        eklenen = 9;
                        label4.Text = "Puan: " + gPuan.ToString();
                    }
                    else if (int.Parse(label3.Text) > 12 && int.Parse(label3.Text) <= 14)
                    {
                        gPuan += 11;
                        eklenen = 11;
                        label4.Text = "Puan: " + gPuan.ToString();
                    }
                    else if (int.Parse(label3.Text) > 14 && int.Parse(label3.Text) <= 16)
                    {
                        gPuan += 13;
                        eklenen = 13;
                        label4.Text = "Puan: " + gPuan.ToString();
                    }
                    else if (int.Parse(label3.Text) > 16 && int.Parse(label3.Text) <= 18)
                    {
                        gPuan += 15;
                        eklenen = 15;
                        label4.Text = "Puan: " + gPuan.ToString();
                    }
                    else if (int.Parse(label3.Text) > 18 && int.Parse(label3.Text) <= 20)
                    {
                        gPuan += 40;
                        eklenen = 40;
                        label4.Text = "Puan: " + gPuan.ToString();
                    }


                    string sonharf = girilen.Substring(textBox1.Text.Length - 1).ToUpper();
                    label1.Text = girilen;
                    textBox1.Text = sonharf;
                    sehirler2.Remove(girilen);
                    label2.Text = "\"" + girilen + "\" cevabınız doğrudur! \"" + eklenen + "\" puan eklendi.";
                    int cikan = 0;
                    foreach (string kontrol in sehirler2)
                    {
                        if (sonharf == kontrol.Substring(0, 1).ToUpper())
                        {
                            cikan++;
                        }
                    }
                    
                    if (cikan == 0)
                    {
                        timer1.Enabled = false;
                        gSaniye = 20;
                        button1.Text = "Başlat";
                        gOyun = false;
                        label1.Text = "Şehir";
                        textBox1.Text = "";
                        sehirler2.Clear();
                        sehirler2 = donusturucu.ArrayiArrayListeDonustur(sehirler);
                        label2.Text = "\"" + sonharf + "\" baş harfle başlayan şehir bulunmadığından oyun bitmiştir.";
                    }
                }
                else
                {
                    timer1.Enabled = false;
                    gSaniye = 20;
                    label3.Text = "20";
                    button1.Text = "Başlat";
                    gOyun = false;
                    label1.Text = "Şehir";
                    textBox1.Text = "";
                    sehirler2.Clear();
                    sehirler2 = donusturucu.ArrayiArrayListeDonustur(sehirler);
                    if (Array.IndexOf(veriler, girilen) != -1)
                    {
                        label2.Text = "\"" + girilen + "\" şehrini önceden girdiniz! \"8\" puanının silinmiştir. Oyun bitti.";
                        gPuan -= 8;
                        label4.Text = "Puan: " + gPuan.ToString();
                    }
                    else
                    {
                        label2.Text = "\"" + girilen + "\" cevabınız yanlıştır! \"5\" puanınız silinmiştir. Oyun bitti.";
                        gPuan -= 5;
                        label4.Text = "Puan: " + gPuan.ToString();
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gSaniye == 0)
            {
                label2.Text = "Süreniz doldu. Oyun bitti! Süreyi \"" + gPuan + "\" puanda bitirdiniz.";
                button1.Text = "Başlat";
                gOyun = false;
                label1.Text = "Şehir";
                textBox1.Text = "";
                timer1.Enabled = false;
                gSaniye = 20;
                label3.Text = "20";
            }
            else
            {
                gSaniye--;
                label3.Text = gSaniye.ToString();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (button1.Text == "Başlat")
                {
                    label2.Text = "";
                    gSaniye = 20;
                    timer1.Enabled = true;
                    gOyun = true;
                    button1.Text = "Onayla";
                    Random rastgele = new Random();
                    rastgelesayi = rastgele.Next(0, sehirler.Length - 1);
                    label1.Text = sehirler[rastgelesayi];
                    textBox1.Text = sehirler[rastgelesayi].Substring(sehirler[rastgelesayi].Length - 1).ToUpper();
                    sehirler2.RemoveAt(rastgelesayi);
                    string sonharf = (sehirler[rastgelesayi].Substring(sehirler[rastgelesayi].Length - 1).ToUpper());
                    int cikan = 0;
                    foreach (string kontrol in sehirler2)
                    {
                        if (sonharf == kontrol.Substring(0, 1))
                        {
                            cikan++;
                        }
                    }

                    if (cikan == 0)
                    {
                        timer1.Enabled = false;
                        gSaniye = 20;
                        button1.Text = "Başlat";
                        gOyun = false;
                        label1.Text = "Şehir";
                        textBox1.Text = "";
                        sehirler2.Clear();
                        sehirler2 = donusturucu.ArrayiArrayListeDonustur(sehirler);
                        label2.Text = "Çok şansızsınız ne yazık ki. \"" + sehirler[rastgelesayi].Substring(sehirler[rastgelesayi].Length - 1).ToUpper() + "\" harfi ile başlayan şehir bulunmamaktadır.";
                    }
                    else
                    {
                        label2.Text = "Oyun başlatıldı. \"" + sehirler[rastgelesayi].Substring(sehirler[rastgelesayi].Length - 1).ToUpper() + "\" harfi ile başlayan bir şehir bulun. Başarılar...";
                    }
                }
                else if (button1.Text == "Onayla")
                {
                    gSaniye = 20;
                    timer1.Enabled = true;
                    string ilkgirilen = textBox1.Text.Substring(0, 1).ToUpper();
                    string girilen = ilkgirilen + textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                    indexler = sehirler2.IndexOf(girilen);
                    int eklenen = 0;
                    if (indexler != -1)
                    {
                        if (int.Parse(label3.Text) > 0 && int.Parse(label3.Text) <= 2)
                        {
                            gPuan += 1;
                            eklenen = 1;
                            label4.Text = "Puan: " + gPuan.ToString();
                        }
                        else if (int.Parse(label3.Text) > 2 && int.Parse(label3.Text) <= 4)
                        {
                            gPuan += 2;
                            eklenen = 2;
                            label4.Text = "Puan: " + gPuan.ToString();
                        }
                        else if (int.Parse(label3.Text) > 4 && int.Parse(label3.Text) <= 6)
                        {
                            gPuan += 4;
                            eklenen = 4;
                            label4.Text = "Puan: " + gPuan.ToString();
                        }
                        else if (int.Parse(label3.Text) > 6 && int.Parse(label3.Text) <= 8)
                        {
                            gPuan += 5;
                            eklenen = 5;
                            label4.Text = "Puan: " + gPuan.ToString();
                        }
                        else if (int.Parse(label3.Text) > 8 && int.Parse(label3.Text) <= 10)
                        {
                            gPuan += 7;
                            eklenen = 7;
                            label4.Text = "Puan: " + gPuan.ToString();
                        }
                        else if (int.Parse(label3.Text) > 10 && int.Parse(label3.Text) <= 12)
                        {
                            gPuan += 9;
                            eklenen = 9;
                            label4.Text = "Puan: " + gPuan.ToString();
                        }
                        else if (int.Parse(label3.Text) > 12 && int.Parse(label3.Text) <= 14)
                        {
                            gPuan += 11;
                            eklenen = 11;
                            label4.Text = "Puan: " + gPuan.ToString();
                        }
                        else if (int.Parse(label3.Text) > 14 && int.Parse(label3.Text) <= 16)
                        {
                            gPuan += 13;
                            eklenen = 13;
                            label4.Text = "Puan: " + gPuan.ToString();
                        }
                        else if (int.Parse(label3.Text) > 16 && int.Parse(label3.Text) <= 18)
                        {
                            gPuan += 15;
                            eklenen = 15;
                            label4.Text = "Puan: " + gPuan.ToString();
                        }
                        else if (int.Parse(label3.Text) > 18 && int.Parse(label3.Text) <= 20)
                        {
                            gPuan += 40;
                            eklenen = 40;
                            label4.Text = "Puan: " + gPuan.ToString();
                        }


                        string sonharf = girilen.Substring(textBox1.Text.Length - 1).ToUpper();
                        label1.Text = girilen;
                        textBox1.Text = sonharf;
                        sehirler2.Remove(girilen);
                        label2.Text = "\"" + girilen + "\" cevabınız doğrudur! \"" + eklenen + "\" puan eklendi.";
                        int cikan = 0;
                        foreach (string kontrol in sehirler2)
                        {
                            if (sonharf == kontrol.Substring(0, 1).ToUpper())
                            {
                                cikan++;
                            }
                        }

                        if (cikan == 0)
                        {
                            timer1.Enabled = false;
                            gSaniye = 20;
                            button1.Text = "Başlat";
                            gOyun = false;
                            label1.Text = "Şehir";
                            textBox1.Text = "";
                            sehirler2.Clear();
                            sehirler2 = donusturucu.ArrayiArrayListeDonustur(sehirler);
                            label2.Text = "\"" + sonharf + "\" baş harfle başlayan şehir bulunmadığından oyun bitmiştir.";
                        }
                    }
                    else
                    {
                        timer1.Enabled = false;
                        gSaniye = 20;
                        label3.Text = "20";
                        button1.Text = "Başlat";
                        gOyun = false;
                        label1.Text = "Şehir";
                        textBox1.Text = "";
                        sehirler2.Clear();
                        sehirler2 = donusturucu.ArrayiArrayListeDonustur(sehirler);
                        if (Array.IndexOf(veriler, girilen) != -1)
                        {
                            label2.Text = "\"" + girilen + "\" şehrini önceden girdiniz! \"8\" puanının silinmiştir. Oyun bitti.";
                            gPuan -= 8;
                            label4.Text = "Puan: " + gPuan.ToString();
                        }
                        else
                        {
                            label2.Text = "\"" + girilen + "\" cevabınız yanlıştır! \"5\" puanınız silinmiştir. Oyun bitti.";
                            gPuan -= 5;
                            label4.Text = "Puan: " + gPuan.ToString();
                        }
                    }
                }
            }
        }
    }
}
