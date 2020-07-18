using DesafioBoltons.Domain.Entities;
using DesafioBoltons.Domain.Interfaces;
using DesafioBoltons.Infa.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBoltons.Infa.Data.Repository
{
    public class NFeRepository : BaseRepository<NFeEntity, int>, INFeRepository
    {
        public NFeRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }

        public async Task<NFeEntity> BuscarPorId(int id) => base.Select().Where(w => w.ID == id).FirstOrDefault();
        
        public async Task<NFeEntity> BuscarTodos(string chave) => base.Select().Where(w => w.Access_key == chave).FirstOrDefault();

        public async Task<int> Adicionar(NFeEntity item)
        {
            base.Insert(item);
            return item.ID;
        }
    }
}
