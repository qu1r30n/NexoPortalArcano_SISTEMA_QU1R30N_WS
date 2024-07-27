using NexoPortalArcano_SISTEMA_QU1R30N_WS.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexoPortalArcano_SISTEMA_QU1R30N_WS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            poner_al_inicio_del_programa ini = new poner_al_inicio_del_programa();
            ini.inicio();
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            chatbot_clase ch_bot = new chatbot_clase();
            ch_bot.configuracion_de_inicio();
        }
    }
}
