using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    [SerializeField] float _dropSpeed = .75f;

    private Rigidbody2D rigidbody2D;
    private GameSession _gameSession;


    private void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _gameSession = GameObject.Find("GameSession").GetComponent<GameSession>();
    }

    private void Update()
    {
        if (gameObject.transform.position.y <= -1)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity += Vector2.down * _dropSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Paddle>() != null)
        {
            if (gameObject.tag == "Heart" && _gameSession.PlayerLives + 1 <= 5)
            {
                _gameSession.PlayerLives += 1;
            }
            else if (gameObject.tag == "Gear")
            {
                _gameSession.IncreasePaddleSize();
            }
            else if (gameObject.tag == "Blue_Bottle")
            {
                _gameSession.IncreasePaddleSpeed();
            }
            else if (gameObject.tag == "Empty_Bottle")
            {
                _gameSession.RemoveAllEffect();
            }

            Destroy(gameObject);
        }
    }

}
