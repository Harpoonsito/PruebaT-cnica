using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Obstaculo : Collectable
    {
        [SerializeField] private int damageAmount = 10;

        protected override void OnPlayerDetected(PlayerControler playerScript)
        {
            base.OnPlayerDetected(playerScript);
            playerScript.recibirDaño(damageAmount);   
        }
    }

