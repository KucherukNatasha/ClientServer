using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;

namespace Client.Models
{
    public class SocketClient
    {
       public Object KlientPostGet(string request)
        {
            Object obj;
            // Инициализация
            TcpClient client = new TcpClient("127.0.0.1", 1000);
            Byte[] data = Encoding.UTF8.GetBytes(request);
            NetworkStream stream = client.GetStream();
            try
            {
                // Отправка сообщения
                stream.Write(data, 0, data.Length);
                // Получение ответа
                Byte[] readingData = new Byte[100000];
                String responseData = String.Empty;
                StringBuilder completeMessage = new StringBuilder();
                int numberOfBytesRead = 0;
                do
                {
                  numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                  string res=Encoding.UTF8.GetString(readingData, 0, numberOfBytesRead);
                  obj = (Object)JsonConvert.DeserializeObject(res); 
                   
                }
                    while (stream.DataAvailable);
                    responseData = completeMessage.ToString();
                   
                }
                finally
                {
                    stream.Close();
                    client.Close();
                }
            return obj;
        }
        

    }
}
