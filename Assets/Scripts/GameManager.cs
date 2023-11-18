using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NativeWebSocket;
using Mono.Data.Sqlite;

public class GameManager : MonoBehaviour
{
       public static GameManager instance;
    public static bool juegoPausado = false;
    public GameObject ball;
    public Rigidbody ballRB;
    public string messageWB;
    WebSocket websocket;
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


    private void Awake()
    {
        // Obtener la preferencia del jugador y configurar usarMovimientoIzquierda
        int preferenciaMovimiento = PlayerPrefs.GetInt("UsarMovimientoIzquierda", 1); // 1 para izquierda, 0 para derecha
        usarMovimientoIzquierda = (preferenciaMovimiento == 1);
    }

    // Start is called before the first frame update
    async void Start()
    
    {
         scoreScript = FindObjectOfType<Score>();
      databaseManager = FindObjectOfType<DatabaseManager>();
        recolectarScript = FindObjectOfType<Recolectar>(); // Mueve la inicialización aquí
        ball = GameObject.Find("Sphere");
        ballRB = ball.GetComponent<Rigidbody>();
        websocket = new WebSocket("ws://localhost:3000");

        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
        };

        websocket.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
        };

        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };

        websocket.OnMessage += (bytes) =>
        {
            //Debug.Log("OnMessage!");
            //Debug.Log(bytes);

            // getting the message as a string
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            messageWB = message;
            Debug.Log("OnMessage! " + message);
        };

        // Keep sending messages at every 0.3s
        InvokeRepeating("SendWebSocketMessage", 0.0f, 0.3f);

        // waiting for messages
        await websocket.Connect();
    }

    void Update()
    
    {
#if !UNITY_WEBGL || UNITY_EDITOR
    websocket.DispatchMessageQueue();
#endif

if (!string.IsNullOrEmpty(messageWB))
{
    if (usarMovimientoIzquierda)
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
        }
    }
    else
    {
        // Casos para el movimiento de derecha
        switch (messageWB)
        {
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
}
    
           // Manejo de la tecla "R" para pausar/reanudar el juego
        if (Input.GetKeyDown(KeyCode.R))
        {
            CambiarEstadoJuego();
        }
    
    }

    async void SendWebSocketMessage()
    {
        if (websocket.State == WebSocketState.Open)
        {
            // Sending bytes
            await websocket.Send(new byte[] { 10, 20, 30 });

            // Sending plain text
            await websocket.SendText("plain text message");
        }
    }

    private async void OnApplicationQuit()
    {
        await websocket.Close();
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
    Debug.Log("Botón Izquierda presionado. Nueva dirección: Izquierda");
}

public void BotonDerechaPresionado()
{
    usarMovimientoIzquierda = false;
    Debug.Log("Botón Derecha presionado. Nueva dirección: Derecha");
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


    

}