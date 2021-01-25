using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject dirPoint;
    Rigidbody rb;
    public float force;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 dir = transform.position - dirPoint.transform.position;
        rb.AddForce(dir * force, ForceMode.Impulse);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10f)
        {
            Destroy(gameObject);
        }
    }
}
