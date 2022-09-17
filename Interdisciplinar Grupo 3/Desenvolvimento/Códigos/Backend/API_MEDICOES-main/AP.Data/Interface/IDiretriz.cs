using AM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Interface
{
    public interface IDiretriz
    {
        public Task Cadastrar(Diretriz e);
        public List<Diretriz> Listar();
        public List<Diretriz> ListarPorId(string id);
        public Task Deletar(string id);
        public Task Alterar(Diretriz e);
    }
}
