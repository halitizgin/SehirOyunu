using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Şehir Oyunu v1.1\nhttp://sanaldosya.org\nGeliştiren: Ready\nDağıtımı ve kullanımı tamamen ücretsizdir.\nGeliştirilmeye açık bir oyundur.\nGeliştirilmeye devam edilecektir.", "Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Oyunun Oynanışı:\n\nOyuna başladığınızda rastgele bir şehir gelecektir. Bunun son harfiyle başlayan bir şehir yazıp Onayla düğmesine tıkladığınızda saniyeye de bakarak size puan verilecektir.\nBir kere onayladığınız şehiri bir daha onaylamaya çalıştığınızda veya yanlış bir şehir söylediğinizde oyun biter.(Puan kesilir; yanlış şehir için 5, onaylanmış bir şehir için 8)\nOyun; dikkat, hafıza ve ülkemizdeki şehirleri bilmemizi gerektiren bir oyundur.\nOyunda 81 ilin tamamı bulunmaktadır.\nPuanlama Sistemi:\n\n0 ile 2 arasındaki saniyelerde cevap verdiğinizde 1 puan\n2 ile 4 arasındaki saniyelerde cevap verdiğinizde 2 puan\n4 ile 6 arasındaki saniyelerde cevap verdiğinizde 4 puan\n6 ile 8 arasındaki saniyelerde cevap verdiğinizde 5 puan\n8 ile 10 arasındaki saniyelerde cevap verdiğinizde 7 puan\n10 ile 12 arasındaki saniyelerde cevap verdiğinizde 11 puan\n14 ile 16 arasındaki saniyelerde cevap verdiğiniz zaman 13 puan\n16 ile 18 arasındaki saniyelerde cevap verdiğiniz zaman 15 puan\n18 ile 20 arasındaki saniyelerde cevap verdiğiniz zaman 40 puan eklenir.\n\nYanlış cevap verdiğinizde 5 puan çıkartılır ve oyun biter.\nOnaylanmış şehir girdiğinizde 8 puan çıkartılır ve oyun biter.");
        }
    }
}
