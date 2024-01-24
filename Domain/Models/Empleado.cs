using Domain.Events;
using SharedKernel.Core;

namespace Domain.Models
{
    public class Empleado : AggregateRoot<Guid>
    {
        public string Nombre { get; private set; }
        public string Apellidop { get; private set; }
        public string Apellidom { get; private set; }


        public Empleado(string nombre, string apellidop, string apellidom)
        {


            Id = Guid.NewGuid();
            Nombre = nombre;
            Apellidop = apellidop;
            Apellidom = apellidom;
        }

        public Empleado() { }

        public void Notificar(TipoNotificacion tipo)
        {
            AddDomainEvent(new NotificacionLanzada(Nombre+" "+Apellidop+" "+Apellidom, tipo));
        }
    }
}
