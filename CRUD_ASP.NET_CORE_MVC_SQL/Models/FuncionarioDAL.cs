using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_ASP.NET_CORE_MVC_SQL.Models
{
    public class FuncionarioDAL : IFuncionarioDAL
    {
        string connectionString = @"Server=DESKTOP-FUPLHOR;Database=CadastroDB;User ID=sa;Password=qweasd;Trusted_Connection=False;Packet Size=4096;";

        public IEnumerable<Funcionario> GetAllFuncionarios()
        {
            List<Funcionario> lstfuncionario = new List<Funcionario>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT FuncionarioId, Nome, Cidade, Departamento, Sexo FROM Funcionarios", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                    funcionario.Nome = rdr["Nome"].ToString();
                    funcionario.Cidade = rdr["Cidade"].ToString();
                    funcionario.Departamento = rdr["Departamento"].ToString();
                    funcionario.Sexo = rdr["Sexo"].ToString();
                    lstfuncionario.Add(funcionario);
                }
                con.Close();
            }
            return lstfuncionario;
        }
        public void AddFuncionario(Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Insert into Funcionarios (Nome,Cidade,Departamento,Sexo) " +
                                                        "Values(@Nome, @Cidade, @Departamento, @Sexo)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Cidade", funcionario.Cidade);
                cmd.Parameters.AddWithValue("@Departamento", funcionario.Departamento);
                cmd.Parameters.AddWithValue("@Sexo", funcionario.Sexo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateFuncionario(Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Update Funcionarios set Nome = @Nome, Cidade = @Cidade, Departamento = " +
                                                              "@Departamento, Sexo = @Sexo where FuncionarioId = @FuncionarioId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FuncionarioId", funcionario.FuncionarioId);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Cidade", funcionario.Cidade);
                cmd.Parameters.AddWithValue("@Departamento", funcionario.Departamento);
                cmd.Parameters.AddWithValue("@Sexo", funcionario.Sexo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Funcionario GetFuncionario(int? id)
        {
            Funcionario funcionario = new Funcionario();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Funcionarios WHERE FuncionarioId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    funcionario.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                    funcionario.Nome = rdr["Nome"].ToString();
                    funcionario.Cidade = rdr["Cidade"].ToString();
                    funcionario.Departamento = rdr["Departamento"].ToString();
                    funcionario.Sexo = rdr["Sexo"].ToString();
                }
            }
            return funcionario;
        }
        public void DeleteFuncionario(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from Funcionarios where FuncionarioId = @FuncionarioId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FuncionarioId", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
