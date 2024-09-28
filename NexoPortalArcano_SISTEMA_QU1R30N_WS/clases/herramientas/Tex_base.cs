using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
using System.Windows.Forms;

namespace NexoPortalArcano_SISTEMA_QU1R30N_WS.clases
{
    class Tex_base
    {
        string G_direccion_base_archivos_bandera = "BANDERAS_ARCH\\";


        static public string[][] GG_base_arreglo_de_arreglos = null;


        //direcciones_de_las_bases
        static public string[,] GG_dir_bd_y_valor_inicial_bidimencional = null;

        //[0]=indice desde donde comensara desde el 0 nombre de las columnas y es mejor empesar desde el 1
        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;
        var_fun_GG vf_GG = new var_fun_GG();
        //caracteres de separacion//el primero lo usaremos diferente NO USAR LOS MISMOS QUE G_separador_para_funciones_espesificas;
        /*
        public string[] G_caracter_separacion = { "|", "°", "¬", "^" };
        public string G_separador_para_funciones_espesificas = "~";
        public string G_separador_para_funciones_espesificas2 = "§";
        public string G_separador_para_funciones_espesificas3 = "¶";
        */
        public string[] GG_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        public string[] GG_separador_para_funciones_espesificas_ = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        public string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;

        static public string GG_año_mes_dia_para_registros_ = DateTime.Now.ToString("yyyyMMdd");



        /*Aquí poner las funciones de las otras clases Si te vas a llevar esta clase solamente --------------------------------
       Ver poniendo también los nombres de las funciones que estás usando para no pasar toda la clase -----------------------
       Próstata también el nombre de la clase para saber de qué clase se está sacando las funciones -------------------------
       */
        operaciones_arreglos op_arr = new operaciones_arreglos();


        //fin Aquí poner las funciones de las otras clases Si te vas a llevar esta clase solamente --------------------------------


        //no muy importantes---------------------------------------------------------------------------------------------------



        //fin no muy importantes-------------------------------------------------------------------------------------------------


        //filas: es para filas iniciales valor_inicial: se utilisa para poner filas inicial normalmente se usa para poner el nombre de las columnas
        public string Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(string direccion_archivo, string valor_inicial = null, string[] filas_iniciales = null, object caracter_separacion_fun_esp_objeto = null, bool leer_y_agrega_al_arreglo = true)
        {
            string[] caracter_separacion_fun_esp = vf_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_fun_esp_objeto);
            char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split
            string acumulador_directorios_y_archvo = "";
            string[] direccion_espliteada = direccion_archivo.Split(parametro2);//spliteamos la direccion
            bool creo_algo = false;

            for (int i = 0; i < direccion_espliteada.Length; i++)//pasamos por todas las los directorios y archivo
            {
                if (i < direccion_espliteada.Length - 1)//el path muestra 6 palabras que fueron espliteadas se le resta uno por que los arreglos empiesan desde 0 y solo se le pone el menor que por que la ultima palabra es el archivo
                {
                    acumulador_directorios_y_archvo = acumulador_directorios_y_archvo + direccion_espliteada[i] + "\\"; // va acumulando los directorios a los que va a entrar ejemplo: ventas\\   ventas\\2016    ventas\\2016\\        ventas\\2016\\11      ventas\\2016\\11\\dias\\  y no muestra el ultimo por que es el archivo y en el if  le dijimos que lo dejara en el penultimo
                    if (!Directory.Exists(acumulador_directorios_y_archvo))//si el directorio no existe entrara y lo creara
                    {

                        Directory.CreateDirectory(acumulador_directorios_y_archvo);//crea el directorio
                        creo_algo = true;
                    }
                }
            }

