namespace Not_sistemi
{
    public partial class Giris3 : Form
    {
        Thread th;
        private void OpenNewForm()
        {
            Application.Run(new Frm3_ogrenci_giris());
        }
        private void OpenNewForm2()
        {
            Application.Run(new Frm3_ogretmen_giris());
        }
        public Giris3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();

        }
    }
}