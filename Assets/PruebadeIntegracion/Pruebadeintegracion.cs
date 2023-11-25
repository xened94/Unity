using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using dbgm;
using System.Collections;

namespace Tests
{
    public class Pruebadeintegracion
    {
        [UnityTest]
        public IEnumerator TTest6Movimientos()
        {
            // Configuración de la prueba
            GameObject gameManagerObject = new GameObject();
            GameManager gameManager = gameManagerObject.AddComponent<GameManager>();

            // Inicia la prueba directamente, sin cargar la escena
            gameManager.BotonIzquierdaPresionado();

            // Realiza aserciones básicas
            Assert.IsTrue(gameManager.usarMovimientoIzquierda);

            // Realiza 4 movimientos de la mano izquierda
            yield return RealizarMovimientos(gameManager, KeyCode.LeftArrow, 4);

            // Realiza 2 movimientos de la mano derecha (deberían fallar)
            yield return RealizarMovimientos(gameManager, KeyCode.D, 2);

            yield return RealizarMovimientos(gameManager, KeyCode.A, 2);
            yield return RealizarMovimientos(gameManager, KeyCode.RightArrow, 4);

            // Limpieza después de la prueba (si es necesario)
            GameObject.DestroyImmediate(gameManagerObject);
        }

        [UnityTest]
        public IEnumerator TestMovimientoDerecha()
        {
            GameObject gameManagerObject = new GameObject();
            GameManager gameManager = gameManagerObject.AddComponent<GameManager>();

            // Realiza un movimiento hacia la derecha
            gameManager.RealizarMovimiento(Vector3.right);

            // Espera un frame para que el GameManager procese la entrada
            yield return null;

            // Verifica si se llamó a RealizarMovimiento con la dirección correcta
            Vector3 expectedDirection = Vector3.right;
            Assert.IsTrue(gameManager.HasCalledRealizarMovimientoWithDirection(expectedDirection));

            // Limpia la escena después de la prueba
            GameObject.DestroyImmediate(gameManagerObject);
        }

        [UnityTest]
        public IEnumerator TestMovimientoIzquierdaAdelante()
        {
            GameObject gameManagerObject = new GameObject();
            GameManager gameManager = gameManagerObject.AddComponent<GameManager>();

            // Realiza un movimiento hacia adelante
            gameManager.RealizarMovimiento(Vector3.left);

            // Espera un frame para que el GameManager procese la entrada
            yield return null;

            // Verifica si se llamó a RealizarMovimiento con la dirección correcta
            Vector3 expectedDirection = Vector3.left;
            Assert.IsTrue(gameManager.HasCalledRealizarMovimientoWithDirection(expectedDirection));

            // Limpia la escena después de la prueba
            GameObject.DestroyImmediate(gameManagerObject);
        }

        private IEnumerator RealizarMovimientos(GameManager gameManager, KeyCode key, int count)
        {
            for (int i = 0; i < count; i++)
            {
                // Simula la tecla presionada
                gameManager.SimularTeclaPresionada(key);

                // Espera un frame para que el GameManager procese la entrada
                yield return null;

                // Llama al método RealizarMovimiento con la dirección correcta
                Vector3 direccion = Vector3.zero;

                if (gameManager.usarMovimientoIzquierda)
                {
                    // Casos para el movimiento de izquierda
                    switch (key)
                    {
                        case KeyCode.RightArrow:
                            direccion = Vector3.right;
                            break;
                        case KeyCode.LeftArrow:
                            direccion = Vector3.left;
                            break;
                        case KeyCode.UpArrow:
                            direccion = Vector3.forward;
                            break;
                        case KeyCode.DownArrow:
                            direccion = Vector3.back;
                            break;
                    }
                }
                else
                {
                    // Casos para el movimiento de derecha
                    switch (key)
                    {
                        case KeyCode.D:
                            direccion = Vector3.right;
                            break;
                        case KeyCode.A:
                            direccion = Vector3.left;
                            break;
                        case KeyCode.W:
                            direccion = Vector3.forward;
                            break;
                        case KeyCode.S:
                            direccion = Vector3.back;
                            break;
                    }
                }

                gameManager.RealizarMovimiento(direccion);

                // Verifica los logs
                Debug.Log($"Movimiento realizado: {key}");
            }
        }
    }
}
