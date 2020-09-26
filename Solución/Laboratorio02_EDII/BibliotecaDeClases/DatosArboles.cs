using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaDeClases
{
    public class DatosArboles
    {
        private static DatosArboles _instance = null;
        public static DatosArboles Instance
        {
            get
            {
                if (_instance == null) _instance = new DatosArboles();
                return _instance;
            }
        }

        public int Grado;
        public Delegate ObtenerNodo;
        public Delegate ObtenerString;
    }
}
