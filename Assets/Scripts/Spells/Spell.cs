using System;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected float Damage;
    [SerializeField] protected float Radius;
    [SerializeField] protected float Cooldown;

    protected KeyCode KeyActive;
    protected bool IsSpellReady = true;

    public event Action<float, float> ChargeChenged;

    public abstract void Activate();

    protected void SendMessageAboutChargeChenge(float value, float maxValue)
    {
        ChargeChenged?.Invoke(value, maxValue);
    }
}
