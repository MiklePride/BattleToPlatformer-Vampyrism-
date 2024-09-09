using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private LootCollisionHandler _lootCollisionHandler;

    private int _coin;

    private void OnEnable()
    {
        _lootCollisionHandler.CoinIsRaised += OnAddCoin;
    }

    private void OnDisable()
    {
        _lootCollisionHandler.CoinIsRaised += OnAddCoin;
    }

    private void OnAddCoin(Coin coin)
    {
        _coin += Mathf.Abs(coin.Count);
        Destroy(coin.gameObject);
    }
}
