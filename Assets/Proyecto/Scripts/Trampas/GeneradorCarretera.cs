using System.Collections.Generic;
using UnityEngine;

public class GeneradorCarretera : MonoBehaviour
{
    public GameObject[] prefabsCarretera; // Array de prefabs de carretera
    public Transform jugador;             // Referencia al jugador
    public float largoCarretera = 10f;    // Largo de cada segmento de carretera
    public int maxCarreteras = 5;         // Máximo de segmentos en pantalla
    public float distanciaGeneracion = 30f; // Distancia para generar la siguiente carretera

    private List<GameObject> carreterasActivas = new List<GameObject>();
    private float siguientePosZ = 0f; // Posición de la siguiente carretera

    void Start()
    {
        // Generar los primeros segmentos de carretera
        for (int i = 0; i < maxCarreteras; i++)
        {
            GenerarCarretera();
        }
    }

    void Update()
    {
        // Si el jugador se acerca al final de la última carretera activa, generar un nuevo tramo
        if (jugador.position.z > siguientePosZ - distanciaGeneracion)
        {
            GenerarCarretera();
            EliminarCarreteraAntigua();
        }
    }

    void GenerarCarretera()
    {
        if (prefabsCarretera.Length == 0)
        {
            Debug.LogError("No hay prefabs de carretera asignados.");
            return;
        }

        // Seleccionar un prefab de carretera aleatorio
        int indice = Random.Range(0, prefabsCarretera.Length);
        GameObject prefabSeleccionado = prefabsCarretera[indice];

        // Instanciar en la posición correcta
        GameObject nuevaCarretera = Instantiate(prefabSeleccionado, new Vector3(0, 0, siguientePosZ), Quaternion.identity);
        nuevaCarretera.SetActive(true);
        carreterasActivas.Add(nuevaCarretera);

        // Avanzar la posición para el siguiente tramo
        siguientePosZ += largoCarretera;
    }

    void EliminarCarreteraAntigua()
    {
        // Eliminar la carretera más antigua si hay demasiados segmentos en pantalla
        if (carreterasActivas.Count > maxCarreteras)
        {
            GameObject carreteraAEliminar = carreterasActivas[0]; // Primer segmento
            carreterasActivas.RemoveAt(0); // Remover de la lista
            Destroy(carreteraAEliminar); // Destruir en la escena
        }
    }
}
