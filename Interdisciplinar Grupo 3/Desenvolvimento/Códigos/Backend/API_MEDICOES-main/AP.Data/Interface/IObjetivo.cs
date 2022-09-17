using AM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Interface
{
    public interface IObjetivo
    {
        public Task Cadastrar(Objetivo p);
        public List<Objetivo> Listar();
        public List<Objetivo> ListarPorId(int id);
        public Task Deletar(decimal id);
        public Task Alterar(Objetivo p);
    }
}
