using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerControler : MonoBehaviour
{
    public float velocidad = 10f;        
    public float fuerzaSalto = 8f;       
    public float desplazamientoX = 3f;   
    private int carrilActual = 1;
    public int salud = 200; 
    public GameObject hasPerdidoCanvas;   


    private Rigidbody rb;
    private bool enSuelo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }   

    void Update()
    {
       
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
       salud -= Daño; 
       if (salud <= 0)
       {
        hasPerdidoCanvas.SetActive(true);
       }
    }
}
