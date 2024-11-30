using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Controls player movement 

    [SerializeField] private float Speed;
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;//may not be nessariy


    [Header("Dash")]
    public bool CanDash = true;
    private bool isDashing;
    [SerializeField] private float DashPower;
    [SerializeField] private float DashTime;
    [SerializeField] private float DashCooldown;
    private TrailRenderer tr;//header dosen't work for some reason //nvm

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        tr = GetComponent<TrailRenderer>();

    }

    private void Update()
    {

        if (isDashing)
        {
            return;
        }
        float horizontalInput;
        float verticalInput;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontalInput * Speed, verticalInput * Speed);


        if (/*Input.GetKeyDown(KeyCode.Mouse0) && CanDash || */Input.GetKeyDown(KeyCode.Q) && CanDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        CanDash = false;
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x * DashPower, rb.velocity.y * DashPower);
        tr.emitting = true;
        yield return new WaitForSeconds(DashTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(DashCooldown);
        CanDash = true;

    }

}
