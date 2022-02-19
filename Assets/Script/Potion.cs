using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, ICatchable
{
    public void Use(PlayerEntity playerEntity)
    {
        if (playerEntity.Health.CurrentHealth < playerEntity.Health.MaxHealth)
        {
            Debug.Log(playerEntity.Health.CurrentHealth + " . " + playerEntity.Health.MaxHealth);
            playerEntity.Health.HealingSpell(4);
            gameObject.SetActive(false);
        }
    }
}
