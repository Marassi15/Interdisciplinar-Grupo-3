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
    public class ObjetivoPersistence : DAL, IObjetivo
    {
        public Task Cadastrar(Objetivo p) {

            OpenConnection();

            Cmd = new SqlCommand("SELECT ISNULL(MAX(CD_OBJ + 1), 1) FROM OBJETIVO", Con);
            int cd_ultimo = Convert.ToInt32(Cmd.ExecuteScalar());

            Cmd = new SqlCommand("INSERT INTO OBJETIVO VALUES(@CD_OBJ, @CD_DIR, @TITULO_OBJ, @RESUMO_OBJ)", Con);
            Cmd.Parameters.AddWithValue("@CD_OBJ", cd_ultimo);
            Cmd.Parameters.AddWithValue("@CD_DIR", p.cd_dir);
            Cmd.Parameters.AddWithValue("@TITULO_OBJ", p.titulo_obj.ToUpper());
            Cmd.Parameters.AddWithValue("@RESUMO_OBJ", p.resumo_obj.ToUpper());           

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<Objetivo> Listar() {
            OpenConnection();

            List<Objetivo> lista = new List<Objetivo>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM OBJETIVO", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Objetivo()
                {
                    cd_obj = Dr["CD_OBJ"].ToString(),
                    cd_dir = Dr["CD_DIR"].ToString(),
                    titulo_obj = TratamentoNull.CheckNullFromDB<string>(Dr["TITULO_OBJ"]),
                    resumo_obj = TratamentoNull.CheckNullFromDB<string>(Dr["RESUMO_OBJ"])                  
                });
            }

            return lista;
        }

        public List<Objetivo> ListarPorId(int id)
        {
            OpenConnection();

            List<Objetivo> lista = new List<Objetivo>();

            Cmd = new SqlCommand("SELECT * FROM OBJETIVO WHERE CD_OBJ = @CD_OBJ", Con);
            Cmd.Parameters.AddWithValue("@CD_OBJ", id);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Objetivo()
                {
                    cd_obj = Dr["CD_OBJ"].ToString(),
                    cd_dir = Dr["CD_DIR"].ToString(),
                    titulo_obj = TratamentoNull.CheckNullFromDB<string>(Dr["TITULO_OBJ"]),
                    resumo_obj = TratamentoNull.CheckNullFromDB<string>(Dr["RESUMO_OBJ"])
                });
            }

            return lista;
        }
        public Task Deletar(decimal id)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM OBJETIVO WHERE CD_OBJ = @ID", Con);
            Cmd.Parameters.AddWithValue("@ID", id);
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM OBJETIVO WHERE CD_OBJ = @ID", Con);
                Cmd.Parameters.AddWithValue("@ID", id);

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Objetivo não encontrado!");

            return Task.CompletedTask;
        }

        public Task Alterar(Objetivo p) 
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE OBJETIVO SET CD_DIR = @CD_DIR, TITULO_OBJ = @TITULO_OBJ, RESUMO_OBJ = @RESUMO_OBJ WHERE CD_OBJ = @CODIGO", Con);
            Cmd.Parameters.AddWithValue("@CODIGO", p.cd_obj);
            Cmd.Parameters.AddWithValue("@CD_DIR", p.cd_dir);
            Cmd.Parameters.AddWithValue("@TITULO_OBJ", p.titulo_obj);
            Cmd.Parameters.AddWithValue("@RESUMO_OBJ", p.resumo_obj);           

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
