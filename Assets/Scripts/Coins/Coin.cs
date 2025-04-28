using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Image Image;
    public int Value;
    private bool _isMoving = true;
    private Vector2 _direction;
    private Vector2 _position;
    private float _fallingSpeed = 0f;

    public static Coin Create(Image imageToClone, int value, Vector2 position)
    {
        GameObject coinObject = new GameObject("Coin");
        Coin coin = coinObject.AddComponent<Coin>();

        coin.Image = Instantiate(imageToClone, imageToClone.transform.parent);
        coin.Image.transform.position = position.ToNewVector2();
        coin._position = position.ToNewVector2();
        coin.Image.transform.localScale = imageToClone.transform.localScale;
        coin.Image.color = coin.Image.color.GetVisibleColor();
        coin.Value = value;

        coin._direction = new Vector2(Random.Range(-30, 30)/30000f, Random.Range(10, 30) / 30000f);

        return coin;

    }
    
    public void Pickup()
    {
        Account account = Account.GetCurrentAccount();
        account.AccountStats.Coins += Value;
        Debug.Log("Pickup " + account.AccountStats.Coins);
        account.SaveData();
    }

    public void Hide()
    {
        Image.color = Image.color.GetTransparentColor();
        //Destroy(Image);
    }

    public void Update()
    {
        
        if(_isMoving)
        {
            _fallingSpeed += 0.001f * Time.deltaTime;
            _position = new Vector2(_position.x + _direction.x, _position.y + (_direction.y - _fallingSpeed));
            Image.transform.position = _position.ToNewVector2();
            if (_fallingSpeed > 0.004f) _isMoving = false;
        }
    }
}
