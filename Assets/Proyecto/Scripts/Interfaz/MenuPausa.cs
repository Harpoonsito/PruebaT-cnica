using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject botonMenu; // Botón para volver al menú principal
    [SerializeField] private AudioSource musicaJuego; // AudioSource de la música

    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        botonMenu.SetActive(true); // Mostrar botón de menú

        // Pausar la música
        if (musicaJuego != null)
        {
            musicaJuego.Pause();
        }
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        botonMenu.SetActive(false); // Ocultar botón de menú

        // Reanudar la música
        if (musicaJuego != null)
        {
            musicaJuego.Play();
        }
    }

    public void IrAlMenuPrincipal()
    {
        Time.timeScale = 1f; // Asegurar que el tiempo vuelva a la normalidad
        SceneManager.LoadScene("MenuPrincipal"); // Cargar la escena del menú principal
    }
}
