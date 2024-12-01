using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private BoxCollider2D BoxCollider;
    [SerializeField] private GameObject Player;


    private void Awake()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
        Destroy(this.gameObject, 10f);


        rb.AddForceAtPosition(Player.transform.position, Player.transform.position);//no work

        Vector2 newPosition = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * speed);
        rb.MovePosition(newPosition);


        transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(Player.transform.position - transform.position),
                                                  Time.deltaTime); rb.velocity = new Vector2(Player.transform.position.x, Player.transform.position.y);

    }




}
