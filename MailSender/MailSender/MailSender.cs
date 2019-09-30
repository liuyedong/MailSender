using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CC.ERP.BLL.Message
{
    public static class MailSender
    {
        
        /// <summary>
        /// 发送邮件方法
        /// </summary>
        /// <param name="title">邮件标题</param>
        /// <param name="content">邮件内容</param>
        /// <param name="mailsender">发送邮件地址</param>
        /// <param name="mailaccepter">接收邮件地址多个以，号隔开</param>
        /// <param name="hostserer">发送服务器地址</param>
        /// <param name="authcode">pop smtp授权码,或者密码</param>
        public static void SendMailMessage(string title, string content, string mailsender = "", string mailaccepter = "", string hostserver = "", string authcode = "")
        {
            try
            {
                ///"oiwjnmuqsvpcbhgh"
                var receivelist = mailaccepter.Split(',');

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(mailsender);
                foreach (var adds in receivelist)
                {
                    mailMessage.To.Add(new MailAddress(adds));
                }
                //邮件标题。
                mailMessage.Subject = title;
                //邮件内容。
                mailMessage.Body = content;
                SmtpClient client = new SmtpClient();
                client.Host = hostserver;
                if (hostserver.IndexOf("qq.com") > -1)
                {
                    //使用安全加密连接。
                    client.EnableSsl = true;
                }

                //不和请求一块发送。
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mailsender, authcode);
                //发送

                client.Send(mailMessage);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
