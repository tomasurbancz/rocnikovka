using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{
    private List<Coin> _coins;
    public Canvas Canvas;
    public Image CoinImage;
    private CoinTracker _coinTracker;

    // Start is called before the first frame update
    void Start()
    {
        _coins = new List<Coin>();
    }

    public CoinTracker SpawnCoins(int value, int coins, Vector2 position)
    {
        for(int i = 0; i < coins; i++)
        {
            _coins.Add(Coin.Create(CoinImage, value, position));
        }
        _coinTracker = new CoinTracker(coins);
        return _coinTracker;
    }

    // Update is called once per frame
    void Update()
    {
        List<Coin> coinsToRemove = new List<Coin>();
        foreach (var coin in _coins)
        {
            coin.Update();
            if(RectTransformUtility.RectangleContainsScreenPoint(
                coin.Image.rectTransform,
                Input.mousePosition,
                Canvas.worldCamera
            ))
            {
                coin.Hide();
                coinsToRemove.Add(coin);
                _coinTracker.Remaining -= 1;
            }
        }
        foreach(var coin in coinsToRemove)
        {
            _coins.Remove(coin);
        }
    }
}
