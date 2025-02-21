using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public float velocidad = 10f;        
    public float fuerzaSalto = 8f;       
    public float desplazamientoX = 3f;   
    private int carrilActual = 1;
    public int salud = 200; 

    public GameObject hasPerdidoCanvas;   
    public int punto = 1;
    public Slider barraDeVida; 

    public AudioSource musicaPrincipal;
    public AudioSource musicaPerdida;
    public AudioSource sonidoDaño; 

    public ParticleSystem particulasDaño; 

    private Rigidbody rb;
    private bool enSuelo = true;
    private bool juegoTerminado = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (barraDeVida != null)
        {
            barraDeVida.maxValue = salud;
            barraDeVida.value = salud;
        }
    }   

    void Update()
    {
        if (juegoTerminado) return;

        transform.position += Vector3.forward * velocidad * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && carrilActual > 0)
        {
            carrilActual--; 
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && carrilActual < 2)
        {
            carrilActual++; 
        }

        Vector3 nuevaPos = new Vector3(carrilActual * desplazamientoX - desplazamientoX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, nuevaPos, Time.deltaTime * 10f);

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    public void recibirDaño(int Daño)
    {
        if (juegoTerminado) return; 

        salud -= Daño; 

        if (barraDeVida != null)
        {
            barraDeVida.value = salud;
        }

        if (sonidoDaño != null)
        {
            sonidoDaño.Play(); 
        }

        if (particulasDaño != null)
        {
            particulasDaño.Play(); 
        }

        if (salud <= 0)
        {
            PerderJuego();
        }
    }

    private void PerderJuego()
    {
        if (juegoTerminado) return; 

        juegoTerminado = true;
        hasPerdidoCanvas.SetActive(true);

        if (musicaPrincipal != null && musicaPrincipal.isPlaying)
        {
            musicaPrincipal.Stop(); 
        }

        if (musicaPerdida != null && !musicaPerdida.isPlaying)
        {
            musicaPerdida.Play();
            musicaPerdida.loop = false; 
        }
    }
}
