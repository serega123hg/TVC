using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using System.Net;
using System.Net.Mail;


namespace PracticaTest2
{
    public class EmailSender : IJob
    {

        public async Task Execute(IJobExecutionContext context)


        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("Почта отправителя", "Tom");
            // кому отправляем
            MailAddress to = new MailAddress("Почта получателя");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("Почта отправителя", "Пароль отправителя");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);





            //using (MailMessage message = new MailMessage("admin@yandex.ru", "user@yandex.ru"))
            //{
            //    message.Subject = "Новостная рассылка";
            //    message.Body = "Новости сайта: бла бла бла";
            //    using (SmtpClient client = new SmtpClient
            //    {
            //        EnableSsl = true,
            //        Host = "smtp.yandex.ru",
            //        Port = 25,
            //        Credentials = new NetworkCredential("admin@yandex.ru", "password")
            //    })
            //    {
            //        await client.SendMailAsync(message);
            //    }
            //}
        }
    }
}
