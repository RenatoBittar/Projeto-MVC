using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TesteRift.Models
{
    public class PessoaFisicaModel : IDisposable
    {
        private SqlConnection conn;

        public PessoaFisicaModel()
        {
            string strConn = @"Server=DESKTOP-1NFUKKA;DataBase=Rift;Integrated Security=true; "; 
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();

        }

        public void Create(PessoaFisica pessoaFisica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"INSERT INTO TB_PESSOA_FISICA VALUES (@nome, @cpf, @rg, @endereco, @telefone, @email)";

            cmd.Parameters.AddWithValue("@nome", pessoaFisica.Nome);
            cmd.Parameters.AddWithValue("@cpf", pessoaFisica.CPF);
            cmd.Parameters.AddWithValue("@rg", pessoaFisica.RG);
            cmd.Parameters.AddWithValue("@endereco", pessoaFisica.Endereco);
            cmd.Parameters.AddWithValue("@telefone", pessoaFisica.Telefone);
            cmd.Parameters.AddWithValue("@email", pessoaFisica.Email);

            cmd.ExecuteNonQuery();
        }
        public List<PessoaFisica> Read()
        {
            List<PessoaFisica> list = new List<PessoaFisica>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM TB_PESSOA_FISICA";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PessoaFisica pessoa = new PessoaFisica();
                pessoa.IdPessoaFisica = (int)reader["IdPessoaFisica"];
                pessoa.Nome = (string)reader["Nome"];
                pessoa.CPF = (string)reader["CPF"];
                pessoa.CPF = (string)reader["RG"];
                pessoa.CPF = (string)reader["Endereco"];
                pessoa.CPF = (string)reader["Telefone"];
                pessoa.CPF = (string)reader["Email"];

                list.Add(pessoa);

            }
            return list;
        }

        public PessoaFisica GetPessoa(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM TB_PESSOA_FISICA WHERE IdPessoaFisica = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            PessoaFisica pessoa = new PessoaFisica();
            while (reader.Read())
            {
                pessoa.IdPessoaFisica = (int)reader["IdPessoaFisica"];
                pessoa.Nome = (string)reader["Nome"];
                pessoa.CPF = (string)reader["CPF"];
                pessoa.CPF = (string)reader["RG"];
                pessoa.CPF = (string)reader["Endereco"];
                pessoa.CPF = (string)reader["Telefone"];
                pessoa.CPF = (string)reader["Email"];
            }
            return pessoa;
        }

        public List<PessoaFisica> Get(PessoaFisica pessoa)
        {
            List<PessoaFisica> list = new List<PessoaFisica>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM TB_PESSOA_FISICA WHERE Nome = @nome or CPF = @cpf or RG = @rg";
            cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@cpf", pessoa.CPF);
            cmd.Parameters.AddWithValue("@rg", pessoa.RG);
            

            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                PessoaFisica p = new PessoaFisica();
                p.IdPessoaFisica = (int)reader["IdPessoaFisica"];
                p.Nome = (string)reader["Nome"];
                p.CPF = (string)reader["CPF"];
                p.RG = (string)reader["RG"];
                p.Endereco = (string)reader["Endereco"];
                p.Telefone = (string)reader["Telefone"];
                p.Email = (string)reader["Email"];

                list.Add(p);
            }
            return list;
        }
    }
}