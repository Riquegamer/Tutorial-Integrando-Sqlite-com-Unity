using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.Globalization;

public class BancoDeDados
{
    private IDbConnection BancoDados;

   private IDbConnection criarEAbrirBancoDeDados()
    {
        string idburi = "URI=file:BancoDeDados.Sqlite";
        IDbConnection ConexaoBanco = new SqliteConnection(idburi);
        ConexaoBanco.Open();

        using (var comandoCriarTabelas = ConexaoBanco.CreateCommand())
        {
            comandoCriarTabelas.CommandText = "CREATE TABLE IF NOT EXISTS POSICOES(id INTEGER PRIMARY KEY NOT NULL, x REAL, y REAL);";
            comandoCriarTabelas.ExecuteNonQuery();
        }

        return ConexaoBanco;
    }

    public void InserirPosicao(int id, float x, float y)
    {
        CultureInfo cultura = CultureInfo.InvariantCulture;
        BancoDados = criarEAbrirBancoDeDados();
        IDbCommand InserDados = BancoDados.CreateCommand();
        InserDados.CommandText = $"INSERT OR REPLACE INTO POSICOES(id, x, y) VALUES({id}, {x.ToString(cultura)}, {y.ToString(cultura)})";
        InserDados.ExecuteNonQuery();
        BancoDados.Close();
    }

    public IDataReader LerPosicao(int id)
    {
        BancoDados = criarEAbrirBancoDeDados();
        IDbCommand ComandoLerPosicao = BancoDados.CreateCommand();
        ComandoLerPosicao.CommandText = $"SELECT * FROM POSICOES WHERE ID LIKE {id};";
        IDataReader Leitura = ComandoLerPosicao.ExecuteReader();
        return Leitura;
    }

    public void FecharConexao() 
    {
        BancoDados.Close();
    }

    public void CriarBanco() 
    {
       BancoDados = criarEAbrirBancoDeDados();
        BancoDados.Close(); 
    }

    public void NovoJogo()
    {
        BancoDados = criarEAbrirBancoDeDados();
        IDbCommand DeletarTudo = BancoDados.CreateCommand();
        DeletarTudo.CommandText = "DELETE FROM POSICOES";
        DeletarTudo.ExecuteNonQuery();
        BancoDados.Close();
    }


}
