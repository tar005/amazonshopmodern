﻿using Ecommerce.Application.Contracts.Infraestructure;
using Ecommerce.Application.Models.Email;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infraestructure.MessageImplementation
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(EmailMessage email, string token)
        {
            try
            {
                var client = new SendGridClient(_emailSettings.Key);
                var from = new EmailAddress(_emailSettings.Email);
                var subject = email.Subject;
                var to = new EmailAddress(email.To, email.To);

                var plainTextContext = email.Body;
                var htmlContent = $"{email.Body} {_emailSettings.BaseUrlClient}/password/reset/{token}";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContext, htmlContent);
                var response = await client.SendEmailAsync(msg);

                return response.IsSuccessStatusCode;
            }
            catch (Exception) {
                _logger.LogError("El email no pudo enviarse, existen errores");
                return false;
            }
        }
    }
}
