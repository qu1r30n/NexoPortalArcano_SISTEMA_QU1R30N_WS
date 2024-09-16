using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;

using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.SqlServer.Server;


namespace NexoPortalArcano_SISTEMA_QU1R30N_WS.clases.herramientas
{
    internal class conmutador
    {

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;
        string[] G_caracter_usadas_por_usuario = var_fun_GG.GG_caracter_usadas_por_usuario;

        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();
        var_fun_GG vf_GG = new var_fun_GG();
        Tex_base bas = new Tex_base();



        string[,] G_contactos_lista_para_mandar_informacion =
        {
            /*0*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[9, 0],"encargados" },
            /*1*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[10, 0],"supervisores" },
            /*2*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[11, 0],"contadores" },
            /*3*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[12, 0],"vendedores" },
            /*4*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[13, 0],"repartidores" },
            /*5*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[14, 0],"reg_mensage" },
            /*6*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[16, 0],"tesoreros" },
            /*7*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[15, 0],"programador" },
            /*8*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[20, 0],"confirmadores" },
            /*9*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[21, 0],"administradores" },
            /*10*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[22, 0],"compradores" },

        };

        public string[] G_dir_arch_transferencia =
        {
            /*0*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\XEROX\\CONFIG\\INF\\BKLKFJC\\BANDERAS.TXT",
            /*1*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\XEROX\\CONFIG\\INF\\BKLKFJC\\1.TXT",//preguntas
            /*2*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\XEROX\\CONFIG\\INF\\BKLKFJC\\2.TXT",//respuestas
        };

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

        string[,] G_dir_arch_conf_extra =
        {
            /*0*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[17, 0],"MENSAJE DE BIENVENIDA" },
            /*1*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[19,0] ,"FOLIOS_A_PROCESAR" },//"config\\chatbot\egistros\\folios_a_checar\\folio_ventas.txt,"
        };



        string[] G_direcciones =
        {
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[18, 0],//inventairo,
        };

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        //procesos------------------------------------------------------------------
        public void conmutar_datos(IWebDriver manejadores, WebDriverWait esperar, string parametro)
        {
            string[] res_espliteada = parametro.Split(G_caracter_para_transferencia_entre_archivos[1][0]);

            // Implementa la lógica aquí


            //procesos_usaras------------------------------------------------------------


            if (res_espliteada[1] == "PREGUNTAS_WS")
            {
                preguntas_ws(manejadores, esperar, res_espliteada[2]);
            }

            else if (res_espliteada[1] == "WS")
            {
                mandar_ws(manejadores, esperar, res_espliteada[3], res_espliteada[2]);
            }

            else if (res_espliteada[1] == "WS_RS")
            {
                mandar_ws_rs(manejadores, esperar, res_espliteada[3], res_espliteada[2]);
            }


            else if (res_espliteada[1] == "MENSAJE")
            {
                mensajes(manejadores, esperar, res_espliteada[3], res_espliteada[2]);
            }


            else
            {

            }


        }

        private void preguntas_ws(IWebDriver manejadores, WebDriverWait esperar, string info_a_procesar)
        {
            string[] inf_esp = info_a_procesar.Split(G_caracter_separacion_funciones_espesificas[0][0]);
            int indice = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_direcciones[0]));
            Tex_base.GG_base_arreglo_de_arreglos[indice] = inf_esp;
        }

        private void mandar_ws(IWebDriver manejadores, WebDriverWait esperar, string contacto, string info_a_procesar)
        {
            chatbot_clase ch_b = new chatbot_clase();
            string[] inf_esp = info_a_procesar.Split(var_fun_GG.GG_caracter_para_confirmacion_o_error[0][0]);
            
            if (inf_esp[0] == "1")
            {
                regresr_respuesta_ia(manejadores, esperar, contacto, "compra exitosa");
            }
            else
            {
                regresr_respuesta_ia(manejadores, esperar, contacto, "error");
            }
        }

        private void mandar_ws_rs(IWebDriver manejadores, WebDriverWait esperar, string contacto, string info_a_procesar)
        {
            chatbot_clase ch_b = new chatbot_clase();
            string[] inf_esp = info_a_procesar.Split(var_fun_GG.GG_caracter_para_confirmacion_o_error[0][0]);
            
            if (inf_esp[0] == "1")
            {
                inf_esp[1] = inf_esp[1].Replace(G_caracter_separacion_funciones_espesificas[0], "\n");
                regresr_respuesta_ia(manejadores, esperar, contacto, inf_esp[1]);
            }
            else
            {
                regresr_respuesta_ia(manejadores, esperar, contacto, "error");
            }
        }

        private void mensajes(IWebDriver manejadores, WebDriverWait esperar, string contacto, string info_a_procesar)
        {
            info_a_procesar.Replace("\n", G_caracter_separacion_funciones_espesificas[0]);
            string[] pedidos = info_a_procesar.Split(G_caracter_separacion_funciones_espesificas[0][0]);


            string añomesdiahoraminseg = DateTime.Now.ToString("yyMMddHHmmss");
            string folio = generar_folio(añomesdiahoraminseg).ToUpper();


            string pedido_a_registrar = "";
            bool hubo_pedido = false;
            for (int i = 0; i < pedidos.Length; i++)
            {


                string contactos_a_enviar = "";
                bool[] grupos =
                {
                    false, //confirmador
                    false, //tesorero
                    false, //administrador
                    false, //comprador
                };
                //confirmador
                grupos[0] = funciones_extra_por_grupo(manejadores, esperar, contacto, G_contactos_lista_para_mandar_informacion[8, 1], pedidos[i], "CONFIRMADORES", "confirmar_mensaje_para_cliente");
                //tesorero

                grupos[1] = funciones_extra_por_grupo(manejadores, esperar, contacto, G_contactos_lista_para_mandar_informacion[6, 1], pedidos[i], "TESOREROS", "confirmar_comicion_para_vendedor");

                //administradores
                grupos[2] = funciones_extra_por_grupo(manejadores, esperar, contacto, G_contactos_lista_para_mandar_informacion[9, 1], pedidos[i], "ADMNINISTRADORES", "VENTAS_DEL_DIA");

                //compradores
                grupos[3] = funciones_extra_por_grupo(manejadores, esperar, contacto, G_contactos_lista_para_mandar_informacion[10, 1], pedidos[i], "COMPRAS", "PREDICCION_COMPRA");

                bool es_un_grupo_con_funcion = false;
                for (int j = 0; j < grupos.Length; j++)
                {
                    if (grupos[j] == true)
                    {
                        es_un_grupo_con_funcion = true;
                        break;
                    }
                }

                if (es_un_grupo_con_funcion == false)
                {

                    string[] ultimo_mensaje_espliteado = pedidos[i].Split(G_caracter_usadas_por_usuario[0][0]);



                    if (ultimo_mensaje_espliteado.Length > 1)
                    {

                        string cod_bar_o_funcion = ultimo_mensaje_espliteado[0];
                        if (cod_bar_o_funcion != "UBI" && cod_bar_o_funcion != "EXT" && cod_bar_o_funcion != "CAN")
                        {

                            Double cantidad_de_platillos = Convert.ToDouble(ultimo_mensaje_espliteado[1]);
                            string id_producto = "";
                            //tiene id_producto para busqueda rapida en el inventario
                            if (ultimo_mensaje_espliteado.Length > 2) { id_producto = ultimo_mensaje_espliteado[2]; }

                            string[] res = buscar(G_direcciones[0], cod_bar_o_funcion, id_producto).Split(G_caracter_para_confirmacion_o_error[0][0]);
                            if (res[0] == "1")
                            {
                                string[] produc_esp = res[1].Split(G_caracter_separacion[0][0]);

                                pedido_a_registrar = op_tex.concatenacion_caracter_separacion(pedido_a_registrar, cod_bar_o_funcion + G_caracter_usadas_por_usuario[0] + cantidad_de_platillos + G_caracter_usadas_por_usuario[0] + res[2] + G_caracter_usadas_por_usuario[0] + produc_esp[1] + " " + produc_esp[2] + "" + produc_esp[3], G_caracter_separacion[1]);
                                hubo_pedido = true;

                            }

                        }
                        else
                        {
                            pedido_a_registrar = op_tex.concatenacion_caracter_separacion(pedido_a_registrar, pedidos[i], G_caracter_separacion[1]);
                            hubo_pedido = true;
                        }
                        
                    }

                    else
                    {

                        int indice = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_conf_extra[0, 0]));

                        string mensage_bienvenida = op_tex.joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(Tex_base.GG_base_arreglo_de_arreglos[indice], Keys.Shift + Keys.Enter + Keys.Shift+"", 1, true);
                        acumulador_de_mensajes(contacto, mensage_bienvenida);

                    }



                }


            }


            if (hubo_pedido)
            {
                string registro = registros_y_movimientos_a_confirmar(contacto, añomesdiahoraminseg, folio, pedido_a_registrar);
                string info_mandar = pedido_a_registrar.Replace(G_caracter_separacion[1], "\n");
                info_mandar = info_mandar + "\n" + contacto + G_caracter_separacion_funciones_espesificas[0] + folio;
                //info_mandar = info_mandar + G_caracter_separacion_funciones_espesificas[0] + info_mandar;
                string cont_a_mandar = G_contactos_lista_para_mandar_informacion[6, 1] + G_caracter_separacion[0] + G_contactos_lista_para_mandar_informacion[8, 1];
                mandar_mensage_usuarios(manejadores, esperar, cont_a_mandar, info_mandar);
            }
            

            mandar_mensages_acumulados(manejadores, esperar);

        }




        //fin_procesos------------------------------------------------------------------


        //estos actuan juntos------------------------------------------------------------------------------------
        string[,] mensajes_acumulados = null;
        private string[,] acumulador_de_mensajes(string nombre = null, string mensge = null, string operacion = "agregar")
        {
            if (operacion == "agregar")
            {
                mensajes_acumulados = op_arr.agregar_registro_del_array_bidimensional(mensajes_acumulados, nombre + G_caracter_separacion_funciones_espesificas[0] + mensge, G_caracter_separacion_funciones_espesificas[0]);
                return null;
            }
            else if (operacion == "retornar")
            {
                string[,] tem_mensages = mensajes_acumulados;
                mensajes_acumulados = null;
                return tem_mensages;
            }
            return null;
        }

        private void mandar_mensages_acumulados(IWebDriver manejadores, WebDriverWait esperar)
        {
            //retornar mensages acumulados
            string[,] mensajes_para_y_mensaje = acumulador_de_mensajes(operacion: "retornar");
            //mandar mensages
            if (mensajes_para_y_mensaje != null)
            {
                //ordenar
                for (int i = 0; i < mensajes_para_y_mensaje.GetLength(0); i++)
                {
                    if (mensajes_para_y_mensaje[i, 0] != "usuario_actual")
                    {

                        for (int k = i + 1; k < mensajes_para_y_mensaje.GetLength(0); k++)
                        {
                            if (mensajes_para_y_mensaje[k, 0] == "usuario_actual")
                            {
                                // Almacenar la fila actual en una variable temporal
                                string tempUsuario = mensajes_para_y_mensaje[i, 0];
                                string tempMensaje = mensajes_para_y_mensaje[i, 1];

                                // Intercambiar toda la fila
                                mensajes_para_y_mensaje[i, 0] = mensajes_para_y_mensaje[k, 0];
                                mensajes_para_y_mensaje[i, 1] = mensajes_para_y_mensaje[k, 1];
                                mensajes_para_y_mensaje[k, 0] = tempUsuario;
                                mensajes_para_y_mensaje[k, 1] = tempMensaje;

                            }
                        }
                    }
                }

                for (int i = 0; i < mensajes_para_y_mensaje.GetLength(0); i++)
                {
                    mandar_mensage_usuarios(manejadores, esperar, mensajes_para_y_mensaje[i, 0], mensajes_para_y_mensaje[i, 1]);
                }
            }




        }
        //------------------------------------------------------------------------------------------------


        public void enviar(string modelo, string proceso, string folio_o_palbra_clave_a_del_que_lo_recibira, string info, string contacto = "", string programa_enviar = "CLASE_QU1R30N")
        {

            


            string info_a_env = programa_enviar + G_caracter_para_transferencia_entre_archivos[0] + var_fun_GG.GG_id_programa + G_caracter_para_transferencia_entre_archivos[1] + modelo + G_caracter_para_transferencia_entre_archivos[1] + proceso + G_caracter_para_transferencia_entre_archivos[1] + folio_o_palbra_clave_a_del_que_lo_recibira + G_caracter_para_transferencia_entre_archivos[1] + info + G_caracter_para_transferencia_entre_archivos[1] + contacto;


            bas.Agregar_a_archivo_sin_arreglo(G_dir_arch_transferencia[1], info_a_env);

        }


        private void buscar_nombre_y_dar_click(IWebDriver manejadores, WebDriverWait esperar, string nombre_o_numero)
        {
            Actions action = new Actions(manejadores);
            action.SendKeys(Keys.Escape).Perform();

            //buscamos persona en el buscador de personas
            //aqui hacemos que reconosca la barra de texto y escriba
            if (G_info_de_configuracion_chatbot == null)
            {
                G_info_de_configuracion_chatbot = extraer_info_de_archivos_de_configuracion_chatbot(G_dir_arch_conf_chatbot);
            }
            string lugar_a_escribir = G_info_de_configuracion_chatbot[5][2];
            //var escribir_msg = G_esperar2.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));
            var escribir_msg = esperar.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));

            escribir_msg.SendKeys(nombre_o_numero);
            escribir_msg.SendKeys(Keys.Enter);


            /* lla funciona con el enter que se le da en busqueda asi que no es nesesario
            //damos click
            IWebDriver manejadores_de_busqueda = manejadores;
            //ReadOnlyCollection<IWebElement> elementos = manejadores_de_busqueda.FindElements(By.XPath("//span[contains(@title, 'Jorge')]"));
            string buscar_elemento = G_info_de_configuracion_chatbot[6][1] + nombre_o_numero + "')]";
            IWebElement elemento = manejadores_de_busqueda.FindElement(By.XPath(buscar_elemento));
            string a = elemento.Text;
            elemento.Click();
            */

            //limpiamos_lo_que_se_puso_en_el_buscador_de_contactos
            escribir_msg.Click(); // Enfocar el elemento
            for (int i = 0; i < nombre_o_numero.Length; i++)
            {
                escribir_msg.SendKeys(Keys.Backspace); // Borrar el contenido del textbox
            }


        }

