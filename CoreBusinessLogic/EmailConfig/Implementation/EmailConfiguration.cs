using Configuration.EmailConfig.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.EmailConfig.Implementation
{
    public class EmailConfiguration : IEmailConfiguration
    {
        //C# 6.0 - Setting default values to Auto Properties
        public string SmtpServer { get; set; } = "smtp.gmail.com";
        public int SmtpPort { get; set; } = 587;
        public string SmtpUsername { get; set; } = "ramakrishna.public@gmail.com";
        public string SmtpPassword { get; set; } = "9880205856";
        //To recive emails from server
        public string PopServer { get; set; } = "pop.gmail.com";
        public int PopPort { get; set; } = 995;
        public string PopUsername { get; set; } = "ramakrishna.public@gmail.com";
        public string PopPassword { get; set; } = "9880205856";
    }
}
