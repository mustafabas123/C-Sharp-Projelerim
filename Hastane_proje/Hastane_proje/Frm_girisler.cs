namespace Hastane_proje
{
    public partial class Frm_girisler : Form
    {
        Thread th;
        public Frm_girisler()
        {
            InitializeComponent();
        }

        private void BtnHasta_Click(object sender, EventArgs e)
        {
         
            th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
            
        }
        private void OpenNewForm()
        {
            Application.Run(new Frm_Hasta_giris());
        }
        private void OpenNewForm2()
        {
            Application.Run(new Frm_giris_doktor());

        }
        private void OpenNewForm3()
        {
            Application.Run(new Frm_sekreter_giris());

        }

        private void BtnDoktor_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();

        }

        private void BtnSekreter_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();


        }
    }
}