using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexoPortalArcano_SISTEMA_QU1R30N_WS.clases;

namespace NexoPortalArcano_SISTEMA_QU1R30N_WS
{
    internal class poner_al_inicio_del_programa
    {
        Tex_base bas = new Tex_base();
        operaciones_arreglos op_arreglos = new operaciones_arreglos();

        int G_configuracion = var_fun_GG.GG_indice_donde_comensar;
        public string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        public string[] G_separador_para_funciones_espesificas_ = var_fun_GG.GG_caracter_separacion_funciones_espesificas;



        public void inicio()
        {

            string direccion_archivo_de_direcciones_de_bd = "archivos_iniciales\\inicio.txt";
            string fila_inicial = "direccion_de_las_bases_de_datos" + bas.GG_separador_para_funciones_espesificas_[0] + "fila_inicial" + bas.GG_separador_para_funciones_espesificas_[0] + "arreglo_de_filas_separado_por_§//posdata_solo_ir_agregando_archivos_asta_abajo_por_que_las_filas_ya_son_ocupadas_por_el_programa_y_no_borrar";



            string[] agregar_filas =
            {
                // empiesa desde el 1 por que el 0 es de los archivos iniciales
                
                /*1*/ "config\\chatbot\\info_para_comandos_chatbot\\00_paginaweb.txt~info_para_comandos~http://web.whatsapp.com/",
                /*2*/ "config\\chatbot\\info_para_comandos_chatbot\\01_ya_entrado_en_la_mensajeria.txt~info_para_comandos~side",
                /*3*/ "config\\chatbot\\info_para_comandos_chatbot\\02_chequeo_no_leidos.txt~info_para_comandos~//span[contains(@aria-label, 'No leídos') or contains(@aria-label, '4 mensaje no leído') or contains(@aria-label, '3 mensaje no leído') or contains(@aria-label, '2 mensaje no leído') or contains(@aria-label, '1 mensaje no leído')]",
                /*4*/ "config\\chatbot\\info_para_comandos_chatbot\\03_clickeo.txt~info_para_comandos~//ancestor::div[@class='_8nE1Y']",
                /*5*/ "config\\chatbot\\info_para_comandos_chatbot\\04_lectura_del_mensage.txt~info_para_comandos~//div[contains(@class, 'message-in')]//span[contains(@class, '_11JPr')]",
                /*6*/ "config\\chatbot\\info_para_comandos_chatbot\\05_reconocer_textbox_de_envio.txt~info_para_comandos~//*[@id='main']/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]",
                /*7*/ "config\\chatbot\\info_para_comandos_chatbot\\06_buscar_nombre.txt~info_para_comandos~//span[contains(@title, '",

                /*8*/ "config\\chatbot\\info_para_comandos_chatbot\\07_nombre_del_clikeado.txt~info_para_comandos~//header[@class='AmmtE']//div[@class='Mk0Bp _30scZ']§//*[@id='main']/header/div[2]/div[1]/div/span",
                
                /*9*/ "config\\chatbot\\05_encargados.txt~nombre_o_numero_de_telefono_que_aparece_en_el_watsap~Encargados",
                /*10*/ "config\\chatbot\\06_supervisores.txt~nombre_o_numero_de_telefono_que_aparece_en_el_watsap~Supervisores",
                /*11*/ "config\\chatbot\\07_contadores.txt~nombre_o_numero_de_telefono_que_aparece_en_el_watsap~Contadores",
                /*12*/ "config\\chatbot\\08_vendedores.txt~nombre_o_numero_de_telefono_que_aparece_en_el_watsap~Prueba",
                /*13*/ "config\\chatbot\\09_repartidores.txt~nombre_o_numero_de_telefono_que_aparece_en_el_watsap~Repartidores",
                /*14*/ "config\\chatbot\\10_reg_mensaje.txt~nombre_o_numero_de_telefono_que_aparece_en_el_watsap_y_envia_todos_los_mensajes_recibidos~Reg_mensaje",
                
                /*15*/ "config\\chatbot\\configuracion_programador.txt~nombre_o_numero_de_telefono_que_aparece_en_el_watsap_y_este_para_funciones_especificas_echas_por_el_programador~",
                /*16*/ "config\\chatbot\\14_tesoreros.txt~nombre_o_numero_de_telefono_que_aparece_en_el_watsap~Tesoreros",

                /*17*/ "config\\chatbot\\15_mensaje_bienvenida.txt~mensaje_1§mensaje_2~hola§los productos los encntraras en esta pagina https://www.QU1R30N.com/§espero sea de tu agrado",

                /*18*/ "config\\chatbot\\16_inventario.txt~ID|PRODUCTO|CONTENIDO|TIPO_MEDIDA|PRECIO_VENTA|COD_BARRAS|CANTIDAD|COSTO_COMP|PROVEDOR|GRUPO|CANT_X_PAQUET|ES_PAQUETE|CODBAR_PAQUETE|COD_BAR_INDIVIDUAL_ES_PAQ|LIGAR_PROD_SAB|IMPUESTOS|INGREDIENTES|CADUCIDAD|ULTIMO_MOV|SUCUR_VENT|CLAF_PROD|DIR_IMG_INTER|DIR_IMG_COMP|INFO_EXTRA|PROCESO_CREAR|DIR_VID_PROC_CREAR|NO_PONER_NADA~",

                /*19*/ "config\\chatbot\\registros\\folios_a_checar\\folio_ventas.txt~folio_venta|añomesdiahoraminutosegundo|total|operacion|producto1¬precio1°pedido2¬precio2|vendedor|num_celular_vendedor|repartidor|datos_comprador°datos_comprador|datos_extra1°dato_extra2~",
                /*20*/ "config\\chatbot\\12_confirmadores.txt~nombre_o_numero_de_telefono_que_aparece_en_el_watsap~Confirmadores",



            };

           bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(direccion_archivo_de_direcciones_de_bd, fila_inicial, agregar_filas, caracter_separacion_fun_esp_objeto: G_separador_para_funciones_espesificas_[2]);



            //Tex_base.GG_dir_bd_y_valor_inicial_bidimencional = op_arreglos.agregar_registro_del_array_bidimensional(Tex_base.GG_dir_bd_y_valor_inicial_bidimencional, direccion_archivo_de_direcciones_de_bd, new string[] { bas.G_separador_para_funciones_espesificas });

            for (int i = G_configuracion; i < Tex_base.GG_base_arreglo_de_arreglos[0].Length; i++)
            {
                string[] espliteados_direcciones_bases_datos_y_fila_inicial = Tex_base.GG_base_arreglo_de_arreglos[0][i].Split(bas.GG_separador_para_funciones_espesificas_[0][0]);
                string[] filas_iniciales = espliteados_direcciones_bases_datos_y_fila_inicial[2].Split(G_separador_para_funciones_espesificas_[1][0]);
                if (i > 0)
                {
                    bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(espliteados_direcciones_bases_datos_y_fila_inicial[0], espliteados_direcciones_bases_datos_y_fila_inicial[1], filas_iniciales);
                }


            }

            chatbot_clase chatbot = new chatbot_clase();
            
            bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "config\\chatbot\\respondiendo_a_una_pregunta.txt", "0_puede_enviar_mensaje_1_espera_a_que_se_desocupe_ia", new string[] { "0" }, leer_y_agrega_al_arreglo: false);

            //entrada_salida_y_pedido
            for (int i = 0; i < chatbot.G_dir_arch_transferencia.Length; i++)
            {
                bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(chatbot.G_dir_arch_transferencia[i], "sin_informacion", leer_y_agrega_al_arreglo: false);
            }
            bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\xerox\\config\\inf\\bklkfjc\\9.txt", "sin_informacion", new string[] { "0", "1", "2", "6", "7", "8" }, leer_y_agrega_al_arreglo: false);
        }
    }
}
