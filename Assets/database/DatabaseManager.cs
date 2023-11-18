using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System.Data;

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
        }
        else
        {
            Debug.LogError("La base de datos no existe. Asegúrate de haberla creado previamente.");
        }
    }

    private void OpenDB(string dbPath)
    {
        dbConnection = new SqliteConnection("URI=file:" + dbPath);
        dbConnection.Open();

        Debug.Log("La conexión a la base de datos está abierta.");
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
            dbCommand.CommandText = "INSERT INTO treatment_data (playerName, date, score, miniGameName, level, time, objectCount) VALUES ('" +
                            playerName + "', '" +
                            System.DateTime.Now.ToString("dd/MM/yy") + "', " +
                            score + ", '" +
                            miniGameName + "', '" +  // <-- Corregir aquí (agregar comilla simple)
                            level + "', " +
                            time + ", " +
                            objectCount + ")";

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