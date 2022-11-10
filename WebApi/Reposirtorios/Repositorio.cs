using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace WebApi.Reposirtorios
{
    public class Repositorio : IRepositorios
    {
        private readonly BaseDeDatosSB _Basededatos;

        public Repositorio (BaseDeDatosSB baseDeDatos)
        {
            _Basededatos = baseDeDatos;
        }
        public Task<IEnumerable<BaseDeDatosSB>> Get()
        {
            throw new NotImplementedException();
        }

        public Task GetById(string Id)
        {
            return _Basededatos.Users.FirstOrDefaultAsync(x => x.Id.Equals(Id));
        }
    }
}
