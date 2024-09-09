using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCollisionHandler : MonoBehaviour
{
    public event Action<Coin> CoinIsRaised;
    public event Action<MedicalKit> MedicalKitIsRaised;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
            CoinIsRaised?.Invoke(coin);

        if (collision.TryGetComponent(out MedicalKit medicalKit))
            MedicalKitIsRaised?.Invoke(medicalKit);
    }
}
