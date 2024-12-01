using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private CircleCollider2D CircleCollider;
    [SerializeField] private GameObject Player;
    private PlayerMovement PlayerMovement;
    public int Point;

    private void Awake()
    {
        PlayerMovement = Player.GetComponent<PlayerMovement>();
        CircleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Point += 1;
            transform.position = new Vector2(Random.Range(PlayerMovement.MinX, PlayerMovement.MaxX), Random.Range(PlayerMovement.MinY, PlayerMovement.MaxY));
        }
    }








}
