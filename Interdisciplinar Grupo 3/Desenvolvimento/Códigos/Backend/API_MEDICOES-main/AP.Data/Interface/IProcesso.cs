using AM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Interface
{
    public interface IProcesso
    {
        public Task Cadastrar(Processo a);
        public List<Processo> Listar();
        public List<Processo> ListarPorId(string id);
        public Task Deletar(string id);
        public Task Alterar(Processo a);
    }
}
