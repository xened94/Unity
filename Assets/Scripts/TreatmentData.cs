using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite;

[System.Serializable]
public class TreatmentData
{
    [PrimaryKey, AutoIncrement] // Esto indica que será la clave primaria de la tabla
    public int treatmentNumber { get; set; }
    public string playerName { get; set; }
    public string date { get; set; }
    public int score { get; set; }
    public string miniGameName { get; set; }
    public string level { get; set; } // Cambiado de int a string
    public float time { get; set; }
    public int objectCount { get; set; }

    // Puedes agregar más campos según sea necesario
}
