using Newtonsoft.Json;
using Serv.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Server
{
    class SocketServer
    {
        ClassSQLDatabase myDatabase;
        public SocketServer()
        {
           InitialConect();
        }
        private void InitialConect()
        {
            myDatabase = new ClassSQLDatabase();
            myDatabase.OpenCloseDataBase(true);

            if (myDatabase.databaseConnectionState != enumDatabaseConnectionsState.Open)
            {
                string s = "";
                switch (myDatabase.databaseConnectionState)
                {
                    case enumDatabaseConnectionsState.PingFailed:
                        {
                            s = "Немає зв'язку з сервером\n" + myDatabase.strIPAddressServer;
                            break;
                        }
                    default:
                        {
                            s = "Помилка підключення до бази даних\n";
                            break;
                        }
                }
                ErrorMsg(s);
                Environment.Exit(2);
            }


        }
        private static void ErrorMsg(string strMess) //Ошибка соединения с базой
        {
            MessageBox.Show(strMess, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ServerListen(DataSet dataSet)
        {
            string[] reqestArr;
            // Инициализация
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(localAddr, 1000);
            // Запуск в работу
            server.Start();
            // Бесконечный цикл
            Task FreeInterf = Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        // Подключение клиента
                        TcpClient client = server.AcceptTcpClient();
                        NetworkStream stream = client.GetStream();
                        // Обмен данными
                        try
                        {
                            if (stream.CanRead)
                            {
                                byte[] myReadBuffer = new byte[100000];
                                StringBuilder myCompleteMessage = new StringBuilder();
                                do
                                {
                                    int numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                                    string requestVal = Encoding.UTF8.GetString(myReadBuffer, 0, numberOfBytesRead);
                                    reqestArr = requestVal.Split('&');
                                }
                                while (stream.DataAvailable);
                                if (reqestArr[0] == "GET")
                                {
                                    SelectData(stream, dataSet);
                                }
                                else
                                {
                                    InsertData(reqestArr[1], reqestArr[2]);
                                }
                            }
                        }
                        finally
                        {
                            stream.Close();
                            client.Close();
                        }
                    }
                    catch
                    {
                        server.Stop();
                        break;
                    }

                }
            }
            );
          
         
        }
        void SelectData(NetworkStream stream, DataSet dataSet)
        {
            ClassDataSet classDataSet = new ClassDataSet(myDatabase.databaseConnection);
            classDataSet.FillDataSet(dataSet, 0, "Select * From PERSONS_DATA");
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            Byte[] responseData = Encoding.UTF8.GetBytes(json);
            stream.Write(responseData, 0, responseData.Length);

        }



        void InsertData(string reqName, string reqPhone)
        {
            string[] name= reqName.Split('=');
            string[] phone= reqPhone.Split('=');
            ClassDataSet classDataSet = new ClassDataSet(myDatabase.databaseConnection);
            classDataSet.PostDataSet($"INSERT INTO PERSONS_DATA VALUES ({"'" + name[1] + "'"}, {phone[1]})");

        }


    }
}
