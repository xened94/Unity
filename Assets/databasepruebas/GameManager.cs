using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using recolectarpruebas;
using scorepruebas;
using dbpruebas;


namespace dbgm
{
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool juegoPausado = false;
    public GameObject ball;
    public Rigidbody ballRB;    
    public string messageWB;
    public string playerName = "";
    public bool usarMovimientoIzquierda = true;
    public DatabaseManager databaseManager;
    private float tiempoDelJuego;
    private int objetosObtenidos;
    private int tratamientoActual = 1;
    private string level;
    private string nombreMinijuego;
    public Recolectar recolectarScript;
    private Score scoreScript;
      private Vector3 lastCalledDirection;

    private void Awake()
    {
        // Obtener la preferencia del jugador y configurar usarMovimientoIzquierda
        int preferenciaMovimiento = PlayerPrefs.GetInt("UsarMovimientoIzquierda", 1); // 1 para izquierda, 0 para derecha
        usarMovimientoIzquierda = (preferenciaMovimiento == 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = FindObjectOfType<Score>();
        databaseManager = FindObjectOfType<DatabaseManager>();
        recolectarScript = FindObjectOfType<Recolectar>();
        ball = GameObject.Find("Sphere");
        ballRB = ball.GetComponent<Rigidbody>();
    }

   void Update()
{
    // Manejo de la tecla "R" para pausar/reanudar el juego
    if (Input.GetKeyDown(KeyCode.R))
    {
        CambiarEstadoJuego();
    }
}

public void SimularTeclaPresionada(KeyCode key)
{
    // Simular la tecla presionada según la lógica actual
    if (usarMovimientoIzquierda)
    {
        // Casos para el movimiento de izquierda
        switch (key)
        {
            case KeyCode.RightArrow:
                messageWB = "LDerecha";
                break;
            case KeyCode.LeftArrow:
                messageWB = "LIzquierda";
                break;
            case KeyCode.UpArrow:
                messageWB = "LAdelante";
                break;
            case KeyCode.DownArrow:
                messageWB = "LAbajo";
                break;
        }
    }
    else
    {
        // Casos para el movimiento de derecha
        switch (key)
        {
            case KeyCode.D:
                messageWB = "Derecha";
                break;
            case KeyCode.A:
                messageWB = "Izquierda";
                break;
            case KeyCode.W:
                messageWB = "Adelante";
                break;
            case KeyCode.S:
                messageWB = "Abajo";
                break;
        }
    }
}
 

  public static void CambiarEstadoJuego()
{
    juegoPausado = !juegoPausado;

    if (juegoPausado)
    {
        // Pausar el juego completamente
        Time.timeScale = 0;
    }
    else
    {
        // Reanudar el juego
        Time.timeScale = 1;
    }
}

    public void SetPlayerName(string name)
    {
        playerName = name;
        recolectarScript.SetPlayerName(name);
    }

public void BotonIzquierdaPresionado()
{
    usarMovimientoIzquierda = true;
    Debug.Log("Botón Izquierda presionado. Terapia de mano: Izquierda");
}

public void BotonDerechaPresionado()
{
    usarMovimientoIzquierda = false;
    Debug.Log("Botón Derecha presionado. Terapia de mano: Derecha");
}


 public void FinalizarJuego()
    {
        // Asegurémonos de tener una referencia válida a RecolectarScript
           if (recolectarScript == null || scoreScript == null)
        {
             Debug.LogError("No se encontró un objeto con el script Recolectar o Score en la escena.");
        return;
        }

        // Ahora puedes usar recolectarScript en el resto del método
        
       
        int score = recolectarScript.puntajeTotal;
        float time = scoreScript.ObtenerTiempoTotal();
        string miniGameName = nombreMinijuego; // Reemplaza esto con el nombre real del minijuego
        
        int objectCount = Mathf.FloorToInt(score / 10.0f); // Calcula objetos obtenidos
        
        // Obtén el puntaje total desde el script Recolectar
         string playerName = recolectarScript.ObtenerNombreJugador();

        // Inserta los datos en la base de datos utilizando el tratamiento actual
       string level = usarMovimientoIzquierda ? "Izquierda" : "Derecha";
        databaseManager.InsertarDatosDelJuego(score, miniGameName, level, time, objectCount, tratamientoActual, playerName);

        // Incrementa el tratamientoActual para el próximo juego
        tratamientoActual++;
    }

    public static void FinalizarJuegoStatic()
    {
        // Accede a la instancia actual de GameManager
        GameManager instance = FindObjectOfType<GameManager>();
        if (instance != null)
        {
            instance.FinalizarJuego();
        }
        else
        {
            Debug.LogError("No se encontró una instancia de GameManager.");
        }
    }

        public void SetNombreMinijuego(string nombre)
    {
        nombreMinijuego = nombre;
    }
    private IEnumerator RealizarMovimientos(GameManager gameManager, KeyCode key, int count)
{
    for (int i = 0; i < count; i++)
    {
        // Simula la tecla presionada
        gameManager.SimularTeclaPresionada(key);

        // Espera un frame para que el GameManager procese la entrada
        yield return null;

        // Registra el movimiento
        RegistrarMovimiento(gameManager, key);
    }
}

private void RegistrarMovimiento(GameManager gameManager, KeyCode key)
{
    // Determina el mensaje correspondiente al movimiento
    string messageWB = gameManager.usarMovimientoIzquierda ? GetLeftMessage(key) : GetRightMessage(key);

    // Registra el movimiento en la consola
    Debug.Log($"Movimiento realizado: {messageWB}");

    // Aplica la lógica de fuerza según el mensaje
    ApplyForceByMessage(gameManager.ballRB, messageWB);
}

private string GetLeftMessage(KeyCode key)
{
    switch (key)
    {
        case KeyCode.RightArrow:
            return "LDerecha";
        case KeyCode.LeftArrow:
            return "LIzquierda";
        case KeyCode.UpArrow:
            return "LAdelante";
        case KeyCode.DownArrow:
            return "LAbajo";
        default:
            return "";
    }
}

private string GetRightMessage(KeyCode key)
{
    switch (key)
    {
        case KeyCode.D:
            return "Derecha";
        case KeyCode.A:
            return "Izquierda";
        case KeyCode.W:
            return "Adelante";
        case KeyCode.S:
            return "Abajo";
        default:
            return "";
    }
}

private void ApplyForceByMessage(Rigidbody ballRB, string messageWB)
{
    // Casos para el movimiento de izquierda
    switch (messageWB)
    {
        case "LDerecha":
            ballRB.AddForce(Vector3.right * 0.5f);
            break;
        case "LIzquierda":
            ballRB.AddForce(Vector3.left * 0.5f);
            break;
        case "LAdelante":
            ballRB.AddForce(Vector3.forward * 0.5f);
            break;
        case "LAbajo":
            ballRB.AddForce(Vector3.back * 0.5f);
            break;
        // Casos para el movimiento de derecha
        case "Derecha":
            ballRB.AddForce(Vector3.right * 0.5f);
            break;
        case "Izquierda":
            ballRB.AddForce(Vector3.left * 0.5f);
            break;
        case "Adelante":
            ballRB.AddForce(Vector3.forward * 0.5f);
            break;
        case "Abajo":
            ballRB.AddForce(Vector3.back * 0.5f);
            break;
    }
}

        public void RealizarMovimiento(Vector3 direccion)
        {
            ballRB.AddForce(direccion * 0.5f);
            Debug.Log($"Movimiento realizado: {direccion}");

            // Almacena la última dirección llamada
            lastCalledDirection = direccion;
        }

private Vector3 GetForceByMessage(string message)
{
    switch (message)
    {
        case "LDerecha":
            return Vector3.right * 0.5f;
        case "LIzquierda":
            return Vector3.left * 0.5f;
        case "LAdelante":
            return Vector3.forward * 0.5f;
        case "LAbajo":
            return Vector3.back * 0.5f;
        case "Derecha":
            return Vector3.right * 0.5f;
        case "Izquierda":
            return Vector3.left * 0.5f;
        case "Adelante":
            return Vector3.forward * 0.5f;
        case "Abajo":
            return Vector3.back * 0.5f;
        default:
            return Vector3.zero;
    }
}


public bool HasCalledRealizarMovimientoWithDirection(Vector3 expectedDirection)
{
    return lastCalledDirection == expectedDirection;
}

}
}