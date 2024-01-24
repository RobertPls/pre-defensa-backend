using Domain.Models;
using SharedKernel.Core;

namespace Domain.Events
{

    public record NotificacionLanzada : DomainEvent
    {
        public string Empleado{ get; set; }
        public TipoNotificacion Tipo { get; set; }

        public NotificacionLanzada(string empleado, TipoNotificacion tipo) : base(DateTime.Now)
        {
            Empleado = empleado;
            Tipo = tipo;
        }
    }
}
