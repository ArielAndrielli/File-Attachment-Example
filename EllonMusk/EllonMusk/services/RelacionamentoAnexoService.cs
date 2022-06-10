using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;

namespace EllonMusk.services
{

    #region Proriedades

    public class Anexo
    {
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public string Extensao { get; set; }
        public List<byte> Dados { get; set; }
    }

    #endregion

    #region Classe Abstrata

    public abstract class RelacionamentoAnexoService
    {
        public List<Anexo> Anexos { get; set; } = new List<Anexo>();
        public abstract string SalvarAnexo();
        public override string ToString() => GetType().Name;
    }

    #endregion

    #region Métodos

    public class AnexoClienteService : RelacionamentoAnexoService
    {
        public override string SalvarAnexo()
        {
            try
            {
                MySqlConnection connection = null;
                string ConnectionString = @"Server=localhost;User=root;Password=sql$user;Database=telas;";
                connection = new MySqlConnection(ConnectionString);
                connection.Open();

                foreach(var anexo in Anexos)
                {
                    string filename = anexo.Nome;
                    string filePath = anexo.Caminho;
                    string fileType = anexo.Extensao;
                    List<byte> Dados = anexo.Dados;

                    

                    MySqlCommand command = new MySqlCommand();

                    command.CommandText = @$"INSERT INTO Cliente ( Nome , caminho, TipoDeConteudo, Dado ) VALUES (@nm, @fp, @tc, @dt)";
                    command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = filename;
                    command.Parameters.Add("@fp", MySqlDbType.VarChar).Value = filePath;
                    command.Parameters.Add("@tc", MySqlDbType.VarChar).Value = fileType;
                    command.Parameters.Add("@dt", MySqlDbType.Binary).Value = Dados;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }

            }
            catch (IOException ex)
            {
                return ex.Message;
            }

            return "Salvo na tabela Anexo do Cliente";
        }
    }
    public class AnexoSolicitacaoService : RelacionamentoAnexoService
    {
        public override string SalvarAnexo()
        {

            try
            {
                MySqlConnection connection = null;
                string ConnectionString = @"Server=localhost;User=root;Password=sql$user;Database=telas;";
                connection = new MySqlConnection(ConnectionString);
                connection.Open();

                foreach (var anexo in Anexos)
                {
                    string filename = anexo.Nome;
                    string filePath = anexo.Caminho;
                    string fileType = anexo.Extensao;
                    List<byte> Dados = anexo.Dados;



                    MySqlCommand command = new MySqlCommand();

                    command.CommandText = @$"INSERT INTO solicitacao ( Nome , caminho, TipoDeConteudo, Dado ) VALUES (@nm, @fp, @tc, @dt)";
                    command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = filename;
                    command.Parameters.Add("@fp", MySqlDbType.VarChar).Value = filePath;
                    command.Parameters.Add("@tc", MySqlDbType.VarChar).Value = fileType;
                    command.Parameters.Add("@dt", MySqlDbType.Binary).Value = Dados;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }

            }
            catch (IOException ex)
            {
                return ex.Message;
            }

            return "Salvo na tabela Anexo do Cliente";
        }

    }
    public class AnexoVisitaService : RelacionamentoAnexoService
    {
        public override string SalvarAnexo()
        {

            try
            {
                MySqlConnection connection = null;
                string ConnectionString = @"Server=localhost;User=root;Password=sql$user;Database=telas;";
                connection = new MySqlConnection(ConnectionString);
                connection.Open();

                foreach (var anexo in Anexos)
                {
                    string filename = anexo.Nome;
                    string filePath = anexo.Caminho;
                    string fileType = anexo.Extensao;
                    List<byte> Dados = anexo.Dados;



                    MySqlCommand command = new MySqlCommand();

                    command.CommandText = @$"INSERT INTO visita ( Nome , caminho, TipoDeConteudo, Dado ) VALUES (@nm, @fp, @tc, @dt)";
                    command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = filename;
                    command.Parameters.Add("@fp", MySqlDbType.VarChar).Value = filePath;
                    command.Parameters.Add("@tc", MySqlDbType.VarChar).Value = fileType;
                    command.Parameters.Add("@dt", MySqlDbType.Binary).Value = Dados;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }

            }
            catch (IOException ex)
            {
                return ex.Message;
            }

            return "Salvo na tabela Anexo do Cliente";
        }
    }

    #endregion
}
