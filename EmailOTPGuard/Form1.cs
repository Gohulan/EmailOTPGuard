using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace EmailOTPGuard
{
    public partial class Form1 : Form
    {
        private string otp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Generate OTP
            otp = GenerateOTP();

            // Send OTP via email
            string email = textBox1.Text;
            SendEmail(email, "OTP for email verification", $"Your OTP is: {otp}");

            MessageBox.Show("OTP sent to email!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verify OTP
            string enteredOTP = textBox2.Text;
            if (enteredOTP == otp)
            {
                label1.Text = "Verified";
            }
            else
            {
                label1.Text = "Wrong code";
            }
        }

        private string GenerateOTP()
        {
            // Generate 4-digit OTP
            Random random = new Random();
            int otpValue = random.Next(1000, 9999);
            return otpValue.ToString();
        }

        private void SendEmail(string to, string subject, string body)
        {
            // Configure SMTP client with Gmail credentials
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("gohulan.work@gmail.com", "zyahiebftyijbrxr");

            // Create email message
            MailMessage message = new MailMessage("gohulan.work@gmail.com", to, subject, body);

            try
            {
                // Send email
                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
            }
        }

        
        }
    }
