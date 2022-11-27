using Okul_Projesi;

namespace Kutuphane_projesi
{
    public partial class Frm2_Giris : Form
    {
        Thread th;
        public Frm2_Giris()
        {
            InitializeComponent();
        }
        private void OpenNewForm()
        {
            Application.Run(new Frm2_Ogrenci_girisi());
        }
        private void OpenNewForm2()
        {
            Application.Run(new Frm2_Ogretmen_girisi());
        }
        private void OpenNewForm3()
        {
            Application.Run(new Frm2_Sekreter_girisi());
        }

        private void btnOgrenci_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();

        }

        private void btnOgretmen_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();

        }

        private void btnSekreter_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();

        }
    }
}