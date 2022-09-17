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
    public class MedidaPersistence : DAL, IMedida
    {
        public Task Cadastrar(Medida p)
        {

            OpenConnection();

            Cmd = new SqlCommand("SELECT ISNULL(MAX(CD_MEDIDA + 1), 1) FROM MEDIDA", Con);
            int cd_ultimo = Convert.ToInt32(Cmd.ExecuteScalar());

            Cmd = new SqlCommand("INSERT INTO MEDIDA VALUES(@CD_MEDIDA, @CD_OBJ, @TITULO_MEDIDA, @RESUMO_MEDIDA, @TERMO_MEDIDA, @NOCAO_MEDIDA, @IMPACTO_MEDIDA, @SINONIMO_MEDIDA, @FONTE_MEDIDA, @TIPO_MEDIDA, @FORMATO_MEDIDA, @RESTRICAO_MEDIDA)", Con);
            Cmd.Parameters.AddWithValue("@CD_MEDIDA", cd_ultimo);
            Cmd.Parameters.AddWithValue("@CD_OBJ", p.cd_obj);
            Cmd.Parameters.AddWithValue("@TITULO_MEDIDA", p.titulo_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@RESUMO_MEDIDA", p.resumo_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@TERMO_MEDIDA", p.termo_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@NOCAO_MEDIDA", p.nocao_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@IMPACTO_MEDIDA", p.impacto_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@SINONIMO_MEDIDA", p.sinonimo_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@FONTE_MEDIDA", p.fonte_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@TIPO_MEDIDA", p.tipo_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@FORMATO_MEDIDA", p.formato_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@RESTRICAO_MEDIDA", p.restricao_medida.ToUpper());

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<Medida> Listar()
        {
            OpenConnection();

            List<Medida> lista = new List<Medida>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM MEDIDA", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Medida()
                {
                    cd_medida = Dr["CD_MEDIDA"].ToString(),
                    cd_obj = Dr["CD_OBJ"].ToString(),
                    titulo_medida = TratamentoNull.CheckNullFromDB<string>(Dr["TITULO_MEDIDA"]),
                    resumo_medida = TratamentoNull.CheckNullFromDB<string>(Dr["RESUMO_MEDIDA"]),
                    termo_medida = TratamentoNull.CheckNullFromDB<string>(Dr["TERMO_MEDIDA"]),
                    nocao_medida = TratamentoNull.CheckNullFromDB<string>(Dr["NOCAO_MEDIDA"]),
                    impacto_medida = TratamentoNull.CheckNullFromDB<string>(Dr["IMPACTO_MEDIDA"]),
                    sinonimo_medida = TratamentoNull.CheckNullFromDB<string>(Dr["SINONIMO_MEDIDA"]),
                    fonte_medida = TratamentoNull.CheckNullFromDB<string>(Dr["FONTE_MEDIDA"]),
                    tipo_medida = TratamentoNull.CheckNullFromDB<string>(Dr["TIPO_MEDIDA"]),
                    formato_medida = TratamentoNull.CheckNullFromDB<string>(Dr["FORMATO_MEDIDA"]),
                    restricao_medida = TratamentoNull.CheckNullFromDB<string>(Dr["RESTRICAO_MEDIDA"])
                });
            }

            return lista;
        }

        public List<Medida> ListarPorId(int id)
        {
            OpenConnection();

            List<Medida> lista = new List<Medida>();

            Cmd = new SqlCommand("SELECT * FROM MEDIDA WHERE CD_MEDIDA = @CD_MEDIDA", Con);
            Cmd.Parameters.AddWithValue("@CD_MEDIDA", id);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Medida()
                {
                    cd_medida = Dr["CD_MEDIDA"].ToString(),
                    cd_obj = Dr["CD_OBJ"].ToString(),
                    titulo_medida = TratamentoNull.CheckNullFromDB<string>(Dr["TITULO_MEDIDA"]),
                    resumo_medida = TratamentoNull.CheckNullFromDB<string>(Dr["RESUMO_MEDIDA"]),
                    termo_medida = TratamentoNull.CheckNullFromDB<string>(Dr["TERMO_MEDIDA"]),
                    nocao_medida = TratamentoNull.CheckNullFromDB<string>(Dr["NOCAO_MEDIDA"]),
                    impacto_medida = TratamentoNull.CheckNullFromDB<string>(Dr["IMPACTO_MEDIDA"]),
                    sinonimo_medida = TratamentoNull.CheckNullFromDB<string>(Dr["SINONIMO_MEDIDA"]),
                    fonte_medida = TratamentoNull.CheckNullFromDB<string>(Dr["FONTE_MEDIDA"]),
                    tipo_medida = TratamentoNull.CheckNullFromDB<string>(Dr["TIPO_MEDIDA"]),
                    formato_medida = TratamentoNull.CheckNullFromDB<string>(Dr["FORMATO_MEDIDA"]),
                    restricao_medida = TratamentoNull.CheckNullFromDB<string>(Dr["RESTRICAO_MEDIDA"])
                });
            }

            return lista;
        }
        public Task Deletar(decimal id)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM MEDIDA WHERE CD_MEDIDA = @ID", Con);
            Cmd.Parameters.AddWithValue("@ID", id);
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM MEDIDA WHERE CD_MEDIDA = @ID", Con);
                Cmd.Parameters.AddWithValue("@ID", id);

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Medida não encontrada!");

            return Task.CompletedTask;
        }

        public Task Alterar(Medida p)
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE MEDIDA SET CD_MEDIDA = @CD_MEDIDA, TITULO_MEDIDA = @TITULO_MEDIDA, RESUMO_MEDIDA = @RESUMO_MEDIDA, TERMO_MEDIDA = @TERMO_MEDIDA, NOCAO_MEDIDA = @NOCAO_MEDIDA, IMPACTO_MEDIDA = @IMPACTO_MEDIDA, SINONIMO_MEDIDA = @SINONIMO_MEDIDA, FONTE_MEDIDA = @FONTE_MEDIDA, TIPO_MEDIDA = @TIPO_MEDIDA, FORMATO_MEDIDA = @FORMATO_MEDIDA, RESTRICAO_MEDIDA = @RESTRICAO_MEDIDA WHERE CD_MEDIDA = @CODIGO", Con);
            Cmd.Parameters.AddWithValue("@CODIGO", p.cd_medida);
            Cmd.Parameters.AddWithValue("@CD_OBJ", p.cd_obj);
            Cmd.Parameters.AddWithValue("@TITULO_MEDIDA", p.titulo_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@RESUMO_MEDIDA", p.resumo_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@TERMO_MEDIDA", p.termo_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@NOCAO_MEDIDA", p.nocao_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@IMPACTO_MEDIDA", p.impacto_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@SINONIMO_MEDIDA", p.sinonimo_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@FONTE_MEDIDA", p.fonte_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@TIPO_MEDIDA", p.tipo_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@FORMATO_MEDIDA", p.formato_medida.ToUpper());
            Cmd.Parameters.AddWithValue("@RESTRICAO_MEDIDA", p.restricao_medida.ToUpper());

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