            if (direccion_espliteada[direccion_espliteada.Length - 1] != "")//checa si escribio tambien el archivo o solo carpetas
            {
                if (!File.Exists(direccion_archivo))//si el archivo no existe entra y lo crea
                {

                    FileStream fs0 = new FileStream(direccion_archivo, FileMode.CreateNew);//crea una variable tipo filestream "fs0"  y crea el archivo
                    fs0.Close();//cierra fs0 para que se pueda usar despues



                    if (valor_inicial != null)// si al llamar a la funcion  le pusiste valor_inicial las escribe //se utilisa para que sea como un titulo o un eslogan pero lo utilisaremos en este prog
                    {
                        Agregar_a_archivo_sin_arreglo(direccion_archivo, valor_inicial);//escribe aqui el valor inicial si es que lo pusiste
                    }

                    if (filas_iniciales != null)//si al llamar a la funcion le pusistes columnas a agregar//recuerda que se separan por comas
                    {
                        if (filas_iniciales.Length == 1 && filas_iniciales[0] == "")
                        {

                        }
                        else
                        {
                            for (int i = 0; i < filas_iniciales.Length; i++)
                            {
                                Agregar_a_archivo_sin_arreglo(direccion_archivo, filas_iniciales[i]);//agrega las filas
                            }
                        }

                    }


                    creo_algo = true;
                }
                //si crea ele archivo lee el archivo
                if (leer_y_agrega_al_arreglo)
                {
                    GG_dir_bd_y_valor_inicial_bidimencional = op_arr.agregar_registro_del_array_bidimensional(GG_dir_bd_y_valor_inicial_bidimencional, direccion_archivo + caracter_separacion_fun_esp[0] + valor_inicial, caracter_separacion_fun_esp);
                    GG_base_arreglo_de_arreglos = op_arr.agregar_arreglo_a_arreglo_de_arreglos(GG_base_arreglo_de_arreglos, Leer(direccion_archivo));
                    return direccion_archivo + GG_caracter_separacion[0] + "leido";
                }
            }
            if (creo_algo)
            {
                return direccion_archivo;
            }

            return null;
        }

        // Método para leer un archivo de texto y devolver un array de strings

        public string[] Leer(string direccionArchivo, string posString = null, object caracter_separacion_objeto = null, int iniciar_desde_que_fila = 0)
        {

            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);


            // Declaración de variables
            string[] linea = null;      // Almacenará todas las líneas cuando posString sea null
            string[] resultado = null;  // Almacenará el resultado final cuando posString no sea null
            string[] posSplit;
            int[] posiciones;

            string palabra = null;

            /*
            //-----------------------------------------------------------------------------------------------
            string[] dir_sep = extraer_separado_carpetas_nombreArchivo_extencion(direccionArchivo);
            dir_sep[0] = dir_sep[0] + "\\" + G_direccion_base_archivos_bandera;
            string dir_bandera = dir_sep[0] + "\\" + dir_sep[1] + "." + dir_sep[2];
            //este archivo bandera es para que no se agarre el archivo otro programa antes de sustituirlo
            dir_bandera = dir_bandera.Replace(".TXT", "_BANDERA.TXT");
            Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(dir_bandera, leer_y_agrega_al_arreglo: false);

            StreamWriter sw_bandera = null;
            bool esta_libre = false;
            while (esta_libre == false)
            {
                try
                {
                    sw_bandera = new StreamWriter(dir_bandera);
                    esta_libre = true;
                }
                catch { }
            }
            //------------------------------------------------------------------------------------------
            */

            // Crear un objeto StreamReader para leer el archivo
            StreamReader sr = null;
            while (sr == null) 
            {

                
                try
                {
                    sr = new StreamReader(direccionArchivo);
                    
                }
                catch (Exception e)
                {
                    string[] checador = Leer(var_fun_GG.GG_direccion_control_errores_try);
                    chequeo_error_try(direccionArchivo, e, checador[1]);
                }
            }
            
            try
            {
                // Si posString es null, se lee el archivo línea por línea y se agrega cada línea a "linea"
                if (posString == null)
                {
                    while ((palabra = sr.ReadLine()) != null)
                    {
                        if (palabra != "")
                        {
                            linea = op_arr.agregar_registro_del_array(linea, palabra);
                        }
                    }
                }
                // Si posString no es null, se extraen las columnas especificadas y se agregan a "resultado"
                else
                {
                    posSplit = posString.Split(caracter_separacion[0][0]);
                    posiciones = new int[posSplit.Length];

                    // Convertir las posiciones de las columnas de string a int
                    for (int i = 0; i < posiciones.Length; i++)
                    {
                        posiciones[i] = Convert.ToInt32(posSplit[i]);
                    }

                    // Leer el archivo línea por línea y procesar según las posiciones especificadas
                    for (int i = 0; (palabra = sr.ReadLine()) != null; i++)
                    {
                        string[] splLinea = palabra.Split(caracter_separacion[0][0]);

                        palabra = "";
                        for (int j = 0; j < posiciones.Length; j++)
                        {
                            if (j < posiciones.Length - 1)
                            {
                                palabra = palabra + splLinea[posiciones[j]] + caracter_separacion[0];
                            }
                            else
                            {
                                palabra = palabra + splLinea[posiciones[j]];
                            }
                        }

                        // Agregar la palabra procesada al arreglo "resultado"
                        resultado = op_arr.agregar_registro_del_array(resultado, palabra);
                    }

                }

                // Cerrar el StreamReader ya que se ha completado el procesamiento
                sr.Close();

                //sw_bandera.Close();

            }
            catch
            {
                sr.Close();
                //sw_bandera.Close();
            }

