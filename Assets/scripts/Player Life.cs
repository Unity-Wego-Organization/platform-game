using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Vector3 respawnpoint;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource death;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        respawnpoint = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("traps"))
        {
            Die();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("traps"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("checkpoints"))
        {
            respawnpoint = transform.position;
        }
    }
    private void Die()
    {
        death.Play();
        //rb.bodyType= RigidbodyType2D.Static;
        //anim.SetTrigger("death");
        RestartLevel();
    }

    private void RestartLevel()
    {
        transform.position = respawnpoint;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
