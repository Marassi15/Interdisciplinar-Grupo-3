using AM.Data.Interface;
using AM.Data.Utiil;
using AM.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Persistence
{
    public class ProcessoPersistence : DAL, IProcesso
    {
        public Task Cadastrar(Processo a)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT ISNULL(MAX(CD_PROC + 1), 1) FROM PROCESSO", Con);
            int cd_ultimo = Convert.ToInt32(Cmd.ExecuteScalar());

            Cmd = new SqlCommand("INSERT INTO PROCESSO VALUES(@CD_PROC, @TITULO_PROC)", Con);
            Cmd.Parameters.AddWithValue("@CD_PROC", cd_ultimo);
            Cmd.Parameters.AddWithValue("@TITULO_PROC", a.titulo_proc.ToUpper());
            
            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<Processo> Listar()
        {
            OpenConnection();

            List<Processo> lista = new List<Processo>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM PROCESSO", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Processo()
                {
                    cd_proc = Dr["CD_PROC"].ToString(),
                    titulo_proc = Dr["TITULO_PROC"].ToString()                  
                });
            }

            return lista;
        }

        public List<Processo> ListarPorId(string id)
        {
            OpenConnection();

            List<Processo> lista = new List<Processo>();

            Cmd = new SqlCommand("SELECT * FROM PROCESSO WHERE CD_PROC = @CD_PROC", Con);
            Cmd.Parameters.AddWithValue("@CD_PROC", id);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Processo()
                {
                    cd_proc = Dr["CD_PROC"].ToString(),
                    titulo_proc = Dr["TITULO_PROC"].ToString()
                });
            }

            return lista;
        }
        public Task Deletar(string id)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM PROCESSO WHERE CD_PROC = @ID", Con);
            Cmd.Parameters.AddWithValue("@ID", id);
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM PROCESSO WHERE CD_PROC = @ID", Con);
                Cmd.Parameters.AddWithValue("@ID", id);

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Processo não encontrado!");

            return Task.CompletedTask;
        }

        public Task Alterar(Processo a)
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE PROCESSO SET CD_PROC = @CD_PROC, TITULO_PROC = @TITULO_PROC WHERE CD_PROC = @CODIGO", Con);
            Cmd.Parameters.AddWithValue("@CODIGO", a.cd_proc);
            Cmd.Parameters.AddWithValue("@TITULO_PROC", a.titulo_proc);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
