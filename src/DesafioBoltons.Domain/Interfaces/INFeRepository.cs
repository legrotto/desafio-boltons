using DesafioBoltons.Domain.Entities;
using System.Threading.Tasks;

namespace DesafioBoltons.Domain.Interfaces
{
    public interface INFeRepository
    {
        Task<NFeEntity> BuscarTodos(string chave);
        Task<NFeEntity> BuscarPorId(int id);
        Task<int> Adicionar(NFeEntity obj);
    }
}
