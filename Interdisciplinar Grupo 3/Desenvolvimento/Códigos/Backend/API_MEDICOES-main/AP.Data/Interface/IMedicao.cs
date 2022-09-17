using AM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Interface
{
    public interface IMedicao
    {
        public Task Cadastrar(Medicao p);
        public List<Medicao> Listar();
        public List<Medicao> ListarPorId(string id);
        public Task Deletar(string id);
        public Task Alterar(Medicao p);
    }
}
