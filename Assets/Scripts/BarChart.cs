using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class BarChartUI : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset barPrefab;
    [SerializeField] private VisualTreeAsset labelPrefab;

    void Start()
    {
        // Crear un contenedor para el gráfico de barras
        var container = new VisualElement();
        container.style.flexDirection = FlexDirection.Row;
        container.style.flexWrap = Wrap.Wrap;
        container.style.width = 400;
        container.style.height = 200;

        // Agregar barras al contenedor (cambiar estos valores según tus datos)
        for (int i = 0; i < 5; i++)
        {
            var bar = barPrefab.CloneTree();
            bar.Q<Label>().text = Random.Range(10, 100).ToString(); // Valor de la barra
            container.Add(bar);

            var label = labelPrefab.CloneTree();
            label.Q<Label>().text = "Label " + (i + 1); // Etiqueta de la barra
            container.Add(label);
        }

        // Agregar el contenedor a la jerarquía de UI
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Add(container);
    }
}