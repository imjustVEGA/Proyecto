﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MediVax.Sesion
{
    public static class Sesion
    {
        public static int UsuarioID { get; set; }

        public static void CerrarSesion()
        {
            UsuarioID = 0;
        }
    }
}
