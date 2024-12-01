using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public int Health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Health -= 1;
        }
    }
    private void Update()
    {
        if (Health <= 0)
        {
            StartCoroutine(PlayParticleSystem());
            Health = 1;
        }
    }


    IEnumerator PlayParticleSystem()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<ParticleSystem>().Play();
        Debug.Log("particle start");
        yield return new WaitForSeconds(3/*GetComponent<ParticleSystem>().duration*/);//mayvbe poroblokm

        Time.timeScale = 1;
        SceneManager.LoadScene("Shop");


    }
}
