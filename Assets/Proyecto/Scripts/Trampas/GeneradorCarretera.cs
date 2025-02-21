using System.Collections.Generic;
using UnityEngine;

public class GeneradorCarretera : MonoBehaviour
{
    public GameObject[] prefabsCarretera; 
    public Transform jugador;             
    public float largoCarretera = 10f;     
    public int maxCarreteras = 5;          
    public float distanciaGeneracion = 30f; 

    public GameObject[] prefabsItems; 

    private List<GameObject> carreterasActivas = new List<GameObject>();
    private float siguientePosZ = 0f; 

    void Start()
    {
        for (int i = 0; i < maxCarreteras; i++)
        {
            GenerarCarretera();
        }
    }

    void Update()
    {
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

        int indice = Random.Range(0, prefabsCarretera.Length);
        GameObject prefabSeleccionado = prefabsCarretera[indice];

        GameObject nuevaCarretera = Instantiate(prefabSeleccionado, new Vector3(0, 0, siguientePosZ), Quaternion.identity);
        carreterasActivas.Add(nuevaCarretera);

        // Buscar el objeto vacío "PuntosSpawn"
        Transform puntosSpawn = nuevaCarretera.transform.Find("PuntosSpawn");
        if (puntosSpawn != null)
        {
            foreach (Transform punto in puntosSpawn)
            {
                GenerarItem(punto.position);
            }
        }

        siguientePosZ += largoCarretera;
    }

    void GenerarItem(Vector3 posicion)
    {
        if (prefabsItems.Length == 0) return;

        int indice = Random.Range(0, prefabsItems.Length);
        GameObject itemSeleccionado = prefabsItems[indice];

        Instantiate(itemSeleccionado, posicion, Quaternion.identity);
    }

    void EliminarCarreteraAntigua()
    {
        if (carreterasActivas.Count > maxCarreteras)
        {
            GameObject carreteraAEliminar = carreterasActivas[0];
            carreterasActivas.RemoveAt(0);
            Destroy(carreteraAEliminar);
        }
    }
}
