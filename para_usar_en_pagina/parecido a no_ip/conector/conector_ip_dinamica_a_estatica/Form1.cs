using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conector_ip_dinamica_a_estatica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_mandar_ip_Click(object sender, EventArgs e)
        {
            await HacerSolicitud();

        }


        public static async Task HacerSolicitud()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://www.tudominio.com/dameip.php?user=user&pass=1234";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Solicitud exitosa: " + DateTime.Now);
                    }
                    else
                    {
                        MessageBox.Show("Error en la solicitud: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }



    }
}
