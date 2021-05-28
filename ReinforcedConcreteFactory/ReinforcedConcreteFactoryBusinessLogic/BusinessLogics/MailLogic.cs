using ReinforcedConcreteFactoryBusinessLogic.BindingModels;
using ReinforcedConcreteFactoryBusinessLogic.HelperModels;
using ReinforcedConcreteFactoryBusinessLogic.Interfaces;
using ReinforcedConcreteFactoryBusinessLogic.ViewModels;
using MailKit.Net.Pop3;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace ReinforcedConcreteFactoryBusinessLogic.BusinessLogics
{
    public class MailLogic
    {
        private static string smtpClientHost;
        private static int smtpClientPort;
        private static string mailLogin;
        private static string mailPassword;
        private readonly IMessageInfoStorage _messageInfoStorage;
        private readonly IClientStorage _clientStorage;
        public MailLogic(IMessageInfoStorage messageInfoStorage, IClientStorage
       clientStorage)
        {
            _messageInfoStorage = messageInfoStorage;
            _clientStorage = clientStorage;
        }
        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return _messageInfoStorage.GetFullList();
            }
            return _messageInfoStorage.GetFilteredList(model);
        }
        public void CreateMail(MessageInfoBindingModel model)
        {
            var client = _clientStorage.GetElement(new ClientBindingModel
            {
                Email = model.FromMailAddress
            });
            model.ClientId = client?.Id;
            _messageInfoStorage.Insert(model);
        }
        public static void MailConfig(MailConfig config)
        {
            smtpClientHost = config.SmtpClientHost;
            smtpClientPort = config.SmtpClientPort;
            mailLogin = config.MailLogin;
            mailPassword = config.MailPassword;
        }
        public static async void MailSendAsync(MailSendInfo info)
        {
            if (string.IsNullOrEmpty(smtpClientHost) || smtpClientPort == 0)
            {
                return;
            }
            
        if (string.IsNullOrEmpty(mailLogin) || string.IsNullOrEmpty(mailPassword))
            {
                return;
            }
            if (string.IsNullOrEmpty(info.MailAddress) ||
           string.IsNullOrEmpty(info.Subject) || string.IsNullOrEmpty(info.Text))
            {
                return;
            }
            using (var objMailMessage = new MailMessage())
            {
                using (var objSmtpClient = new SmtpClient(smtpClientHost,
               smtpClientPort))
                {
                    try
                    {
                        objMailMessage.From = new MailAddress(mailLogin);
                        objMailMessage.To.Add(new MailAddress(info.MailAddress));
                        objMailMessage.Subject = info.Subject;
                        objMailMessage.Body = info.Text;
                        objMailMessage.SubjectEncoding = Encoding.UTF8;
                        objMailMessage.BodyEncoding = Encoding.UTF8;
                        objSmtpClient.UseDefaultCredentials = false;
                        objSmtpClient.EnableSsl = true;
                        objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        objSmtpClient.Credentials = new NetworkCredential(mailLogin,
                        mailPassword);
                        await Task.Run(() => objSmtpClient.Send(objMailMessage));
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public static async void MailCheck(MailCheckInfo info)
        {
            if (string.IsNullOrEmpty(info.PopHost) || info.PopPort == 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(mailLogin) || string.IsNullOrEmpty(mailPassword))
            {
                return;
            }
            if (info.Storage == null)
            {
                return;
            }
            using (var client = new Pop3Client())
            {
                await Task.Run(() =>
                {
                    try
                {
                        client.Connect(info.PopHost, info.PopPort,
                       SecureSocketOptions.SslOnConnect);
                        client.Authenticate(mailLogin, mailPassword);
                        for (int i = 0; i < client.Count; i++)
                        {
                            var message = client.GetMessage(i);
                            foreach (var mail in message.From.Mailboxes)
                            {
                                info.Storage.Insert(new MessageInfoBindingModel
                                {
                                    DateDelivery = message.Date.DateTime,
                                    MessageId = message.MessageId,
                                    FromMailAddress = mail.Address,
                                    Subject = message.Subject,
                                    Body = message.TextBody,
                                    ClientId = info.ClientStorage.GetElement(new ClientBindingModel { Email = mail.Address})?.Id
                                });
                            }
                        }
                    }
                    finally
                    {
                        client.Disconnect(true);
                    }
                });
            }
        }

    }
}
