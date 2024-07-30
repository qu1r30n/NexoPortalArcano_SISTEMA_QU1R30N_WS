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

        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;

        public void conmutar_datos(IWebDriver manejadores, WebDriverWait esperar, string parametro)
        {
            string[] res_espliteada = parametro.Split(G_caracter_separacion_funciones_espesificas[1][0]);

            // Implementa la lógica aquí


            //procesos_usaras------------------------------------------------------------


            if (res_espliteada[0] == "pregunta_ws")
            {
                preguntas_ws(manejadores, esperar, res_espliteada[1]);
            }
            else if (res_espliteada[0] == "ws")
            {
                mandar_ws(manejadores, esperar, res_espliteada[1]);
            }
            
            else
            {

            }


        }

        public void preguntas_ws(IWebDriver manejadores, WebDriverWait esperar, string info_a_procesar)
        {
            string[] inf_esp = info_a_procesar.Split(G_caracter_separacion_funciones_espesificas[1][0]);

        }

        public void mandar_ws(IWebDriver manejadores, WebDriverWait esperar, string info_a_procesar)
        {
            chatbot_clase ch_b = new chatbot_clase();
            string[] inf_esp = info_a_procesar.Split(G_caracter_separacion_funciones_espesificas[1][0]);
            ch_b.regresr_respuesta_ia(manejadores, esperar, inf_esp[0], inf_esp[1]);
        }

    }
}
