using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorLibro>> { 
            
        }
        public class Manejador : IRequestHandler<ListaAutor,List<AutorLibro>>
        {
            private readonly ContextAutor _contexto;
            public Manejador(ContextAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<List<AutorLibro>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                try
                {
                    var autores = await _contexto.AutorLibro.ToListAsync();
                    return autores;
                }
                catch (Exception e) {
                    throw new Exception("error::"+ e.Message);
                }
                
               
               // throw new NotImplementedException();
            }
        }
    }
}
