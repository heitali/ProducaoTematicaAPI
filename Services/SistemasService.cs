using ProducaoTematicaAPI.Context;
using ProducaoTematicaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using NuGet.Protocol;

namespace ProducaoTematicaAPI.Services
{
    public class SistemasService : ISistemasService
    {
        private readonly AppDbContext _context;

        public SistemasService(AppDbContext context)
        {
            this._context = context;
        }

        public async Task AdicionaSistema(Sistema sistema)
        {
            this._context.Sistemas.Add(sistema);
            await this._context.SaveChangesAsync();
        }

        public async Task EditaSistema(Sistema sistema)
        {
            this._context.Entry(sistema).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }

        public async Task ExcluiSistema(Sistema sistema)
        {
            this._context.Sistemas.Remove(sistema);
            await this._context.SaveChangesAsync();
        }

        public async Task<Sistema> RecuperaSistema(int SistemaId)
        {
            var sistema = await this._context.Sistemas.FindAsync(SistemaId);
            return sistema;
        }

        public async Task<IEnumerable<Sistema>> RecuperaSistemas()
        {
            try
            {
                return await this._context.Sistemas.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Sistema>> RecuperaSistemaPorNome(string nome)
        {
            IEnumerable<Sistema> sistemas;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                sistemas = await this._context.Sistemas.Where(n => n.SISTEMA.Contains(nome)).ToListAsync();
            }
            else
            {
                sistemas = await RecuperaSistemas();
            }
            return sistemas;
        }
    }
}
