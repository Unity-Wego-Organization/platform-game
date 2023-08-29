using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    bool hasHit = false;
    private BoxCollider2D coll;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (!hasHit)
        {
            trackMovement();
        }
    }
    void trackMovement()
    {
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rb.bodyType = RigidbodyType2D.Static;
        coll.isTrigger = true;
        if (collision.gameObject.CompareTag("bullseye"))
        {
            Destroy(gameObject, 10);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
