using ProducaoTematicaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProducaoTematicaAPI.Services
{
    public interface ISistemasService
    {
        Task<IEnumerable<Sistema>> RecuperaSistemas();
        Task<Sistema> RecuperaSistema(int sistemaId);
        Task<IEnumerable<Sistema>> RecuperaSistemaPorNome(string nome);
        Task AdicionaSistema(Sistema sistema);
        Task EditaSistema (Sistema sistema);
        Task ExcluiSistema (Sistema sistema);
    }
}
