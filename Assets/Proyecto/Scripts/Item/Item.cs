using UnityEngine;

public class Item : MonoBehaviour
{
    public int puntos = 10;  
    public GameObject efectoParticulas; // Prefab de partículas
    public AudioClip sonidoRecolectar; // Sonido de recolección

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reproducir el sonido
            AudioSource.PlayClipAtPoint(sonidoRecolectar, transform.position);

            // Instanciar el efecto de partículas
            if (efectoParticulas != null)
            {
                Instantiate(efectoParticulas, transform.position, Quaternion.identity);
            }

            // Sumar puntos y destruir el objeto
            Puntuacion.instance.AgregarPuntos(puntos);
            Destroy(gameObject);
        }
    }
}
