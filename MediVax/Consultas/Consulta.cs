﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MediVax.Consultas
{
    internal class Consulta
    {
        private MySqlConnection conex;
        public MySqlConnection Conexion => conex;
        public MySqlConnection Conectar()
        {
            string server = "localhost";
            string database = "medivx";
            string user = "root";
            string pwd = "root";
            string cadenaConexion = $"server={server};database={database};Uid={user};pwd={pwd};";

            conex = new MySqlConnection(cadenaConexion);
            conex.Open();
            return conex;
        }
        public void cerrar()
        {
            conex.Close();
        }

        
        public void agregar(string tabla, string campos, string valores)
        {
            string consulta = "INSERT INTO `" + tabla + "` (" + campos + ") VALUES (" + valores + ")";
            Conectar();
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            MySqlDataReader ejecuta;
            ejecuta = comando.ExecuteReader();
            cerrar();
        }

     

        public MySqlDataReader leer(string tabla)
        {
            string consulta = "SELECT * FROM `" + tabla + "`;";
            Conectar();
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            return comando.ExecuteReader();
        }



        public MySqlDataReader busca(string tabla, string campo, string buscar)
        {
            string consulta = "SELECT * FROM `" + tabla + "` WHERE " + campo + " LIKE '%" + buscar + "%';";
            Conectar();
            conex.Open();
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            return comando.ExecuteReader();

        }



        public void actualizar(string tabla, string campovalor, string campo, string ID)
        {
            try
            {
                string consulta = $"UPDATE `{tabla}` SET {campovalor} WHERE {campo} = '{ID}'";
                Conectar();
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    MessageBox.Show("No se encontró el registro a actualizar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
            finally
            {
                cerrar();
            }
        }

        public void eliminar(string tabla, string campo, string id)
        {
            string consulta = $"DELETE FROM `{tabla}` WHERE {campo} = '{id}'";
            Conectar();
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            comando.ExecuteNonQuery();
            cerrar();
        }




    }


}
