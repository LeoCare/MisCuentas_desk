using MisCuentas_desk.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisCuentas_desk.Socket
{
    public class SocketConnect
    {

        public bool EnviarCorreoDesdeCliente(
            string titulo,
            DateTime? fecha_creacion,
            double? monto,
            string correo,
            string nombre,
            string asunto,
            string contenido)
        {
            bool exito = false;
            try
            {
                EmailRequest request = new EmailRequest
                {
                    Titulo = titulo,
                    Fecha_Creacion = fecha_creacion,
                    Monto = monto,
                    Correo = correo,
                    Nombre = nombre,
                    Asunto = asunto,
                    Contenido = contenido
                };

                string requestJson = JsonConvert.SerializeObject(request);

                TcpClient client = new TcpClient("localhost", 12345);
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = Encoding.UTF8.GetBytes(requestJson);
                    stream.Write(data, 0, data.Length);

                    // Leer la respuesta del servidor
                    byte[] responseBuffer = new byte[1024];
                    int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
                    string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                    if (response == "OK")
                    {

                        exito = true;
                    }
                    else
                    {

                        exito = false;
                    }
                }
                client.Close();
            }
            catch (Exception ex)
            {
                exito = false;
            }

            return exito;
        }
       

    }
}
