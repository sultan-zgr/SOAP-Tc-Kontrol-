using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcKontrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            long kimlikNo = Convert.ToInt64(txtTc.Text);
            int yil = Convert.ToInt32(txtYıl.Text);
            bool durum;

            try
            {
                using (TcDogrula.KPSPublicSoapClient service = new TcDogrula.KPSPublicSoapClient { })
                {
                    durum = service.TCKimlikNoDogrula(kimlikNo, txtAd.Text, txtSoyad.Text, yil);
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (durum == true)
            {
                MessageBox.Show("Kayıt bulundu.");
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı");
            }
        }
    }
}
