using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BibliotecaDeClases
{
    class Nodo<T>
    {
        public Nodo(int padre)
        {
            if (padre == 0)
            {
                cantV = DatosArboles.Instance.Grado - 1;
            }
            else
            {
                cantV = DatosArboles.Instance.Grado - 1;
            }

            this.Padre = padre;
        }
       
        public int indice;

        public int Padre;

        public int cantV;

        public List<int> Hijos = new List<int>();

        public List<T> Valores = new List<T>();

        static string path = Path.Combine(Environment.CurrentDirectory + "\\arbol.txt");
       
        public static Nodo<T> StringToNodo(int posicion)
        {
            var cantHijos = DatosArboles.Instance.Grado;
            var cantCaracteres = 10 + (5 * cantHijos) + (611 * (cantHijos - 1));
            //Lee la linea de archivo de texto que contiene el nodo
            var buffer = new byte[cantCaracteres];
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                fs.Seek((posicion - 1) * cantCaracteres + 15, SeekOrigin.Begin);
                fs.Read(buffer, 0, cantCaracteres);
            }
            var nodeString = Encoding.UTF8.GetString(buffer);

            //Divide los valores para llenar el nodo que se va a utilizar
            var values = nodeString.Split('|');
            var NodoSalida = new Nodo<T>(Convert.ToInt32(values[1]));

            NodoSalida.indice = Convert.ToInt32(values[0]);
            for (int i = 2; i < (2 + cantHijos); i++)
            {
                if (values[i].Trim() != "-")
                {
                    NodoSalida.Hijos.Add(Convert.ToInt32(values[i]));
                }
            }

            for (int i = (2 + cantHijos); i < (1 + (2 * cantHijos)); i++)
            {
                if (values[i].Trim() != "-")
                {
                    NodoSalida.Valores.Add((T)DatosArboles.Instance.ObtenerNodo.DynamicInvoke(values[i]));
                }
            }

            return NodoSalida;
        }
        public void NodoToString()
        {
            string hijos = string.Empty;
            string datos = string.Empty;

            var cantHijos = DatosArboles.Instance.Grado;

            foreach (var item in Hijos)
            {
                hijos = $"{hijos}|{item.ToString("0000;-0000")}";
            }
            for (int i = Hijos.Count; i < cantHijos; i++)
            {
                hijos = $"{hijos}|{string.Format("{0,-4}", "-")}";
            }

            foreach (var item in Valores)
            {
                datos = $"{datos}|{Convert.ToString(DatosArboles.Instance.ObtenerString.DynamicInvoke(item))}";
            }

            for (int i = Valores.Count; i < (cantHijos - 1); i++)
            {
                datos = $"{datos}|{string.Format("{0,-610}", "-")}";
            }

            var NodoChar = ($"{indice.ToString("0000;-0000")}|{Padre.ToString("0000;-0000")}{hijos}{datos}|").ToCharArray();
            var p1 = NodoChar.Length;
            var cantCaracteres = 10 + (5 * cantHijos) + (611 * (cantHijos - 1));

            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                fs.Seek((indice - 1) * cantCaracteres + 15, SeekOrigin.Begin);
                fs.Write(Encoding.UTF8.GetBytes(NodoChar), 0, cantCaracteres);
            }
        }
        

    }
}
