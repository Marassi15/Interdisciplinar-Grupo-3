using AM.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AM.Data.Interface
{
    public interface IMedida
    {
        public Task Cadastrar(Medida r);
        public List<Medida> Listar();
        public List<Medida> ListarPorId(int id);
        public Task Deletar(decimal id);
        public Task Alterar(Medida p);
    }
}
