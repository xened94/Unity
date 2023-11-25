using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System.Data;
using dbgm;
using System;
namespace dbpruebas
{
public class DatabaseManager : MonoBehaviour
{
    private IDbConnection dbConnection;
    private GameManager gameManager;

void Start()
{
    gameManager = FindObjectOfType<GameManager>();

    // Ruta de la base de datos
    string dbPath = Path.Combine(Application.dataPath, "terapias.db");

    // Verificar si la base de datos existe
    if (File.Exists(dbPath))
    {
        // Si la base de datos existe, abrir la conexión
        Debug.Log("La base de datos existe. Abriendo la base de datos...");
        OpenDB(dbPath);

        // Crear la tabla treatment_data si no existe
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS treatment_data (" +
                                "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                "playerName TEXT," +
                                "date TEXT," +
                                "score INTEGER," +
                                "miniGameName TEXT," +
                                "level TEXT," +
                                "time REAL," +
                                "objectCount INTEGER)";

        dbCommand.ExecuteNonQuery();
        dbCommand.Dispose();
    }
    else
    {
        Debug.LogError("La base de datos no existe. Asegúrate de haberla creado previamente.");
    }
}

    // Métodos públicos adicionales para pruebas
public void OpenConnectionForTesting(string connectionString)
{
    if (dbConnection != null && dbConnection.State == ConnectionState.Open)
    {
        Debug.LogWarning("La conexión ya está abierta.");
        return;
    }

    try
    {
        dbConnection = new SqliteConnection(connectionString);
        dbConnection.Open();

        Debug.Log("Conexión de prueba a la base de datos abierta.");

        // Crear la tabla treatment_data si no existe
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS treatment_data (" +
                                "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                "playerName TEXT," +
                                "date TEXT," +
                                "score INTEGER," +
                                "miniGameName TEXT," +
                                "level TEXT," +
                                "time REAL," +
                                "objectCount INTEGER)";

        dbCommand.ExecuteNonQuery();
        dbCommand.Dispose();
    }
    catch (Exception e)
    {
        Debug.LogError($"Error al abrir la conexión de prueba: {e.Message}");
    }
}

    public void CloseConnectionForTesting()
    {
        CerrarConexion();
    }

    public void ClearTableForTesting(string tableName)
    {
        if (dbConnection != null && dbConnection.State == ConnectionState.Open)
        {
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "DELETE FROM " + tableName;
            dbCommand.ExecuteNonQuery();
            dbCommand.Dispose();
        }
    }


private void OpenDB(string dbPath)
{
    dbConnection = new SqliteConnection("URI=file:" + dbPath);
    dbConnection.Open();

    Debug.Log("La conexión a la base de datos está abierta.");

    // Crear la tabla treatment_data si no existe
    IDbCommand dbCommand = dbConnection.CreateCommand();
    dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS treatment_data (" +
                            "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                            "playerName TEXT," +
                            "date TEXT," +
                            "score INTEGER," +
                            "miniGameName TEXT," +
                            "level TEXT," +
                            "time REAL," +
                            "objectCount INTEGER)";

    dbCommand.ExecuteNonQuery();
    dbCommand.Dispose();
}

    public IDbConnection DbConnection
    {
        get { return dbConnection; }
    }

    public void InsertarDatosDelJuego(int score, string miniGameName, string level, float time, int objectCount, int tratamiento, string playerName)
    {
        if (dbConnection != null && dbConnection.State == ConnectionState.Open)
        {
            IDbCommand dbCommand = dbConnection.CreateCommand();
    dbCommand.CommandText = "INSERT INTO treatment_data (playerName, date, score, miniGameName, level, time, objectCount) VALUES (@PlayerName, @Date, @Score, @MiniGameName, @Level, @Time, @ObjectCount)";
    dbCommand.Parameters.Add(new SqliteParameter("@PlayerName", playerName));
    dbCommand.Parameters.Add(new SqliteParameter("@Date", System.DateTime.Now.ToString("dd/MM/yy")));
    dbCommand.Parameters.Add(new SqliteParameter("@Score", score));
    dbCommand.Parameters.Add(new SqliteParameter("@MiniGameName", miniGameName));
    dbCommand.Parameters.Add(new SqliteParameter("@Level", level));
    dbCommand.Parameters.Add(new SqliteParameter("@Time", time));
    dbCommand.Parameters.Add(new SqliteParameter("@ObjectCount", objectCount));

            dbCommand.ExecuteNonQuery();
            dbCommand.Dispose();

            // No cierres la conexión aquí para que siga abierta y pueda usarse en otras consultas
        }
        else
        {
            Debug.LogError("La conexión a la base de datos no está abierta.");
        }
    }

    public void CerrarConexion()
    {
        if (dbConnection != null && dbConnection.State == ConnectionState.Open)
        {
            dbConnection.Close();
        }
    }
}
}