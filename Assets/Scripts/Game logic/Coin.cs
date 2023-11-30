using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, startPos.y + Mathf.Sin(Time.timeSinceLevelLoad * 2) * 0.25F);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManagerScr.Instance.CollectCoin();
            Destroy(gameObject);
        }
    }
}