using DesafioBoltons.Domain.DTOs;
using System.Threading.Tasks;

namespace DesafioBoltons.Domain.Interfaces
{
    public interface INFeService
    {
        Task<NFeDTO> BuscarTodos(BuscarNFeDTO model);
        void Adicionar(AdicionarNFeDTO model);
    }
}
