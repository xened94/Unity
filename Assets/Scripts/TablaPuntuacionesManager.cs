    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using System.Data;
    using System.Globalization;
    using System;
    using TMPro;

    public class TablaPuntuacionesManager : MonoBehaviour
    {
        public TMP_Text tablaText; // Referencia al objeto Text o TextMeshPro que mostrará la tabla de puntuaciones
        public DatabaseManager databaseManager;
         public InputField inputNombre; 

        void Start()
        {
            MostrarTablaPuntuaciones();
        }

        public void BuscarDatos()
    {
        string nombreBuscado = inputNombre.text.Trim(); // Obtén el nombre ingresado y quita espacios en blanco

        // Si el nombre ingresado está vacío, muestra todos los resultados
        if (string.IsNullOrEmpty(nombreBuscado))
        {
            MostrarTablaPuntuaciones();
            return;
        }

        // Consulta SQL con una cláusula WHERE para filtrar por nombre
        string query = $"SELECT playerName, score, miniGameName, level, time, objectCount, date, treatmentNumber FROM treatment_data WHERE playerName = '{nombreBuscado}' ORDER BY score DESC LIMIT 10";
        IDbCommand dbCommand = databaseManager.DbConnection.CreateCommand();
        dbCommand.CommandText = query;
        IDataReader reader = dbCommand.ExecuteReader();

        // Construye el texto para mostrar en la tabla
        string tablaTexto = $"   #     Nombre     Puntaje     Juego     Dificultad    Tiempo   Objetos           Fecha\n";
        while (reader.Read())
        {
            string playerName = reader.GetString(0);
            int score = reader.GetInt32(1);
            string miniGameName = reader.GetString(2);
            string level = reader.GetString(3);
            float time = (float)reader.GetDouble(4);
            int roundedTime = Mathf.RoundToInt(time); // Redondear el tiempo a un entero
            int objectCount = reader.GetInt32(5);
            string date = reader.GetString(6);
            int treatmentNumber = reader.GetInt32(7);

            // Ajusta el formato de la fecha (puedes personalizarlo según tus necesidades)
            DateTime fecha = DateTime.ParseExact(date, "dd/MM/yy", CultureInfo.InvariantCulture);
            string fechaFormateada = fecha.ToString("dd/MM/yyyy");

            // Agrega la información al texto de la tabla
            tablaTexto += $"   {treatmentNumber}    {playerName}   {score}     {miniGameName}   {level}      {roundedTime}              {objectCount}           {fechaFormateada}\n";
        }

        // Asigna el texto construido al objeto Text o TextMeshPro
        tablaText.text = tablaTexto;

        // Cierra el lector y el comando después de usarlos
        reader.Close();
        dbCommand.Dispose();
    }

        void MostrarTablaPuntuaciones()
        {
            // Aquí ejecuta una consulta SQL para obtener la información de la tabla de puntuaciones
            // Utiliza el DatabaseManager para ejecutar la consulta

            // Ejemplo de consulta:
            string query = "SELECT playerName, score, miniGameName, level, time, objectCount, date, treatmentNumber FROM treatment_data ORDER BY score DESC LIMIT 10";
            IDbCommand dbCommand = databaseManager.DbConnection.CreateCommand();
            dbCommand.CommandText = query;
            IDataReader reader = dbCommand.ExecuteReader();

            // Construye el texto para mostrar en la tabla
    string tablaTexto = "   #     Nombre     Puntaje     Juego     Dificultad    Tiempo   Objetos           Fecha\n";
    while (reader.Read())
    {
        string playerName = reader.GetString(0);
        int score = reader.GetInt32(1);
        string miniGameName = reader.GetString(2);
        string level = reader.GetString(3);
        float time = (float)reader.GetDouble(4);
        int roundedTime = Mathf.RoundToInt(time); // Redondear el tiempo a un entero
        int objectCount = reader.GetInt32(5);
        string date = reader.GetString(6);
        int treatmentNumber = reader.GetInt32(7);

        // Ajusta el formato de la fecha (puedes personalizarlo según tus necesidades)
        DateTime fecha = DateTime.ParseExact(date, "dd/MM/yy", CultureInfo.InvariantCulture);
        string fechaFormateada = fecha.ToString("dd/MM/yyyy");

        // Agrega la información al texto de la tabla
        tablaTexto += $"   {treatmentNumber}    {playerName}   {score}     {miniGameName}   {level}      {roundedTime}              {objectCount}           {fechaFormateada}\n";
    }

            // Asigna el texto construido al objeto Text o TextMeshPro
            tablaText.text = tablaTexto;
                RectTransform rectTransform = tablaText.GetComponent<RectTransform>();
    rectTransform.anchoredPosition = new Vector2(0, -50); // Ajusta estos valores según tu diseño

            // Cierra el lector y el comando después de usarlos
            reader.Close();
            dbCommand.Dispose();
        }
    }