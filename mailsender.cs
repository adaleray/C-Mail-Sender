using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

public class EmailSender
{
    private static string senderEmail = "mail@gmail.com";
    private static string emailPassword = "mailapppassword";
    private static string yurtAdi = "name";
    private static string yurtTelNo = "number";

    public static void GonderEmailTekli(string email, string konu, string mesaj)
    {
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(senderEmail, emailPassword),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(senderEmail),
            Subject = konu,
            Body = mesaj,
            IsBodyHtml = false,
        };
        mailMessage.To.Add(email);

        try
        {
            smtpClient.Send(mailMessage);
            MessageBox.Show(email + " adresine mail gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Text alanlarını temizlemek için
            // aramaText.Text = "";
            // textField.Text = "";
            // basliktextfield.Text = "";
            // textArea.Text = "";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Mail gönderilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Örnek çağrı
        GonderEmailTekli("example@example.com", "Konu", "Mesaj içeriği");
    }
}
