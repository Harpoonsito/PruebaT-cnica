using UnityEngine;

public class Item : MonoBehaviour
{
    public int puntos = 10;  
    public GameObject efectoParticulas; 
    public AudioClip sonidoRecolectar; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            AudioSource.PlayClipAtPoint(sonidoRecolectar, transform.position);

            
            if (efectoParticulas != null)
            {
                Instantiate(efectoParticulas, transform.position, Quaternion.identity);
            }

            
            Puntuacion.instance.AgregarPuntos(puntos);
            Destroy(gameObject);
        }
    }
}
