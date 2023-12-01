using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    //* ESSE SCRIPT CRIA A REPRESENTAÇÃO VISUAL DE UMA FUNÇÃO SENO USANDO LINE RENDERER

    //* ADICIONE ESTE SCRIPT À UM OBJETO VAZIO NO CENÁRIO

    public int resolution = 100; // Número de pontos na linha
    public float amplitude = 1f; // Amplitude da função seno
    public float frequency = 1f; // Frequência da função seno

    private LineRenderer lineRenderer;

 
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = resolution;

        // Define a espessura da linha
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // Define o número de vértices de tampa para arredondar os finais da linha
        lineRenderer.numCornerVertices = 10;
        lineRenderer.numCapVertices = 10;

        float width = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        float step = width / (resolution - 1);

        for (int i = 0; i < resolution; i++)
        {
            float x = i * step - width / 2;
            float y = amplitude * Mathf.Sin(2 * Mathf.PI * frequency * x);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }

}
