using System;
using System.IO; //se debe agregar esta using
using System.Text;



namespace LeerEscribir 
{
    class Program
    {
        static void Main(string[] args)
        {
            //La palabra reservada using nos permite crear un bloque de código seguro
            //con finalización de recursos no manejados, es decir, el archivo abierto
            //se cierra solo ante cualquier evento

            //Abro el archivo con acceso de escritura
            using (Stream fs = new FileStream("./Agenda.txt", FileMode.Append, FileAccess.Write))
            {
                string texto;

                Console.WriteLine("Escriba el texto para el archivo:");
                texto = Console.ReadLine();

                using (StreamWriter sw = new StreamWriter(fs)) // Creo el objeto StreamWriter
                {
                    sw.WriteLine(texto); // escribo el contenido de la variable en una linea del archivo
                }
            }   

            //En este caso estariamos abriendo el archivo sin utilizar la palabra reservada using
            //si observan debemos si o si cerrar el archivo al terminar de utilizarlo

            
            Console.WriteLine(""); //imprimo en consola una linea en blanco
            Console.WriteLine("LECTURA DEL ARCHIVO"); //Imprimo un titulo

            StreamReader sr = new StreamReader("./Agenda.txt");//abro el archivo en modo lectura
            while (!sr.EndOfStream) //mientras no sea el final del archivo
            {
                Console.WriteLine(sr.ReadLine()); // imprimo en pantalla cada linea
            }
            sr.Close(); //fundamental cerrar el archivo
            Console.ReadKey();
        }
    }

}