using Domain.Events;
using Domain.Models;
using MediatR;
using SharedKernel.Core;
using System.Net;
using System.Net.Mail;

namespace Application.UseCase.EventHandlers
{
    public class EnviarNotificacionEmailHandler : INotificationHandler<NotificacionLanzada>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnviarNotificacionEmailHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(NotificacionLanzada notification, CancellationToken cancellationToken)
        {

            MailAddress to = new MailAddress("a@yopmail.com");  
            MailAddress from = new MailAddress("b@gmail.com"); // 

            MailMessage email = new MailMessage(from, to);
            string subject = "";
            string body = "";

            if (notification.Tipo == TipoNotificacion.AccesoDenegado)
            {
                subject = "Intento de acceso no autorizado";
                body = "El " + notification.Empleado + " intentó un acceso no autorizado.";
            }

            if (notification.Tipo == TipoNotificacion.Ausencia)
            {
                subject = "Ausencia";
                body = "El " + notification.Empleado + " no se presento en las instalaciones en su horario.";
            }

            if (notification.Tipo == TipoNotificacion.Sobrecarga)
            {
                subject = "Sobrecarga";
                body = "El " + notification.Empleado + " presenta una sobrecarga en sus labores.";
            }

            email.Subject = subject;
            email.Body = body;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; 
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("a@gmail.com", "a"); 
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

                smtp.Send(email);
            System.Diagnostics.Debug.WriteLine("email enviado");
        }
    }
}

