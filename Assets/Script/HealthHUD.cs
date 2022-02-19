using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        health.OnDamage += UpdateHUD;
        health.OnHealing += UpdateHUD;
    }

    private void OnDestroy()
    {
        health.OnDamage -= UpdateHUD;
        health.OnHealing -= UpdateHUD;
    }

    public void UpdateHUD(int amount)
    {
        float perc = Mathf.Max(0f, (float)health.CurrentHealth / (float)health.MaxHealth);
        slider.value = perc;
    }

    private void Reset()
    {
        slider = GetComponent<Slider>();
    }
}
