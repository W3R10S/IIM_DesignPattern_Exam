using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IHealth
{
    // Champs
    [SerializeField] int _startHealth;
    [SerializeField] int _maxHealth;
    [SerializeField] AudioClip[] audioclips = new AudioClip[0];
    [SerializeField] UnityEvent _onDeath;
    [SerializeField] UnityEvent<AudioClip> _onDeathSound;
    [SerializeField] UnityEvent<int> _onDamage;
    [SerializeField] UnityEvent<Transform> _onDeathExplosion;

    // Propriétés
    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;
    public bool IsDead => CurrentHealth <= 0;
    public bool canTakeDamage = true;

    // Events
    public event UnityAction OnSpawn;
    public event UnityAction<int> OnDamage { add => _onDamage.AddListener(value); remove => _onDamage.RemoveListener(value); }
    public event UnityAction<int> OnHealing;
    public event UnityAction OnDeath { add => _onDeath.AddListener(value); remove => _onDeath.RemoveListener(value); }

    // Methods
    void Awake() => Init();

    void Init()
    {
        CurrentHealth = _startHealth;
        OnSpawn?.Invoke();
    }

    public void TakeDamage(int amount)
    {
        if (!canTakeDamage) return;

        if (amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negativ");

        var tmp = CurrentHealth;
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        var delta = CurrentHealth - tmp;
        _onDamage?.Invoke(delta);

        Debug.Log("Vie actuelle : " + CurrentHealth);

        if (CurrentHealth <= 0)
        {
            _onDeath?.Invoke();
            _onDeathSound?.Invoke(audioclips[UnityEngine.Random.Range(0, audioclips.Length)]);
            _onDeathExplosion?.Invoke(transform);
        }

    }

    public void HealingSpell(int amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Min(CurrentHealth, MaxHealth);
        OnHealing?.Invoke(CurrentHealth);
    }

    [Button("test")]
    void MaFonction()
    {
        var enumerator = MesIntPrefere();

        while(enumerator.MoveNext())
        {
            Debug.Log(enumerator.Current);
        }
    }


    List<IEnumerator> _coroutines;

    IEnumerator<int> MesIntPrefere()
    {

        //

        var age = 12;

        yield return 12;


        //

        yield return 3712;

        age++;
        //

        yield return 0;



        //
        yield break;
    }

}
