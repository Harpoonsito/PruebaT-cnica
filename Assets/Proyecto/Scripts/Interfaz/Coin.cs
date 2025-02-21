using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RapidFireTactics
{
    public class Coin : Collectable
    {
        protected override void OnPlayerDetected(PlayerControler playerScript)
        {
            base.OnPlayerDetected(playerScript);

            //Call the score manager to add point
        }
    }
}
