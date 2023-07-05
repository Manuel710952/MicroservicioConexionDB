using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class ConsultaFiltro
    {
        public class AutorUnico:IRequest<AutorLibro> { 
            public string AutorGuid { get; set; }
        
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorLibro>
        {
            private readonly ContextAutor _contexto;
            public Manejador(ContextAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<AutorLibro> Handle(AutorUnico request, CancellationToken cancellationToken) {
                var autor = await _contexto.AutorLibro.Where(x => x.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();
                if (autor == null)
                {
                    throw new Exception("No se encontro el registro");
                }
                return autor;
            }

        }
    }
}
