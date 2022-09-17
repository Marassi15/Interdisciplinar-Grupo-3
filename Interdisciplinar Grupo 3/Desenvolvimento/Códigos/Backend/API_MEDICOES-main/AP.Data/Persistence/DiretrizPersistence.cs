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
    public class DiretrizPersistence : DAL, IDiretriz
    {
        public Task Cadastrar(Diretriz a)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT ISNULL(MAX(CD_DIR + 1), 1) FROM DIRETRIZ", Con);
            int cd_ultimo = Convert.ToInt32(Cmd.ExecuteScalar());

            Cmd = new SqlCommand("INSERT INTO DIRETRIZ VALUES(@CD_DIR, @TITULO_DIR, @RESUMO_DIR)", Con);
            Cmd.Parameters.AddWithValue("@CD_DIR", cd_ultimo);
            Cmd.Parameters.AddWithValue("@TITULO_DIR", a.titulo_dir.ToUpper());
            Cmd.Parameters.AddWithValue("@RESUMO_DIR", a.resumo_dir.ToUpper());

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<Diretriz> Listar()
        {
            OpenConnection();

            List<Diretriz> lista = new List<Diretriz>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM DIRETRIZ", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Diretriz()
                {
                    cd_dir = Dr["CD_DIR"].ToString(),
                    titulo_dir = TratamentoNull.CheckNullFromDB<string>(Dr["TITULO_DIR"]),
                    resumo_dir = TratamentoNull.CheckNullFromDB<string>(Dr["RESUMO_DIR"])
                });
            }

            return lista;
        }

        public List<Diretriz> ListarPorId(string id)
        {
            OpenConnection();

            List<Diretriz> lista = new List<Diretriz>();

            Cmd = new SqlCommand("SELECT * FROM DIRETRIZ WHERE CD_DIR = @CD_DIR", Con);
            Cmd.Parameters.AddWithValue("@CD_DIR", id);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Diretriz()
                {
                    cd_dir = Dr["CD_PROC"].ToString(),
                    titulo_dir = TratamentoNull.CheckNullFromDB<string>(Dr["TITULO_DIR"]),
                    resumo_dir = TratamentoNull.CheckNullFromDB<string>(Dr["RESUMO_DIR"])
                });
            }

            return lista;
        }
        public Task Deletar(string id)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM DIRETRIZ WHERE CD_DIR = @ID", Con);
            Cmd.Parameters.AddWithValue("@ID", id);
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM DIRETRIZ WHERE CD_DIR = @ID", Con);
                Cmd.Parameters.AddWithValue("@ID", id);

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Diretriz não encontrada!");

            return Task.CompletedTask;
        }

        public Task Alterar(Diretriz a)
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE DIRETRIZ SET CD_DIR = @CD_DIR, TITULO_DIR = @TITULO_DIR WHERE CD_DIR = @CODIGO", Con);
            Cmd.Parameters.AddWithValue("@CODIGO", a.cd_dir);
            Cmd.Parameters.AddWithValue("@TITULO_DIR", a.titulo_dir);
            Cmd.Parameters.AddWithValue("@RESUMO_DIR", a.resumo_dir);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
