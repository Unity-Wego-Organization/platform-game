using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootArrow : MonoBehaviour
{
    public float LaunchForce;
    public GameObject arrow;
    public bow bow;

    private void Start()
    {
        bow = FindObjectOfType<bow>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && bow.ActiveBow)
        {
            shoot();
        }
    }
    void shoot()
    {
        GameObject ArrowIns = Instantiate(arrow, transform.position, transform.rotation);
        ArrowIns.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
    }
}
