using UnityEngine;

public class Obstaculo : Collectable
{
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float tiempoReaparicion = 3f; // 

    protected override void OnPlayerDetected(PlayerControler playerScript)
    {
        base.OnPlayerDetected(playerScript);
        playerScript.recibirDaño(damageAmount);  

      
        gameObject.SetActive(false);
        Invoke(nameof(Reaparecer), tiempoReaparicion);
    }

    private void Reaparecer()
    {
        gameObject.SetActive(true);
    }
}
