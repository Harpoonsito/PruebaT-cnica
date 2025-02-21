using UnityEngine;
using TMPro; 

public class Puntuacion : MonoBehaviour
{
    public static Puntuacion instance;
    public TextMeshProUGUI textoPuntos;
    private int puntos = 0;

    void Awake()
    {
        instance = this;
    }

    public void AgregarPuntos(int cantidad)
    {
        puntos += cantidad;
        textoPuntos.text = "Puntos: " + puntos;
    }
}
