using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBlock : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] SpriteRenderer shieldDisplay;
    [SerializeField] SpriteRenderer bowDisplay;

    public void BlockBullet(bool isBlocking)
    {
        health.canTakeDamage = !isBlocking;

        if(isBlocking)
        {
            shieldDisplay.gameObject.SetActive(true);
            bowDisplay.gameObject.SetActive(false);
        } else
        {
            shieldDisplay.gameObject.SetActive(false);
            bowDisplay.gameObject.SetActive(true);
        }
    }
}
