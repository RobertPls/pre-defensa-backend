using Domain.Events;
using MediatR;
using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.EventHandlers
{
    public class EnviarNotificacionSmsHandler : INotificationHandler<NotificacionLanzada>
    {
        public EnviarNotificacionSmsHandler()
        {
        }

        public async Task Handle(NotificacionLanzada notification, CancellationToken cancellationToken)
        {     
            System.Diagnostics.Debug.WriteLine("sms enviado");
        }
    }
}
