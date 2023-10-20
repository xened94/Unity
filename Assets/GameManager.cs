using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeWebSocket;

public class GameManager : MonoBehaviour
{
    
    public static bool juegoPausado = false;
    public GameObject ball;
    public Rigidbody ballRB;
    public string messageWB;
    WebSocket websocket;

    // Start is called before the first frame update
    async void Start()
    {
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
            Debug.Log(messageWB);

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



}