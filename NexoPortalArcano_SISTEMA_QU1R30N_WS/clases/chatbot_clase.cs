
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;


using System.Collections.ObjectModel;
using System.Threading;
using System.Diagnostics.Contracts;
using NexoPortalArcano_SISTEMA_QU1R30N_WS.clases.herramientas;

namespace NexoPortalArcano_SISTEMA_QU1R30N_WS.clases
{
    internal class chatbot_clase
    {
        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();
        var_fun_GG var_GG = new var_fun_GG();
        Tex_base bas = new Tex_base();
        conmutador con = new conmutador();

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;
        string[] G_caracter_usadas_por_usuario = var_fun_GG.GG_caracter_usadas_por_usuario;



        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_dir_arch_conf_chatbot =
        {
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[1, 0],//"config\\chatbot\\info_para_comandos_chatbot\\00_paginaweb.txt",
            /*1*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[2, 0],//"config\\chatbot\\info_para_comandos_chatbot\\01_ya_entrado_en_la_mensajeria.txt",
            /*2*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[3, 0],//"config\\chatbot\\info_para_comandos_chatbot\\02_chequeo_no_leidos.txt",
            /*3*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[4, 0],//"config\\chatbot\\info_para_comandos_chatbot\\03_clickeo.txt",
            /*4*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[5, 0],//"config\\chatbot\\info_para_comandos_chatbot\\04_lectura_del_mensage.txt",
            /*5*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[6, 0],//"config\\chatbot\\info_para_comandos_chatbot\\05_reconocer_textbox_de_envio.txt",
            /*6*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[7, 0],//"config\\chatbot\\info_para_comandos_chatbot\\06_buscar_nombre.txt",
            /*7*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[8, 0],//"config\\chatbot\\info_para_comandos_chatbot\\07_nombre_del_clikeado.txt",

        };

        string[][] G_info_de_configuracion_chatbot = null;

        public string[] G_dir_arch_transferencia =
        {
            /*0*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\XEROX\\CONFIG\\INF\\BKLKFJC\\BANDERAS.TXT",
            /*1*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\XEROX\\CONFIG\\INF\\BKLKFJC\\1.TXT",//PREGUNTAS
            /*2*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\XEROX\\CONFIG\\INF\\BKLKFJC\\2.TXT",//RESPUESTAS
            
        };

        
        
        

        public void configuracion_de_inicio()
        {


            G_info_de_configuracion_chatbot = extraer_info_de_archivos_de_configuracion_chatbot(G_dir_arch_conf_chatbot);

            //<span class="l7jjieqr cfzgl7ar ei5e7seu h0viaqh7 tpmajp1w c0uhu3dl riy2oczp dsh4tgtl sy6s5v3r gz7w46tb lyutrhe2 qfejxiq4 fewfhwl7 ovhn1urg ap18qm3b ikwl5qvt j90th5db aumms1qt"
            //aria-label="No leídos">1</span>

            int tiempo_en_segunds_espera = 40;
            int tiempo_en_minutos = 5;


            //damos algunas opciones para iniciar el chomer
            var opciones = new ChromeOptions();
            opciones.AddArguments("--start-maximized");
            opciones.AddExcludedArgument("enable-automation");

            //declaramos el elemento manejadores
            var manejadores = new ChromeDriver(opciones);
            manejadores.Navigate().GoToUrl(G_info_de_configuracion_chatbot[0][1]);

            //declaramos un elemento esperarque nos ayude a evitar erroes de elementos no encontrados
            var esperar = new WebDriverWait(manejadores, TimeSpan.FromMinutes(tiempo_en_minutos));//segun 5 min es suficiente pero no hace  la espera
            //Thread.Sleep(tiempo_en_segunds_espera * 1000);//puse este yo para que se haga la espera

            //esperar.Until(manej => manej.FindElement(By.Id("side")));//este es un id que aparece despues de escanear el codigo

            esperar.Until(manej =>
            {
                //IWebElement elemento_app = manej.FindElement(By.Id("app"));
                bool ya_entro = false;
                IWebElement elementoSide = null;
                while (ya_entro == false)
                {
                    try
                    {
                        elementoSide = manej.FindElement(By.Id(G_info_de_configuracion_chatbot[1][1]));
                        ya_entro = true;
                    }
                    catch 
                    {

                    }
                    
                }
                return elementoSide;
            });

            procesos(manejadores, esperar);

        }

        public void procesos(IWebDriver manejadores, WebDriverWait esperar)
        {

            //estos son del no leido--------------------------------------------------------------------
            string elementos = G_info_de_configuracion_chatbot[2][1];
            string elementos_clase = elementos + G_info_de_configuracion_chatbot[3][1];
            //extaer inventario-----------------------------------------------------------------------------------------
            con.enviar("PRODUCTOS", "EXTRAER_INVENTARIO","PREGUNTAS_WS","");
            //------------------------------------------------------------------------------------------

            while (true)
            {
                try
                {

                    
                    //checa si estan los elementos  esto sustitulle al // esperar.Until(manej => manej.FindElement(By.XPath(elementos)));//busca el elemento del no leido
                    //porque siempre marcaba error
                    bool elementoEncontrado = false;
                    elementoEncontrado = esperar.Until(manej =>
                    {
                        
                        var cuantos_elementos = manej.FindElements(By.XPath(elementos));

                        if (cuantos_elementos.Count > 0)
                        {
                            
                            
                            //clickea
                            try
                            {
                                manejadores.FindElement(By.XPath(elementos_clase)).Click();//clickea el elemento del no leido
                                string[] textosDelMensaje = leer_mensages_recibidos_del_mensage_clickeado(manejadores, esperar);
                                string nom_del_click = nombre_del_clickeado(manejadores, esperar);

                                //bas.Editar_fila_espesifica_SIN_ARREGLO_GG(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "config\\chatbot\espondiendo_a_una_pregunta.txt", 1, "1");
                                modelo_para_mandar_mensage_archivo_ia(manejadores, esperar, nom_del_click, textosDelMensaje);




                            }
                            catch
                            {

                            }


                            Thread.Sleep(1000);

                            return true;
                        }
                        
                        else
                        {   

                            datos_a_procesar_y_borrar(manejadores, esperar);


                            Thread.Sleep(1000); // Puedes ajustar el tiempo de espera según tu escenario
                            return false;
                        }

                    });
                    //---------------------------------------------------------------------------------------------
                    //

                }
                catch (NoSuchElementException ex) { }

                catch (Exception ex) { }

                catch { }

            }

        }

        private void modelo_para_mandar_mensage_archivo_ia(IWebDriver manejadores, WebDriverWait esperar, string nombre_Del_que_envio_el_mensage, object texto_recibidos_arreglo_objeto)
        {
            
            string[] textos_recibidos_srting_arr = op_arr.convierte_objeto_a_arreglo(texto_recibidos_arreglo_objeto);
            string ultimo_mensaje = textos_recibidos_srting_arr[textos_recibidos_srting_arr.Length - 1].ToUpper();//ultimo mensaje lo pone en minusculas

            con.conmutar_datos(manejadores, esperar, "MENSAJE" + G_caracter_para_transferencia_entre_archivos[1][0] + ultimo_mensaje + G_caracter_para_transferencia_entre_archivos[1][0] + nombre_Del_que_envio_el_mensage);

            Actions action = new Actions(manejadores);
            action.SendKeys(Keys.Escape).Perform();


            
        }


        private string[] leer_mensages_recibidos_del_mensage_clickeado(IWebDriver manejadores, WebDriverWait esperar)
        {

            //estos son los de buscar el mensage que nos llego
            string elementos2 = G_info_de_configuracion_chatbot[4][1];

            ReadOnlyCollection<IWebElement> elementos_ = esperar.Until(manej3 => manej3.FindElements(By.XPath(elementos2)));

            string[] textosDelMensaje = new string[elementos_.Count];
            for (int i = 0; i < elementos_.Count; i++)
            {
                textosDelMensaje[i] = elementos_[i].Text;
            }
            return textosDelMensaje;
        }

        private string nombre_del_clickeado(IWebDriver manejadores, WebDriverWait esperar)
        {
            string nombre_a_devolver = esperar.Until(manej2 =>
            {
                try
                {
                    return manej2.FindElement(By.XPath(G_info_de_configuracion_chatbot[7][1])).Text;
                }
                catch
                {

                    return manej2.FindElement(By.XPath(G_info_de_configuracion_chatbot[7][2])).Text;

                }

            });



            return nombre_a_devolver;

        }



        private string[][] extraer_info_de_archivos_de_configuracion_chatbot(string[] direcciones)
        {

            string[][] info_a_retornar = null;
            for (int i = 0; i < direcciones.Length; i++)
            {
                int indice_configuracion_archivos_chatbot = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direcciones[i]));
                info_a_retornar = op_arr.agregar_arreglo_a_arreglo_de_arreglos(info_a_retornar, Tex_base.GG_base_arreglo_de_arreglos[indice_configuracion_archivos_chatbot]);
            }

            return info_a_retornar;
        }

        private void datos_a_procesar_y_borrar(IWebDriver manejadores, WebDriverWait esperar)
        {


            string[] usuarios_lectura = bas.Leer(G_dir_arch_transferencia[0]);

            if (usuarios_lectura[0] == var_fun_GG.GG_id_programa || usuarios_lectura[0] == "")
            {

                string[] respuestas_ia = bas.Leer(G_dir_arch_transferencia[2]);

                if (respuestas_ia.Length > 1)
                {


                    for (int i = G_donde_inicia_la_tabla; i < respuestas_ia.Length; i++)
                    {
                        string[] id_programa_comparar = respuestas_ia[i].Split(G_caracter_para_transferencia_entre_archivos[0][0]);
                        if (usuarios_lectura[0] == var_fun_GG.GG_id_programa || usuarios_lectura[0] == "")
                        {
                            con.conmutar_datos(manejadores, esperar, id_programa_comparar[1]);
                        }


                    }
                    bas.eliminar_fila_PARA_MULTIPLES_PROGRAMAS(G_dir_arch_transferencia[2], 0, var_fun_GG.GG_id_programa, G_caracter_para_transferencia_entre_archivos[0]);
                    //bas.cambiar_archivo_con_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_2[1]], new string[] { "sin_informacion" });
                }

                cambiar_id_programa_al_siguiente(usuarios_lectura);
            }


        }

        public void cambiar_id_programa_al_siguiente(string[] usuarios)
        {
            for (int i = G_donde_inicia_la_tabla; i < usuarios.Length; i++)
            {
                if (usuarios[i] == var_fun_GG.GG_id_programa)
                {

                }
            }
        }

        public void quitar_id_prog_del_archivo()
        {
            string[] vieja_info_arch = bas.Leer(G_dir_arch_transferencia[0]);
            bas.eliminar_fila_PARA_MULTIPLES_PROGRAMAS(G_dir_arch_transferencia[0], 0, var_fun_GG.GG_id_programa);
            string[] nueva_info_arch = bas.Leer(G_dir_arch_transferencia[0]);
            if (vieja_info_arch[0] == var_fun_GG.GG_id_programa)
            {
                bas.Agregar_a_archivo_sin_arreglo(G_dir_arch_transferencia[0], nueva_info_arch[0]);
            }
            
        }


        private int[] checar_numero_de_direccion_de_archivo_atras_actual_adelante(int posicion_bandera)
        {
            string[] banderas = bas.Leer(G_dir_arch_transferencia[0]);



            int numero_actual_posision = Convert.ToInt32(banderas[posicion_bandera]);
            int numero_adelante_posision = numero_actual_posision + 3;
            int numero_atras_posision = numero_actual_posision - 3;
            int[] arr_devolver = { -1, -1, -1 };


            if (G_dir_arch_transferencia.Length <= numero_adelante_posision)
            {
                if (numero_adelante_posision < 3)
                {
                    numero_adelante_posision = posicion_bandera;
                }
                else
                {
                    numero_adelante_posision = posicion_bandera;
                    while (numero_adelante_posision > 3)
                    {
                        numero_adelante_posision = numero_adelante_posision - 3;
                    }
                }
            }
            if (1 > numero_actual_posision - 3)
            {
                numero_atras_posision = (G_dir_arch_transferencia.Length - 4) + posicion_bandera;
            }
            arr_devolver[0] = numero_atras_posision;
            arr_devolver[1] = numero_actual_posision;
            arr_devolver[2] = numero_adelante_posision;




            return arr_devolver;

        }



        //fin de la clase-----------------------------------------------------------------------
    }
}
