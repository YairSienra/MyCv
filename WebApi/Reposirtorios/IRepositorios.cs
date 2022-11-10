using Persistencia;

namespace WebApi.Reposirtorios
{
    public interface IRepositorios
    {
        Task GetById(string Id);

        Task<IEnumerable<BaseDeDatosSB>> Get();
    }
}
