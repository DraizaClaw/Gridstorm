using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    private CircleCollider2D CircleCollider;
    [SerializeField] private GameObject Player;
    private PlayerMovement PlayerMovement;
    public int Point;

    public Text CoinsText;

    private void Awake()
    {
        PlayerMovement = Player.GetComponent<PlayerMovement>();
        CircleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        CoinsText.text = ("Coins: " + PlayerPrefs.GetInt("Coins"));
        if (Input.GetKey(KeyCode.O))
        {
            PlayerPrefs.SetInt("Coins", 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.position = new Vector2(Random.Range(PlayerMovement.MinX, PlayerMovement.MaxX), Random.Range(PlayerMovement.MinY, PlayerMovement.MaxY));
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
        }
    }









}
