using System;
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

        public MySqlConnection Conectar()
        {
            string server = "localhost";
            string database = "medivax";
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
            conex.Open();
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

     

        public void actualizar(string tabla, string campovalor, string campo, string id)
        {
            string consulta = "UPDATE `" + tabla + "` SET " + campovalor + " WHERE " + campo + " = '" + id + "'; ";
            Conectar();
            conex.Open();
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            MySqlDataReader ejecuta;
            ejecuta = comando.ExecuteReader();
            cerrar();
        }
    }

    
}
