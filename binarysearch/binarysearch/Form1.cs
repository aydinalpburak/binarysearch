using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace binarysearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int aranan;
        int eb = 15;
        int ek = -1;
        int kontrol = 0;
        string metin = "Aranan sayının bulunduğu kutu =";
        PictureBox[] pictures = new PictureBox[15];//array oluşturularak konumları belirleniyor.
        TextBox[] textBoxes = new TextBox[15];
        private void load()//sistem açıldığında arrayler dolduruluyor
        {
            pictures[0] = pictureBox1;
            pictures[1] = pictureBox2;
            pictures[2] = pictureBox3;
            pictures[3] = pictureBox4;
            pictures[4] = pictureBox5;
            pictures[5] = pictureBox6;
            pictures[6] = pictureBox7;
            pictures[7] = pictureBox8;
            pictures[8] = pictureBox9;
            pictures[9] = pictureBox10;
            pictures[10] = pictureBox11;
            pictures[11] = pictureBox12;
            pictures[12] = pictureBox13;
            pictures[13] = pictureBox14;
            pictures[14] = pictureBox15;
            //--------------------------            
            textBoxes[0] = textBox1;
            textBoxes[1] = textBox2;
            textBoxes[2] = textBox3;
            textBoxes[3] = textBox4;
            textBoxes[4] = textBox5;
            textBoxes[5] = textBox6;
            textBoxes[6] = textBox7;
            textBoxes[7] = textBox8;
            textBoxes[8] = textBox9;
            textBoxes[9] = textBox10;
            textBoxes[10] = textBox11;
            textBoxes[11] = textBox12;
            textBoxes[12] = textBox13;
            textBoxes[13] = textBox14;
            textBoxes[14] = textBox15;
        }
        private void alldisable()//tüm gifler devre dışı kalmakta
        {
            for (int i = 0; i < pictures.Length; i++)
            {
                pictures[i].Visible = false;
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            load();
            alldisable();

            Random random = new Random();//random ile sayılar alınıyor.

            ArrayList list = new ArrayList();
            for (int i = 0; i < 15; i++)
            {
                list.Add(random.Next(0, 1000));
            }
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                textBoxes[i].Text = list[i].ToString() ;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            alldisable();
         
        }
        private void Aranacaksayi_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar== Convert.ToChar(Keys.Enter))
            {
                aranan = Convert.ToInt32(aranacaksayi.Text);
                while (eb - ek > 1)                
                {
                    int bakılan = (eb + ek) / 2;
                    pictures[bakılan].Visible = Enabled;
                    
                        if (Convert.ToInt32(textBoxes[bakılan].Text) == aranan)
                        {

                            kontrol = 1;
                            MessageBox.Show("Bulundu");
                            metin += " " + (Convert.ToInt32(bakılan)+1);
                            label16.Text = metin;
                            aranacaksayi.Enabled = false;
                            break;
                            
                    }

                        else if (Convert.ToInt32(textBoxes[bakılan].Text) < aranan)
                        {
                            ek = bakılan;
                        }
                        else
                        {
                            eb = bakılan;
                        }
                    
                        if (kontrol == 0)
                        {
                            MessageBox.Show("ENTER BASINIZ");
                            alldisable();
                        }
                }
                if (kontrol == 0)
                {
                    MessageBox.Show("Bulunamadı");
                    aranacaksayi.Enabled = false;


                }

            }
        }
    }
}