        private void mandar_mensage_usuarios(IWebDriver manejadores, WebDriverWait esperar, object nombre_contacto, string mensage = null, object caracter_separacion_objeto_usuarios = null, object caracter_separacion_objeto_mensages = null)
        {

            string[] caracter_separacion_usuarios = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto_usuarios);
            string[] caracter_separacion_mensajes = vf_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_objeto_mensages);
            string[] supervisores = op_arr.convierte_objeto_a_arreglo(nombre_contacto, caracter_separacion_usuarios[0]);
            
            bool encontro_al_supervisor = false;
            for (int k = 0; k < supervisores.Length; k++)
            {


                for (int h = 0; h < G_contactos_lista_para_mandar_informacion.GetLength(0); h++)
                {

                    if (supervisores[k] == G_contactos_lista_para_mandar_informacion[h, 1])
                    {
                        encontro_al_supervisor = true;
                        // Simular la presión de la tecla Escape
                        Actions action = new Actions(manejadores);
                        action.SendKeys(Keys.Escape).Perform();

                        int indice_supervisor = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_contactos_lista_para_mandar_informacion[h, 0]));
                        for (int l = G_donde_inicia_la_tabla; l < Tex_base.GG_base_arreglo_de_arreglos[indice_supervisor].Length; l++)
                        {
                            buscar_nombre_y_dar_click(manejadores, esperar, Tex_base.GG_base_arreglo_de_arreglos[indice_supervisor][l]);
                            mandar_mensage(esperar, mensage);
                        }

                    }
                }

                if (supervisores[k] == "usuario_actual")
                {
                    encontro_al_supervisor = true;
                    mandar_mensage(esperar, mensage);
                }

                if (encontro_al_supervisor == false)
                {
                    if (nombre_contacto is string)
                    {
                        buscar_nombre_y_dar_click(manejadores, esperar, (string)nombre_contacto);
                        mandar_mensage(esperar, mensage);
                    }

                }



            }


        }

        //WebDriverWait G_esperar2;
        private void mandar_mensage(WebDriverWait esperar, object texto_enviar_arreglo_objeto)
        {
            string[] texto_enviar_arreglo_string = op_arr.convierte_objeto_a_arreglo(texto_enviar_arreglo_objeto, "\n");


            //G_esperar2 = esperar;
            //aqui hacemos que reconosca la barra de texto y escriba
            if (G_info_de_configuracion_chatbot == null)
            {
                G_info_de_configuracion_chatbot = extraer_info_de_archivos_de_configuracion_chatbot(G_dir_arch_conf_chatbot);
            }

            string lugar_a_escribir = G_info_de_configuracion_chatbot[5][1];
            //var escribir_msg = G_esperar2.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));

            var escribir_msg = esperar.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));
            string texto_enviar = string.Join(Keys.Shift + Keys.Enter + Keys.Shift, texto_enviar_arreglo_string);
            texto_enviar = texto_enviar.Replace(G_caracter_separacion_funciones_espesificas[0], "\n");

            escribir_msg.SendKeys(texto_enviar);
            Thread.Sleep(1000); // Puedes ajustar el tiempo de espera según tu escenario
            escribir_msg.SendKeys(Keys.Enter);

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

        private void regresr_respuesta_ia(IWebDriver manejadores, WebDriverWait esperar, string nombre_Del_que_envio_el_mensage, string texto_recibidos_arreglo)
        {

            
            mandar_mensage_usuarios(manejadores, esperar, G_contactos_lista_para_mandar_informacion[5, 1], "ia_" + nombre_Del_que_envio_el_mensage + "\n" + texto_recibidos_arreglo + "\n--------------------------------------------------------------------");
            Actions action = new Actions(manejadores);
            action.SendKeys(Keys.Escape).Perform();
            mandar_mensage_usuarios(manejadores, esperar, nombre_Del_que_envio_el_mensage, texto_recibidos_arreglo);


            action = new Actions(manejadores);
            action.SendKeys(Keys.Escape).Perform();


        }

        private int[] checar_numero_de_direccion_de_archivo_atras_actual_adelante(int posicion_bandera)
        {
            string[] banderas = bas.Leer_inicial(G_dir_arch_transferencia[0]);



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


        private void datos_enviar(IWebDriver manejadores, WebDriverWait esperar, string contacto, string mensage)
        {
            mensage = mensage.Replace(" ", "");
            string[] lineas_del_mensaje = mensage.Split(new string[] { "\n" }, StringSplitOptions.None);

            for (int j = 0; j < lineas_del_mensaje.Length; j++)
            {
                conmutar_datos(manejadores, esperar, "MENSAJE" + G_caracter_para_transferencia_entre_archivos[1] + lineas_del_mensaje[j] + G_caracter_para_transferencia_entre_archivos[1] + contacto);

            }


        }


        private bool funciones_extra_por_grupo(IWebDriver manejadores, WebDriverWait esperar, string nombre, string grupos_que_tienen_el_permiso, string info_a_procesar, string modelo,string funcion_a_hacer, object caracter_separacion_grupos = null)
        {
            bool si_tiene_permiso = permisos(nombre, grupos_que_tienen_el_permiso, caracter_separacion_grupos);

            if (si_tiene_permiso)
            {
                int indice = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_conf_extra[1, 0]));
                
                

                

                if (modelo == "CONFIRMADORES")
                {
                    if (funcion_a_hacer == "confirmar_mensaje_para_cliente")
                    {
                        bool encontro_folio = false;
                        string[] res_folio = calculos_folios(info_a_procesar);
                        mandar_mensajes_deacuerdo_del_resul_calculo_folio(manejadores, esperar, res_folio);
                    }
                }
                else if (modelo == "TESOREROS")
                {
                    if (funcion_a_hacer == "confirmar_comicion_para_vendedor")
                    {
                        bool encontro_folio = false;
                        string[] res_folio = calculos_folios(info_a_procesar);
                        procesar_folio(manejadores, esperar, res_folio);
                    }
                }

                else if (modelo == "ADMINISTRADORES")
                {
                    //"MODELO_ANALISIS_DATOS~PREDICCION_NECESIDADES_COMPRA"
                    string[] temp = info_a_procesar.Split(G_caracter_usadas_por_usuario[0][0]);
                    // Aquí podrías agregar la lógica correspondiente para "COMPRAS" si es necesario.
                    compras(temp, nombre);
                }
                else if (modelo == "COMPRAS")
                {
                    //"MODELO_COMPRAS~COMPRA§" + "COD_BAR1¬1¬200¬2¬NOM_PRODUCTO_SI_NO_ESTA°COD_BAR¬1¬200¬1¬NOM_PRODUCTO_SI_NO_ESTA°COD_BAR1¬1¬200¬2¬NOM_PRODUCTO_SI_NO_ESTA|PROVEDOR1|SUC_9"
                    string[] temp = info_a_procesar.Split(G_caracter_usadas_por_usuario[0][0]);
                    // Aquí podrías agregar la lógica correspondiente para "COMPRAS" si es necesario.
                    compras(temp, nombre);

                }
                else
                {
                    // Aquí podrías agregar una lógica por defecto si es necesario.
                }



            }

            else
            {

            }

            return si_tiene_permiso;
        }

        private bool permisos(string nombre, string grupos_que_tienen_el_permiso, object caracter_separacion_grupos = null)
        {

            bool esta_en_el_grupo = false;
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_grupos);

            string[] grupos_en_los_que_esta = pociciones_en_los_que_se_encutra(nombre);

            string[] grupos_con_permiso = grupos_que_tienen_el_permiso.Split(caracter_separacion[0][0]);
            if (grupos_en_los_que_esta != null)
            {

                for (int i = 0; i < grupos_en_los_que_esta.Length; i++)
                {

                    for (int j = 0; j < grupos_con_permiso.Length; j++)
                    {


                        if (grupos_en_los_que_esta[i] == grupos_con_permiso[j])
                        {
                            esta_en_el_grupo = true;
                            break;
                        }
                    }
                }

            }

            return esta_en_el_grupo;
        }


        private string[] pociciones_en_los_que_se_encutra(string nombre)
        {
            string[] grupos_en_los_que_esta = null;
            int contactos_listas = G_contactos_lista_para_mandar_informacion.GetLength(0);
            for (int i = 0; i < contactos_listas; i++)
            {
                int indice_dir_contactos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_contactos_lista_para_mandar_informacion[i, 0]));
                int contactos_listas2 = Tex_base.GG_base_arreglo_de_arreglos[indice_dir_contactos].Length;
                for (int j = G_donde_inicia_la_tabla; j < contactos_listas2; j++)
                {
                    string temp = Tex_base.GG_base_arreglo_de_arreglos[indice_dir_contactos][j];
                    if (temp == nombre)
                    {
                        grupos_en_los_que_esta = op_arr.agregar_registro_del_array(grupos_en_los_que_esta, G_contactos_lista_para_mandar_informacion[i, 1]);
                        break;
                    }
                }


            }
            return grupos_en_los_que_esta;
        }


        private string registros_y_movimientos_a_confirmar(string nom_mensage_clickeado, string añomesdiahoraminseg, string folio, string pedido_a_confirmar)
        {
            //registros y confirmaciones-----------------------------------------------------------------------------------

            //agregar archivos registros

            int indice_folios = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_conf_extra[1, 0]));

            string tem_info = folio + G_caracter_separacion[0] + añomesdiahoraminseg + G_caracter_separacion[0] + pedido_a_confirmar + G_caracter_separacion[0] + "venta" + G_caracter_separacion[0] + nom_mensage_clickeado + G_caracter_separacion[0] + "id_repartidor" + G_caracter_separacion[0] + "datos_comprador" + G_caracter_separacion[0] + "datos_extras";
            bas.Agregar(G_dir_arch_conf_extra[1, 0], tem_info);


            //fin registros y confirmaciones---------------------------------------------------------------------------------------------------------
            return tem_info;
        }

        public string generar_folio(string añomesdiahoraminseg = null)
        {
            string folio = "";

            if (añomesdiahoraminseg == null)
            {
                folio = GenerarCadenaConFechaHoraAleatoria(4) + "" + DateTime.Now.ToString("yyMMddHHmmss");
            }
            else
            {
                folio = GenerarCadenaConFechaHoraAleatoria(4) + "" + DateTime.Now.ToString(añomesdiahoraminseg);
            }

            folio = folio.ToLower();
            return folio;
        }

        private string GenerarCadenaConFechaHoraAleatoria(int cant_caracteres = 4)
        {
            // Obtiene la hora actual con segundos
            string HoraConSegundos = DateTime.Now.ToString("HHmmss");

            // Inicializa la semilla usando el reloj del sistema
            int semilla = Environment.TickCount;
            Random aleatorio = new Random(semilla);

            // Genera una cadena aleatoria de longitud variable (entre 0 y 10 caracteres)
            int longitud = aleatorio.Next(cant_caracteres);
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] cadenaAleatoria = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                cadenaAleatoria[i] = caracteres[aleatorio.Next(caracteres.Length)];
            }

            // Combina la fecha y hora con la cadena aleatoria
            string resultado = HoraConSegundos + new string(cadenaAleatoria);

            return resultado;
        }
            

        public string buscar(string direccion_archivo, string cod_bar, string id_producto_string = "")
        {
            string inf_retornar = "";
            string[] res_busq = bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo).Split(G_caracter_para_confirmacion_o_error[0][0]);
            int indice = Convert.ToInt32(res_busq[0]);
            if (id_producto_string != "")
            {
                int id_producto = Convert.ToInt32(id_producto_string);
                string[] info_produc_esp = Tex_base.GG_base_arreglo_de_arreglos[indice][id_producto].Split(G_caracter_separacion[0][0]);
                if (cod_bar == info_produc_esp[5])
                {
                    inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + Tex_base.GG_base_arreglo_de_arreglos[indice][id_producto] + G_caracter_para_confirmacion_o_error[0] + id_producto;
                }
                else
                {
                    bool encontro_producto = false;
                    int indice_iniciar_busqueda = id_producto;
                    if (id_producto > 9) { indice_iniciar_busqueda = indice_iniciar_busqueda - 10; }
                    else { indice_iniciar_busqueda = G_donde_inicia_la_tabla; }

                    for (int i = indice_iniciar_busqueda; i < id_producto; i++)
                    {
                        string[] info_prod_bas = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);
                        if (cod_bar == info_prod_bas[5])
                        {
                            inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + Tex_base.GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                            encontro_producto = true;
                            break;
                        }
                    }
                    if (encontro_producto == false)
                    {

                        for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                        {
                            string[] info_prod_bas = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);

                            if (cod_bar == info_prod_bas[5])
                            {
                                inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + Tex_base.GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                                encontro_producto = true;
                                break;
                            }
                        }

                    }
                }
            }
            else
            {
                bool encontro_producto = false;
                for (int i = 0; i < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; i++)
                {
                    string[] info_produc_esp = Tex_base.GG_base_arreglo_de_arreglos[indice][i].Split(G_caracter_separacion[0][0]);
                    if (cod_bar == info_produc_esp[5])
                    {
                        inf_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + Tex_base.GG_base_arreglo_de_arreglos[indice][i] + G_caracter_para_confirmacion_o_error[0] + i;
                        encontro_producto = true;
                        break;
                    }
                }
                if (encontro_producto == false)
                {
                    inf_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no encontro el producto";
                }
            }
            return inf_retornar;
        }


        private string[] calculos_folios(string folio)
        {
            string[] info_a_retornar = null;
            int indice = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_conf_extra[1, 0]));

            

            for (int k = G_donde_inicia_la_tabla; k < Tex_base.GG_base_arreglo_de_arreglos[indice].Length; k++)
            {
                string[] movimiento_a_confirmar = Tex_base.GG_base_arreglo_de_arreglos[indice][k].Split(G_caracter_separacion[0][0]);
                string contacto = movimiento_a_confirmar[4];
                
                //encontro folio?
                if (folio == movimiento_a_confirmar[0])
                {
                    //es una venta?
                    if ("venta" == movimiento_a_confirmar[3])
                    {
                        string[] pedido_a_enviar_para_hacer = movimiento_a_confirmar[2].Split(G_caracter_separacion[1][0]);

                        double acumulador_de_la_venta = 0;

                        //toda la cantidad de pedidos
                        for (int i = 0; i < pedido_a_enviar_para_hacer.Length; i++)
                        {

                            string[] ped_split = pedido_a_enviar_para_hacer[i].Split(G_caracter_usadas_por_usuario[0][0]);

                            string[] res_verificaicion = null;
                            //este solo checa si tiene el id del producto para que si si lo encuentre mas rapido
                            if (ped_split.Length>2){res_verificaicion = buscar(G_direcciones[0], ped_split[0], ped_split[2]).Split(G_caracter_para_confirmacion_o_error[0][0]);}
                            else{res_verificaicion = buscar(G_direcciones[0], ped_split[0]).Split(G_caracter_para_confirmacion_o_error[0][0]);}


                            //encontror el producto?
                            if (res_verificaicion[0] == "1")
                            {
                                string[] res_esp = res_verificaicion[1].Split(G_caracter_separacion[0][0]);


                                string cod_bar = ped_split[0];
                                string nom_produc = res_esp[1] + " " + res_esp[2] + " " + res_esp[3];
                                double cantidad = Convert.ToDouble(ped_split[1]);
                                double precio = Convert.ToDouble(res_esp[4]);
                                double total_producto = cantidad * precio;
                                string pocicion_producto = res_verificaicion[2];
                                string tipo_producto = res_esp[20];


                                acumulador_de_la_venta = acumulador_de_la_venta + total_producto;

                                info_a_retornar = op_arr.agregar_registro_del_array(info_a_retornar, nom_produc + G_caracter_usadas_por_usuario[0] + cantidad + G_caracter_usadas_por_usuario[0] + precio + G_caracter_usadas_por_usuario[0] + total_producto + G_caracter_usadas_por_usuario[0] + cod_bar + G_caracter_usadas_por_usuario[0] + pocicion_producto + G_caracter_usadas_por_usuario[0] + tipo_producto);


                            }

                            else
                            {
                                string info_del_folio = string.Join(G_caracter_usadas_por_usuario[0], ped_split);
                                info_a_retornar = op_arr.agregar_registro_del_array(info_a_retornar, info_del_folio);
                            }



                        }

                        info_a_retornar = op_arr.agregar_registro_del_array(info_a_retornar, "proceso" + G_caracter_usadas_por_usuario[0] + movimiento_a_confirmar[3]);
                        info_a_retornar = op_arr.agregar_registro_del_array(info_a_retornar, "contacto" + G_caracter_usadas_por_usuario[0] + movimiento_a_confirmar[4]);
                        info_a_retornar = op_arr.agregar_registro_del_array(info_a_retornar, "total" + G_caracter_usadas_por_usuario[0] + acumulador_de_la_venta);
                        



                    }




                }

            }


            return info_a_retornar;
        }

        private void mandar_mensajes_deacuerdo_del_resul_calculo_folio(IWebDriver manejadores, WebDriverWait esperar, string[] resultado_de_folio)
        {
            if (resultado_de_folio != null)
            {



                string[] proceso = resultado_de_folio[resultado_de_folio.Length - 3].Split(G_caracter_usadas_por_usuario[0][0]);
                string[] contacto = resultado_de_folio[resultado_de_folio.Length - 2].Split(G_caracter_usadas_por_usuario[0][0]);

                if (proceso[1] == "venta")
                {
                    string mensaje_encargados = "";
                    string mensaje_supervisores = "";
                    string mensaje_contador = "";
                    string mensaje_repartidor = "";

                    for (int i = 0; i < resultado_de_folio.Length - 3; i++)
                    {
                        string[] info_espliteada = resultado_de_folio[i].Split(G_caracter_usadas_por_usuario[0][0]);
                        if (info_espliteada.Length > 2)
                        {
                            string nom_produc = info_espliteada[0];
                            string cantidad = info_espliteada[1];
                            string precio_unitario = info_espliteada[2];
                            string total_producto = info_espliteada[3];

                            mensaje_encargados = op_tex.concatenacion_caracter_separacion(mensaje_encargados, nom_produc + " cantidad:" + cantidad, "\n");
                            mensaje_supervisores = op_tex.concatenacion_caracter_separacion(mensaje_supervisores, nom_produc + " cantidad:" + cantidad + " $" + total_producto, "\n");
                            mensaje_contador = op_tex.concatenacion_caracter_separacion(mensaje_contador, nom_produc + " cantidad:" + cantidad + " $" + total_producto, "\n");
                            mensaje_repartidor = op_tex.concatenacion_caracter_separacion(mensaje_repartidor, nom_produc + " cantidad:" + cantidad, "\n");
                        }
                        else
                        {
                            switch (info_espliteada[0])
                            {
                                case "UBI":
                                    mensaje_supervisores = op_tex.concatenacion_caracter_separacion(mensaje_supervisores, resultado_de_folio[i], "\n");
                                    mensaje_repartidor = op_tex.concatenacion_caracter_separacion(mensaje_repartidor, resultado_de_folio[i], "\n");
                                    break;
                                case "EXT":
                                    mensaje_supervisores = op_tex.concatenacion_caracter_separacion(mensaje_supervisores, resultado_de_folio[i], "\n");
                                    mensaje_encargados = op_tex.concatenacion_caracter_separacion(mensaje_encargados, resultado_de_folio[i], "\n");
                                    break;
                                case "CAN":
                                    mensaje_supervisores = op_tex.concatenacion_caracter_separacion(mensaje_supervisores, resultado_de_folio[i], "\n");
                                    mensaje_repartidor = op_tex.concatenacion_caracter_separacion(mensaje_repartidor, resultado_de_folio[i], "\n");
                                    mensaje_encargados = op_tex.concatenacion_caracter_separacion(mensaje_encargados, resultado_de_folio[i], "\n");
                                    break;
                                default:
                                    mensaje_supervisores = op_tex.concatenacion_caracter_separacion(mensaje_supervisores, resultado_de_folio[i], "\n");
                                    break;
                            }

                        }


                    }

                    string[] total_a_pagar = resultado_de_folio[resultado_de_folio.Length - 1].Split(G_caracter_usadas_por_usuario[0][0]);

                    mensaje_supervisores = contacto[1] + "\n" + mensaje_supervisores + "\nTotal a pagar:" + total_a_pagar[1];
                    mensaje_contador = mensaje_contador + "\nTotal a pagar:" + total_a_pagar[1];
                    mensaje_repartidor = contacto[1] + "\n" + mensaje_repartidor + "\nTotal a pagar:" + total_a_pagar[1];


                    mandar_mensage_usuarios(manejadores, esperar,
                        G_contactos_lista_para_mandar_informacion[0, 1] + G_caracter_separacion[0] +
                        G_contactos_lista_para_mandar_informacion[1, 1] + G_caracter_separacion[0] +
                        G_contactos_lista_para_mandar_informacion[2, 1] + G_caracter_separacion[0] +
                        G_contactos_lista_para_mandar_informacion[4, 1],
                        mensaje_encargados + G_caracter_separacion_funciones_espesificas[0] +
                        mensaje_supervisores + G_caracter_separacion_funciones_espesificas[0] +
                        mensaje_contador + G_caracter_separacion_funciones_espesificas[0] +
                        mensaje_repartidor
                        );


                }
            }

            else
            {
                mandar_mensage(esperar, "no se encontro el folio");
            }

        }

        private void procesar_folio(IWebDriver manejadores, WebDriverWait esperar, string[] resultado_de_folio)
        {


            



            if (resultado_de_folio != null)
            {



                string[] proceso = resultado_de_folio[resultado_de_folio.Length - 3].Split(G_caracter_usadas_por_usuario[0][0]);
                string[] contacto = resultado_de_folio[resultado_de_folio.Length - 2].Split(G_caracter_usadas_por_usuario[0][0]);

                if (proceso[1] == "venta")
                {
                    
                    string pedido_PROCESAR = "";
                    double ventas_para_comicion = 0;
                    for (int i = 0; i < resultado_de_folio.Length - 3; i++)
                    {
                        string[] info_espliteada = resultado_de_folio[i].Split(G_caracter_usadas_por_usuario[0][0]);
                        if (info_espliteada.Length > 2)
                        {
                            string nom_produc = info_espliteada[0];
                            string cantidad = info_espliteada[1];
                            string precio_unitario = info_espliteada[2];
                            string total_producto = info_espliteada[3];
                            string cod_bar = info_espliteada[4];
                            string posicion_producto = info_espliteada[5];
                            string[] clasificacion = info_espliteada[6].Split(G_caracter_separacion[1][0]);
                            
                            for (int j = 0; j < clasificacion.Length; j++)
                            {
                                if (clasificacion[j] == "SIMUL")
                                {
                                    ventas_para_comicion = ventas_para_comicion + Convert.ToDouble(total_producto);
                                    break;
                                }
                            }

                            

                            pedido_PROCESAR = op_tex.concatenacion_caracter_separacion(pedido_PROCESAR, cod_bar + G_caracter_separacion[2] + cantidad + G_caracter_separacion[2] + posicion_producto + G_caracter_separacion[2] + "WS" , G_caracter_separacion[1]);
                        }
                        else
                        {
                            switch (info_espliteada[0])
                            {
                                case "UBI":
                                    
                                    break;
                                case "EXT":
                                    
                                    break;
                                case "CAN":
                                    
                                    break;
                                default:
                                    
                                    break;
                            }

                        }


                    }

                    string[] total_a_pagar = resultado_de_folio[resultado_de_folio.Length - 1].Split(G_caracter_usadas_por_usuario[0][0]);


                    //procesar venta
                    enviar("PUNTO_VENTA", "VENTA", "WS", "MODELO_VENTAS" + G_caracter_separacion_funciones_espesificas[0] + "VENTA" + G_caracter_separacion_funciones_espesificas[1] + pedido_PROCESAR, contacto[1]);
                    //comicion
                    enviar("PUNTO_VENTA", "COMICION_UNIFICADA_VENTA", "WS", "MODELO_MUL" + G_caracter_separacion_funciones_espesificas[0] + "COMICION_VENTA_BUSQUEDA_POR_TELEFONO" + G_caracter_separacion_funciones_espesificas[1] + contacto[1] + G_caracter_separacion[2] + ventas_para_comicion, contacto[1]);

                }
            }

            else
            {
                mandar_mensage(esperar, "no se encontro el folio");
            }





        }

        private void administracion(string[] datos_compras, string contacto)
        {
            if (datos_compras[0] == "PREDICCION_COMPRA")
            {
                
                string pedido_PROCESAR = datos_compras[1] + G_caracter_separacion[2] + datos_compras[2] + G_caracter_separacion[2] + datos_compras[3] + G_caracter_separacion[2] + datos_compras[4] + G_caracter_separacion[2] + datos_compras[5];
                enviar("ADMINISTRACION", "PREDICCION_COMPRA", "WS", "MODELO_ANALISIS_DATOS" + G_caracter_separacion_funciones_espesificas[0] + "PREDICCION_NECESIDADES_COMPRA" + G_caracter_separacion_funciones_espesificas[1] + pedido_PROCESAR, contacto);
            }
        }

        private void compras(string[] datos_compras, string contacto)
        {
            if (datos_compras[0]== "COMP")
            {
                string[] cantidad_de_productos = datos_compras[1].Split(G_caracter_usadas_por_usuario[1][0]);
                string pedido_PROCESAR = "";
                for (int i = 0; i < cantidad_de_productos.Length; i++)
                {
                    string[] info_espliteada = cantidad_de_productos[i].Split(G_caracter_usadas_por_usuario[2][0]);
                    pedido_PROCESAR = op_tex.concatenacion_caracter_separacion(pedido_PROCESAR, info_espliteada[0] + G_caracter_separacion[2] + info_espliteada[1] + G_caracter_separacion[2] + info_espliteada[2] + G_caracter_separacion[2] + info_espliteada[3] + G_caracter_separacion[2] + info_espliteada[4], G_caracter_separacion[1]);
                }
                pedido_PROCESAR = pedido_PROCESAR + G_caracter_separacion[0] + datos_compras[2] + G_caracter_separacion[0] + "SUC1";


                enviar("COMPRAS", "COMPRA", "WS", "MODELO_COMPRAS" + G_caracter_separacion_funciones_espesificas[0] + "COMPRA" + G_caracter_separacion_funciones_espesificas[1] + pedido_PROCESAR, contacto);
            }

            else if (datos_compras[0]=="PREDICCION_COMPRA")
            {
                
                enviar("ADMINISTRACION", "PREDICCION_COMPRA", "WS_RS", "MODELO_ANALISIS_DATOS" + G_caracter_separacion_funciones_espesificas[0] + "PREDICCION_NECESIDADES_COMPRA" + G_caracter_separacion_funciones_espesificas[1] + "", contacto);
            }
        }


        //fin de la clase-------------------------------------------------------------------------------
    }

}
