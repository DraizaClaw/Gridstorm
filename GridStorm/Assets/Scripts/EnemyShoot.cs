using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject Grid;
    [SerializeField] public GameObject[] Projectile;

    [SerializeField] private GameObject FirePoint;


    [SerializeField] private float CoolDownTime;
    private float CoolDown;

    private void Update()
    {
        FirePoint.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (GameObject.Find("Player") != null)
        {
            StartCoroutine(Shoot());
        }
        transform.RotateAround(Grid.transform.position, Vector3.forward, 90 * Time.deltaTime);
        if (CoolDown > 0)
        {
            CoolDown -= 1 * Time.deltaTime;
        }
    }
    
    IEnumerator Shoot()
    {
        if (CoolDown <= 0 && GameObject.Find("Player") != null)
        {

            Instantiate(Projectile[Random.Range(0, Projectile.Length)],FirePoint.transform);
            CoolDown = CoolDownTime;
        }
        
        yield return new WaitForSeconds(0.5f);
        
    }








    }
