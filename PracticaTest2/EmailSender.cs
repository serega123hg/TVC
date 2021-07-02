﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;


namespace PracticaTest2
{
    public class EmailSender : IJob
    {

        public async Task Execute(IJobExecutionContext context)

        {
            try { 
                // Буфер для входящих данных
                byte[] bytes = new byte[1024];

                // Соединяемся с удаленным устройством

                // Устанавливаем удаленную точку для сокета
                IPHostEntry ipHost = Dns.GetHostEntry("localhost");
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

                Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Соединяем сокет с удаленной точкой
                sender.Connect(ipEndPoint);

                string message = "3";
                //Console.Write("Введите сообщение: ");
                //if (number == 1)
                //{
                //    message = "1 " + Properties.Settings.Default.email;
                //}
                //else if (number == 2)
                //{
                //    message = "2 " + "Server=" + Properties.Settings.Default.serverAddress + ";Database=" + Properties.Settings.Default.dbname + ";User Id=" + Properties.Settings.Default.login + ";Password=" + Properties.Settings.Default.password;
                //}
                //else if (number == 3)
                //{
                //    message = "3";
                //}

                Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
                byte[] msg = Encoding.UTF8.GetBytes(message);

                // Отправляем данные через сокет
                int bytesSent = sender.Send(msg);

                // Получаем ответ от сервера
                int bytesRec = sender.Receive(bytes);
                if (Encoding.UTF8.GetString(bytes, 0, bytesRec) == "good")
                {
                    Properties.Settings.Default.working = "Работает";
                    Properties.Settings.Default.Save();
                }
                Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));

                // Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch
            {
                Properties.Settings.Default.working = "Не работает";
                Properties.Settings.Default.Save();
            }

        }
    }
}
