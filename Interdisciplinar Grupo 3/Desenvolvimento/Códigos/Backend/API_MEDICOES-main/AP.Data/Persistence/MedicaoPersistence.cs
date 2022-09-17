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
    public class MedicaoPersistence : DAL, IMedicao
    {
        public Task Cadastrar(Medicao p)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT ISNULL(MAX(CD_MED + 1), 1) FROM MEDICAO", Con);
            int cd_ultimo = Convert.ToInt32(Cmd.ExecuteScalar());

            Cmd = new SqlCommand("INSERT INTO MEDICAO VALUES(@CD_MED, @CD_DIR, @CD_PROC, @VERSAO_MED, @PROPOSITO_MED)", Con);
            Cmd.Parameters.AddWithValue("@CD_MED", cd_ultimo);
            Cmd.Parameters.AddWithValue("@CD_DIR", p.cd_dir);
            Cmd.Parameters.AddWithValue("@CD_PROC", p.cd_proc);
            Cmd.Parameters.AddWithValue("@VERSAO_MED", p.versao_med);
            Cmd.Parameters.AddWithValue("@PROPOSITO_MED", p.proposito_med);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<Medicao> Listar()
        {
            OpenConnection();

            List<Medicao> lista = new List<Medicao>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM MEDICAO", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Medicao()
                {
                    cd_med = Dr["CD_MED"].ToString(),
                    cd_dir = Dr["CD_DIR"].ToString(),
                    cd_proc = Dr["CD_PROC"].ToString(),
                    versao_med = TratamentoNull.CheckNullFromDB<int>(Dr["VERSAO_MED"]),
                    proposito_med = TratamentoNull.CheckNullFromDB<string>(Dr["PROPOSITO_MED"])
                });
            }

            return lista;
        }

        public List<Medicao> ListarPorId(string id)
        {
            OpenConnection();

            List<Medicao> lista = new List<Medicao>();

            Cmd = new SqlCommand("SELECT * FROM MEDICAO WHERE CD_MED = @CD_MED", Con);
            Cmd.Parameters.AddWithValue("@CD_MED", id);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Medicao()
                {
                    cd_med = Dr["CD_MED"].ToString(),
                    cd_dir = Dr["CD_DIR"].ToString(),
                    cd_proc = Dr["CD_PROC"].ToString(),
                    versao_med = TratamentoNull.CheckNullFromDB<int>(Dr["VERSAO_MED"]),
                    proposito_med = TratamentoNull.CheckNullFromDB<string>(Dr["PROPOSITO_MED"])
                });
            }

            return lista;
        }
        public Task Deletar(string id)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM MEDICAO WHERE CD_MED = @CD_MED", Con);
            Cmd.Parameters.AddWithValue("@CD_MED", id);
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM MEDICAO WHERE CD_MED = @CD_MED", Con);
                Cmd.Parameters.AddWithValue("@CD_MED", id);

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Medicao não encontrada!");

            return Task.CompletedTask;
        }

        public Task Alterar(Medicao p)
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE MEDICAO SET CD_DIR = @CD_DIR, CD_PROC = @CD_PROC, VERSAO_MED = @VERSAO_MED, PROPOSITO_MED = @PROPOSITO_MED WHERE CD_MED = @CD_MED", Con);
            Cmd.Parameters.AddWithValue("@CD_DIR", p.cd_dir);
            Cmd.Parameters.AddWithValue("@CD_PROC", p.cd_proc);
            Cmd.Parameters.AddWithValue("@VERSAO_MED", p.versao_med);
            Cmd.Parameters.AddWithValue("@CD_MED", p.cd_med);
            Cmd.Parameters.AddWithValue("@PROPOSITO_MED", p.proposito_med);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
