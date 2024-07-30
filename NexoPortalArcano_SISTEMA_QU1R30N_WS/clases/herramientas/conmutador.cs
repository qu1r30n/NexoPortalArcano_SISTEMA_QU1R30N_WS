using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexoPortalArcano_SISTEMA_QU1R30N_WS.clases.herramientas
{
    internal class conmutador
    {

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;


        Tex_base bas = new Tex_base();

        string[] G_direcciones =
        {
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[18, 0],//inventairo,
        };

        public void conmutar_datos(IWebDriver manejadores, WebDriverWait esperar, string parametro)
        {
            string[] res_espliteada = parametro.Split(G_caracter_para_transferencia_entre_archivos[0][0]);

            // Implementa la lógica aquí


            //procesos_usaras------------------------------------------------------------


            if (res_espliteada[0] == "PREGUNTAS_WS")
            {
                preguntas_ws(manejadores, esperar, res_espliteada[1]);
            }
            else if (res_espliteada[0] == "WS")
            {
                mandar_ws(manejadores, esperar, res_espliteada[2], res_espliteada[1]);
            }
            
            else
            {

            }


        }

        public void preguntas_ws(IWebDriver manejadores, WebDriverWait esperar, string info_a_procesar)
        {
            string[] inf_esp = info_a_procesar.Split(G_caracter_para_transferencia_entre_archivos[0][0]);
            int indice=Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_direcciones[0]));
            Tex_base.GG_base_arreglo_de_arreglos[indice] = inf_esp;
        }

        public void mandar_ws(IWebDriver manejadores, WebDriverWait esperar,string contacto, string info_a_procesar)
        {
            chatbot_clase ch_b = new chatbot_clase();
            string[] inf_esp = info_a_procesar.Split(var_fun_GG.GG_caracter_para_confirmacion_o_error[0][0]);
            string a = "";
            if (inf_esp[0] == "1")
            {
                ch_b.regresr_respuesta_ia(manejadores, esperar, contacto, "compra exitosa");
            }
            else
            {
                ch_b.regresr_respuesta_ia(manejadores, esperar, contacto, "error");
            }
        }

    }
}