            if (linea != null)
            {

                if ((linea.Length - iniciar_desde_que_fila) > 0)
                {


                    // Copiar el contenido de "linea" a un nuevo arreglo para evitar referencias no deseadas
                    string[] arreglo_a_retornar = new string[linea.Length - iniciar_desde_que_fila];
                    for (int k = iniciar_desde_que_fila; k < linea.Length; k++)
                    {
                        arreglo_a_retornar[k - iniciar_desde_que_fila] = "" + linea[k];
                    }

                    //sw_bandera.Close();
                    // Devolver el resultado
                    return arreglo_a_retornar;
                }
                else { return null; }
            }
            else
            {
                //sw_bandera.Close();
                return null;
            }

        }


        public string[] Agregar(string direccion_archivos, string agregando)
        {
            StreamWriter sw = new StreamWriter(direccion_archivos, true);
            try
            {
                sw.WriteLine(agregando);
                sw.Close();
            }
            catch
            {

                sw.Close();

            }

            string num_indice_de_direccion = sacar_indice_del_arreglo_de_direccion(direccion_archivos);

            if (num_indice_de_direccion != null)
            {
                int num_indice_de_direccion_int = Convert.ToInt32(num_indice_de_direccion);
                GG_base_arreglo_de_arreglos[num_indice_de_direccion_int] = op_arr.agregar_registro_del_array(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int], agregando);

                return GG_base_arreglo_de_arreglos[num_indice_de_direccion_int];
            }

            return null;
        }

        public void Agregar_a_archivo_sin_arreglo(string direccion_archivos, string agregando)
        {
            StreamWriter sw = new StreamWriter(direccion_archivos, true);
            try
            {

                sw.WriteLine(agregando);
                sw.Close();

            }
            catch (Exception)
            {

                sw.Close();
            }

        }






        public void eliminar_fila_PARA_MULTIPLES_PROGRAMAS(string direccion_archivo, int columna_a_comparar, string comparar, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            
            StreamReader sr = null;
            while (sr == null) 
            {


                try
                {
                    sr = new StreamReader(direccion_archivo);
                    
                }
                catch (Exception e)
                {

                    string[] checador = Leer(var_fun_GG.GG_direccion_control_errores_try);
                    chequeo_error_try(direccion_archivo, e, checador[1]);
                }
            }

            string dir_tem = direccion_archivo.Replace(".TXT", "_TEM.TXT");
            StreamWriter sw = new StreamWriter(dir_tem, true);


            try
            {

                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {
                    string linea = sr.ReadLine();//leemos linea y lo guardamos en linea
                    if (linea != null)
                    {

                        string[] linea_espliteada = linea.Split(caracter_separacion[0][0]);
                        if (linea_espliteada[columna_a_comparar] != comparar)
                        {
                            sw.WriteLine(linea);
                        }



                    }

                }



                sr.Close();
                sw.Close();

                File.Delete(direccion_archivo);//borramos el archivo original
                File.Move(dir_tem, direccion_archivo);//renombramos el archivo temporal por el que tenia el original

                


            }
            catch (Exception error)
            {
                sr.Close();
                sw.Close();
                File.Delete(dir_tem);//borramos el archivo temporal

                

            }


        }

        public string[] eliminar_fila(string direccion_archivo, int num_column_comp, string comparar, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            string num_indice_de_direccion = sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            int num_indice_de_direccion_int = Convert.ToInt32(num_indice_de_direccion);

            string temp = "";

            for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
            {
                string[] columnas = GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i].Split(caracter_separacion[0][0]);

                if (columnas[num_column_comp] == comparar)
                {
                    break;
                }

                if (i > GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length - 1)
                {
                    temp = temp + GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i] + GG_separador_para_funciones_espesificas_[0];
                }
                else
                {
                    temp = temp + GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i];
                }

            }
            string[] arreglo_a_retornar = temp.Split(GG_separador_para_funciones_espesificas_[0][0]);
            return arreglo_a_retornar;
        }

        public string seleccionar(string direccion_archivo, int num_column_comp, string comparar, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            int num_indice_de_direccion_int = Convert.ToInt32(sacar_indice_del_arreglo_de_direccion(direccion_archivo));

            for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
            {
                string[] columnas = GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i].Split(caracter_separacion[0][0]);

                if (columnas[num_column_comp] == comparar)
                {

                    return GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i];
                }
            }
            return null;
        }

        public string sacar_indice_del_arreglo_de_direccion(string direccion_archivo)
        {
            string num_indice_de_direccion = null;
            for (int i = G_donde_inicia_la_tabla; i < GG_dir_bd_y_valor_inicial_bidimencional.GetLength(0); i++)
            {
                if (GG_dir_bd_y_valor_inicial_bidimencional[i, 0] == direccion_archivo)
                {
                    num_indice_de_direccion = "" + i;
                    return num_indice_de_direccion;
                }
            }
            return num_indice_de_direccion;
        }




        public string Agregar_sino_existe
            (string direccion_archivo_a_checar, int num_column_comp, string comparar, string texto_a_agregar_si_no_esta = "", object caracter_separacion_obj = null)
        {

            operaciones_textos op_tex = new operaciones_textos();


            string info_a_retornar = "";

            try
            {
                string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);


                string direccion_archivo = direccion_archivo_a_checar;
                string resultado_archivo = sacar_indice_del_arreglo_de_direccion(direccion_archivo);

                if (resultado_archivo == null)
                {
                    resultado_archivo = "-1";
                }
                string[] res_esp_archivo = resultado_archivo.Split(G_caracter_para_confirmacion_o_error[0][0]);

                //encontro o no archivo
                if (Convert.ToInt32(res_esp_archivo[0]) > 0)//si res es mayor a 0 la operacioon fue exitosa si no hubo un error
                {
                    //encontro archivo y direccion en la lista
                    if (res_esp_archivo[0] == "1")
                    {

                        int num_indice_de_direccion_int = Convert.ToInt32(res_esp_archivo[1]);
                        bool encotro_info = false;

                        for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                        {

                            string resul_busqueda = op_tex.busqueda_con_YY_profunda_texto(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], "" + num_column_comp, comparar);
                            string[] res_esp = resul_busqueda.Split(G_caracter_para_confirmacion_o_error[0][0]);
                            //encontro la informacion?
                            if (Convert.ToInt32(res_esp[0]) > 0)
                            {
                                if (res_esp[0] == "1")
                                {
                                    info_a_retornar = "-4" + G_caracter_para_confirmacion_o_error[0] + "la informacion ya existe";
                                    encotro_info = true;
                                    break;
                                }
                            }


                        }
                        //no encontro la info
                        if (encotro_info == false)
                        {
                            if (texto_a_agregar_si_no_esta != "")
                            {
                                Agregar(direccion_archivo, texto_a_agregar_si_no_esta);
                                info_a_retornar = "1" + G_caracter_para_confirmacion_o_error[0] + "agrego_la_informacion";
                            }
                            else
                            {
                                info_a_retornar = "-3" + G_caracter_para_confirmacion_o_error[0] + "no encontro el dato y no se puede agregar por que la variable texto_a_agregar_si_no_esta esta vacia";
                            }

                        }
                    }

                }

                else
                {
                    //no encontro archivo
                    if (res_esp_archivo[0] == "0")
                    {
                        info_a_retornar = "0" + G_caracter_para_confirmacion_o_error[0] + "no se encontro el archivo";
                    }
                    //solo encontro archivo y no esta en la lista
                    if (res_esp_archivo[0] == "-1")
                    {
                        bool esta = false;

                        string[] info_archivo = Leer(direccion_archivo);
                        if (info_archivo == null)
                        {
                            info_archivo = new string[] { "" };
                        }
                        for (int i = G_donde_inicia_la_tabla; i < info_archivo.Length; i++)
                        {
                            string[] columnas = info_archivo[i].Split(caracter_separacion[0][0]);

                            if (columnas[num_column_comp] == comparar)
                            {


                                //cambiar_archivo_con_arreglo(direccion_archivo, info_archivo);
                                info_a_retornar = "2" + G_caracter_para_confirmacion_o_error[0] + "se_agrego_al_archivo";
                                esta = true;
                                break;
                            }
                        }
                        if (esta == false)
                        {
                            Agregar_a_archivo_sin_arreglo(direccion_archivo, texto_a_agregar_si_no_esta);
                        }

                    }

                }

            }
            catch
            {


            }



            return info_a_retornar;
        }


        public string[] Editar_o_incr_espesifico_si_no_esta_agrega_linea(string direccion_archivo, int num_column_comp, string comparar, string numero_columnas_editar, string editar_columna, string edit_0_o_increm_1 = null, string linea_a_agregar_si_no_lo_encuentra = null, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            /*
            //---------------------------------------------------------------------------------------------------
            string[] dir_sep = extraer_separado_carpetas_nombreArchivo_extencion(direccion_archivo);
            dir_sep[0] = dir_sep[0] + "\\" + G_direccion_base_archivos_bandera;
            string dir_bandera = dir_sep[0] + "\\" + dir_sep[1] + "." + dir_sep[2];
            //este archivo bandera es para que no se agarre el archivo otro programa antes de sustituirlo
            dir_bandera = dir_bandera.Replace(".TXT", "_BANDERA.TXT");
            Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(dir_bandera, leer_y_agrega_al_arreglo: false);
            
            StreamWriter sw_bandera = null;
            bool esta_libre = false;
            while (esta_libre == false)
            {
                try
                {
                    sw_bandera = new StreamWriter(dir_bandera);
                    esta_libre = true;
                }
                catch { }
            }
            //------------------------------------------------------------------------------------------
            */
            int num_indice_de_direccion_int = Convert.ToInt32(sacar_indice_del_arreglo_de_direccion(direccion_archivo));
            try
            {



                bool se_encontro = false;
                for (int i = G_donde_inicia_la_tabla; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
                {
                    string[] columnas = GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i].Split(caracter_separacion[0][0]);

                    if (columnas[num_column_comp] == comparar)
                    {
                        se_encontro = true;
                        GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i] = op_arr.editar_incr_string_funcion_recursiva(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], numero_columnas_editar, editar_columna, edit_0_o_increm_1);

                        cambiar_archivo_con_arreglo(direccion_archivo, GG_base_arreglo_de_arreglos[num_indice_de_direccion_int]);
                        break;
                    }
                }
                if (se_encontro == false)
                {
                    if (linea_a_agregar_si_no_lo_encuentra != null)
                    {
                        Agregar(direccion_archivo, linea_a_agregar_si_no_lo_encuentra);
                    }

                }

                //sw_bandera.Close();
            }
            catch
            {
                //sw_bandera.Close();

            }



            return GG_base_arreglo_de_arreglos[num_indice_de_direccion_int];
        }


        public string cambiar_archivo_con_arreglo(string direccion_archivo, string[] arreglo, object caracter_separacion_objeto = null, object stream_reader_o_write = null)
        {
            string[] caracter_separacion = vf_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);


            string[] dir_sep = extraer_separado_carpetas_nombreArchivo_extencion(direccion_archivo);
            dir_sep[0] = dir_sep[0] + "\\" + G_direccion_base_archivos_bandera;
            string dir_bandera = dir_sep[0] + "\\" + dir_sep[1] + "." + dir_sep[2];
            //este archivo bandera es para que no se agarre el archivo otro programa antes de sustituirlo
            dir_bandera = dir_bandera + direccion_archivo.Replace(".TXT", "_BANDERA_CAA.TXT");
            Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(dir_bandera, leer_y_agrega_al_arreglo: false);

            StreamWriter sw_bandera = null;
            bool esta_libre = false;
            while (esta_libre == false)
            {
                try
                {
                    sw_bandera = new StreamWriter(dir_bandera);
                    esta_libre = true;
                }
                catch { }
            }
            //------------------------------------------------------------------------------------------




            string exito_o_fallo = "";
            string dir_tem = "tem.txt";
            StreamWriter sw = new StreamWriter(dir_tem, true);
            try
            {

                for (int i = 0; i < arreglo.Length; i++)
                {
                    sw.WriteLine(arreglo[i]);
                }
                exito_o_fallo = "1" + caracter_separacion[0] + "exito";
                sw.Close();

                sw_bandera.Close();
            }
            catch (Exception e)
            {

                exito_o_fallo = "2" + caracter_separacion[0] + "fallo" + caracter_separacion[0] + e;
                sw.Close();

                sw_bandera.Close();
            }


            File.Delete(direccion_archivo);//borramos el archivo original
            File.Move(dir_tem, direccion_archivo);//renombramos el archivo temporal por el que tenia el original

            return exito_o_fallo;
        }

        public string si_existe_suma_sino_agega_extra__SIN_ARREGLO(string direccion_archivo, int columna_a_comparar, string comparar, string numero_columnas_editar, string cantidad_a_sumar, string texto_a_agregar, char caracter_separacion = '|', bool los_valores_seam_menores_0 = true, string valor_inicial_si_crea_archivo = null, string[] filas_iniciales_si_crea_archivo = null)
        {
            /*
            //-------------------------------------------------------------------------------------------------
            string[] dir_sep = extraer_separado_carpetas_nombreArchivo_extencion(direccion_archivo);
            dir_sep[0] = dir_sep[0] + "\\" + G_direccion_base_archivos_bandera;
            string dir_bandera = dir_sep[0] + "\\" + dir_sep[1] + "." + dir_sep[2];
            //este archivo bandera es para que no se agarre el archivo otro programa antes de sustituirlo
            dir_bandera = dir_bandera.Replace(".TXT", "_BANDERA.TXT");
            Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(dir_bandera, leer_y_agrega_al_arreglo: false);

            StreamWriter sw_bandera = null;
            bool esta_libre = false;
            while (esta_libre == false)
            {
                try
                {
                    sw_bandera = new StreamWriter(dir_bandera);
                    esta_libre = true;
                }
                catch { }
            }
            //------------------------------------------------------------------------------------------

            */

            Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(direccion_archivo, valor_inicial_si_crea_archivo, filas_iniciales_si_crea_archivo, leer_y_agrega_al_arreglo: false);
            bool bandera = false;
            StreamReader sr = null;
            while (sr == null)
            {


                try
                {
                    sr = new StreamReader(direccion_archivo);

                }
                catch (Exception e)
                {
                    string[] checador = Leer(var_fun_GG.GG_direccion_control_errores_try);
                    chequeo_error_try(direccion_archivo, e, checador[1]);
                }
            }
            string dir_tem = direccion_archivo.Replace(".TXT", "_TEM.TXT");
            StreamWriter sw = new StreamWriter(dir_tem, true);
            string exito_o_fallo = null;
            int num_column_comp = 0;

            try
            {

                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {
                    string linea = sr.ReadLine();//leemos linea y lo guardamos en linea
                    if (linea != null)
                    {

                        string[] linea_espliteada = linea.Split(caracter_separacion);
                        if (linea_espliteada[columna_a_comparar] == comparar)
                        {
                            string[] num_col_spliteadas = numero_columnas_editar.Split(caracter_separacion);
                            string[] cantidad_spliteada = cantidad_a_sumar.Split(caracter_separacion);
                            for (int i = 0; i < num_col_spliteadas.Length; i++)
                            {
                                if (los_valores_seam_menores_0)
                                {
                                    linea_espliteada[Convert.ToInt32(num_col_spliteadas[i])] = "" + (Convert.ToDecimal(linea_espliteada[Convert.ToInt32(num_col_spliteadas[i])]) + Convert.ToDecimal(cantidad_spliteada[i]));
                                }
                                else
                                {
                                    linea_espliteada[Convert.ToInt32(num_col_spliteadas[i])] = "" + (Convert.ToDecimal(linea_espliteada[Convert.ToInt32(num_col_spliteadas[i])]) + Convert.ToDecimal(cantidad_spliteada[i]));
                                    double resultado = Convert.ToDouble(linea_espliteada[Convert.ToInt32(num_col_spliteadas[i])]);
                                    if (resultado < 0)
                                    {
                                        linea_espliteada[Convert.ToInt32(num_col_spliteadas[i])] = "0";
                                    }

                                }

                            }
                            linea = string.Join("|", linea_espliteada);
                            exito_o_fallo = linea;
                            bandera = true;
                        }

                        sw.WriteLine(linea);
                    }
                    num_column_comp++;
                }
                num_column_comp = 0;

                sr.Close();
                sw.Close();
                File.Delete(direccion_archivo);//borramos el archivo original
                File.Move(dir_tem, direccion_archivo);//renombramos el archivo temporal por el que tenia el original


                if (bandera == false)
                {
                    bandera = false;
                    Agregar(direccion_archivo, texto_a_agregar);
                }

                //sw_bandera.Close();

            }
            catch (Exception error)
            {
                sr.Close();
                sw.Close();
                exito_o_fallo = null;
                File.Delete(dir_tem);//borramos el archivo temporal

                //sw_bandera.Close();
            }
            return exito_o_fallo;
        }

        public string Editar_fila_espesifica_SIN_ARREGLO_GG(string direccion_archivo, int num_fila, string editar_info)
        {

            

            //------------------------------------------------------------------------------------------




            StreamReader sr = null;
            while (sr == null)
            {


                try
                {
                    sr = new StreamReader(direccion_archivo);

                }
                catch (Exception e)
                {
                    string[] checador = Leer(var_fun_GG.GG_direccion_control_errores_try);
                    chequeo_error_try(direccion_archivo, e, checador[1]);
                }
            }
            string dir_tem = direccion_archivo.Replace(".TXT", "_TEM.TXT");
            StreamWriter sw = new StreamWriter(dir_tem, true);
            string exito_o_fallo;

            try
            {
                int id_linea = 0;

                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {
                    string linea = sr.ReadLine();//leemos linea y lo guardamos en palabra
                    if (linea != null)
                    {

                        if (id_linea == num_fila)
                        {
                            sw.WriteLine(editar_info);

                        }
                        else
                        {
                            sw.WriteLine(linea);
                        }

                        id_linea++;
                    }
                }
                exito_o_fallo = "1)exito";
                sr.Close();
                sw.Close();
                File.Delete(direccion_archivo);//borramos el archivo original
                File.Move(dir_tem, direccion_archivo);//renombramos el archivo temporal por el que tenia el original

                
            }
            catch (Exception error)
            {
                sr.Close();
                sw.Close();
                exito_o_fallo = "2)error:" + error;
                File.Delete(dir_tem);//borramos el archivo original

            }
            return exito_o_fallo;
        }


        public string[] extraer_separado_carpetas_nombreArchivo_extencion(string direccion_archivo)
        {
            operaciones_textos op_tex = new operaciones_textos();
            string[] arreglo_retornar = new string[3];


            string[] direccion_esp = direccion_archivo.Split('\\');
            string[] nom_ext_esp = direccion_esp[direccion_esp.Length - 1].Split('.');
            if (nom_ext_esp.Length > 1)
            {
                string carpetas = op_tex.joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(direccion_archivo, '\\', 1);
                string nombre = nom_ext_esp[0];
                string extencion = nom_ext_esp[1];
                arreglo_retornar[0] = carpetas;
                arreglo_retornar[1] = nombre;
                arreglo_retornar[2] = extencion;
            }
            else
            {

            }


            return arreglo_retornar;
        }




        private string G_direccion_reg_modifiacion_archivo = "C:\\XEROX\\CONFIG\\REG\\REG_" + DateTime.Now.ToString("yyyyMMdd");
        private int posicion_registro = -1;
        public void actualisacion_archivo_para_multiples_programas()
        {
            string[] info_archivo = Leer(G_direccion_reg_modifiacion_archivo);
            if (posicion_registro == -1)
            {
                if (info_archivo != null)
                {
                    posicion_registro = info_archivo.Length - 1;
                }

            }

            if (info_archivo != null)
            {
                for (int i = posicion_registro + 1; i < info_archivo.Length; i++)
                {
                    string[] datos_para_actualisacion = info_archivo[i].Split(G_caracter_para_transferencia_entre_archivos[0][0]);

                    string indice_arreglo = sacar_indice_del_arreglo_de_direccion(datos_para_actualisacion[1]);
                    if (indice_arreglo != null)
                    {
                        GG_base_arreglo_de_arreglos[Convert.ToInt32(indice_arreglo)] = Leer(datos_para_actualisacion[1]);
                    }




                }
            }


        }


        public void chequeo_error_try(string direccionArchivo, Exception e, string numero_chequeo)
        {
            DialogResult result = MessageBox.Show(e.Message, e.Message + "\nError quieres crear el archivo sie es el error \"No\" para volver a intentar \"cancelar\" para cerrar el programa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(direccionArchivo, "sin informacion");
            }
            else if (result == DialogResult.No)
            {

            }
            else if (result == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }
        }

    }
}