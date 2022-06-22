using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.AddForce(Vector3.down * 0.5f * rigidbody2D.mass);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LoseCollider")
        {
            Destroy(this.gameObject);
        } else if (collision.gameObject.name.StartsWith("Paddle"))
        {
            Destroy(this.gameObject);
        }
    }
}
