using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using rampa;



    [TestFixture]
    public class CajaBlancaObjetosGeneratorRampa
    {
        [UnityTest]
        public IEnumerator GenerateObjects_CorrectNumberOfInstances()
        {
            // Arrange
            var objetosGeneratorRampaObject = new GameObject();
            var objetosGeneratorRampa = objetosGeneratorRampaObject.AddComponent<ObjetosGeneratorRampa>();

            // Act
            yield return null; // Espera un frame para que Start se ejecute automáticamente

            // Accede al resultado después de que se ha ejecutado la lógica de GenerateObjects
            int generatedObjectsCount = objetosGeneratorRampa.generatedObjectsCount;
             Debug.Log("Número de objetos generados: " + generatedObjectsCount);
            // Assert
           Assert.AreEqual(100, generatedObjectsCount, "El número de objetos generados no es el esperado.");
        }


    }

