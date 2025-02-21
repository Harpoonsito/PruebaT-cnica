using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RapidFireTactics
{
    public class Obstacle : Collectable
    {
        [SerializeField] private int damageAmount = 10;

        protected override void OnPlayerDetected(PlayerScript playerScript)
        {
            base.OnPlayerDetected(playerScript);

            //Decrease Life of player
            //Maybe the player has a script of health
            //playerScript.GetComponent<Health>().TakeDamage(damageAmount);

            //The player must have the logic of animations or something
        }
    }
}
