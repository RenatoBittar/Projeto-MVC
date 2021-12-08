using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TesteRift.Models
{
    public class PessoaJuridicaModel : IDisposable
    {
        private SqlConnection conn;

        public PessoaJuridicaModel()
        {
            string strConn = @"Server=DESKTOP-1NFUKKA;DataBase=Rift;Integrated Security=true; ";
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();

        }
       
        public void Create(PessoaJuridica pessoaJuridica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"INSERT INTO TB_PESSOA_JURIDICA VALUES (@cnpj, @razaoSocial, @nomeFantasia, @endereco, @telefone, @email)";

            cmd.Parameters.AddWithValue("@cnpj", pessoaJuridica.CNPJ);
            cmd.Parameters.AddWithValue("@razaoSocial", pessoaJuridica.RazaoSocial);
            cmd.Parameters.AddWithValue("@nomeFantasia", pessoaJuridica.NomeFantasia);
            cmd.Parameters.AddWithValue("@endereco", pessoaJuridica.Endereco);
            cmd.Parameters.AddWithValue("@telefone", pessoaJuridica.Telefone);
            cmd.Parameters.AddWithValue("@email", pessoaJuridica.Email);

            cmd.ExecuteNonQuery();
        }
        public List<PessoaJuridica> Read()
        {
            List<PessoaJuridica> list = new List<PessoaJuridica>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM TB_PESSOA_JURIDICA";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PessoaJuridica pessoa = new PessoaJuridica();
                pessoa.IdPessoaJuridica = (int)reader["IdPessoaJuridica"];
                pessoa.CNPJ = (string)reader["CNPJ"];
                pessoa.RazaoSocial = (string)reader["RazaoSocial"];
                pessoa.NomeFantasia = (string)reader["NomeFantasia"];
                pessoa.Endereco = (string)reader["Endereco"];
                pessoa.Telefone = (string)reader["Telefone"];
                pessoa.Email = (string)reader["Email"];

                list.Add(pessoa);

            }
            return list;
        }
        public PessoaJuridica GetPessoa(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM TB_PESSOA_JURIDICA WHERE IdPessoaJuridica = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            PessoaJuridica pessoa = new PessoaJuridica();
            while (reader.Read())
            {
                pessoa.IdPessoaJuridica = (int)reader["IdPessoaJuridica"];
                pessoa.CNPJ = (string)reader["CNPJ"];
                pessoa.RazaoSocial = (string)reader["RazaoSocial"];
                pessoa.NomeFantasia = (string)reader["NomeFantasia"];
                pessoa.Endereco = (string)reader["Endereco"];
                pessoa.Telefone = (string)reader["Telefone"];
                pessoa.Email = (string)reader["Email"];
            }
            return pessoa;
        }
        public List<PessoaJuridica> Get(PessoaJuridica pessoa)
        {
            List<PessoaJuridica> list = new List<PessoaJuridica>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM TB_PESSOA_JURIDICA WHERE CNPJ = @cnpj or RazaoSocial = @razaoSocial or  NomeFantasia = @nomeFantasia";
            cmd.Parameters.AddWithValue("@cnpj", pessoa.CNPJ);
            cmd.Parameters.AddWithValue("@razaoSocial", pessoa.RazaoSocial);
            cmd.Parameters.AddWithValue("@nomeFantasia", pessoa.NomeFantasia);
         
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PessoaJuridica p = new PessoaJuridica();
                p.IdPessoaJuridica = (int)reader["IdPessoaJuridica"];
                p.CNPJ = (string)reader["CNPJ"];
                p.RazaoSocial = (string)reader["RazaoSocial"];
                p.NomeFantasia = (string)reader["NomeFantasia"];
                p.Endereco = (string)reader["Endereco"];
                p.Telefone = (string)reader["Telefone"];
                p.Email = (string)reader["Email"];

                list.Add(p);
            }
            return list;
        }
    }
}