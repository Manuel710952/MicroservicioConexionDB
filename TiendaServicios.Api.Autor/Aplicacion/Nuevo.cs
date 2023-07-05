using MediatR;
using System.Globalization;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest { 
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta>
        {

            public readonly ContextAutor _contexto;

            public Manejador(ContextAutor contexto) {
                _contexto = contexto;
            }

            public async Task Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var AutorLibro = new AutorLibro {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid = Convert.ToString(Guid.NewGuid())
                };
                _contexto.AutorLibro.Add(AutorLibro);
                var valor = await _contexto.SaveChangesAsync();
                if (valor > 0) return;

                throw new Exception("");
            }

           
        }
    }
}
