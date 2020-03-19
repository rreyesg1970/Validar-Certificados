using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Validar_Certificados
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"C:\Tmp";
            string certificado = "119200302624.p12";
            string rutaCompleta = @"C:\Tmp\" + certificado; 
            string pswd = "1018";
           
            X509Certificate2 cert = new X509Certificate2(rutaCompleta, pswd);

            if (cert.NotAfter > DateTime.Now)

            {
                Console.Write("Certificado válido.Vencimiento: " + cert.NotAfter.ToString("dd-MM-yyyy HH: mm:sszzz"));

                string certificadoVenta = cert.NotAfter.ToString("dd-MMMM-yyyy HH: mm:sszzz");
                string FechaCertificado = ruta + "\\" + "FechaCertificado.txt";
                StreamWriter flujoSalidaVenta = File.CreateText(FechaCertificado);
                flujoSalidaVenta.Write(certificadoVenta);
                flujoSalidaVenta.Close();
            }
            else
            {
                Console.Write("Certificado inválido");
            }
            Console.ReadKey();
        }
    }
}
