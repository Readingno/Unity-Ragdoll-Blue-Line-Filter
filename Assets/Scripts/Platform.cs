using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    bool ready = true;
    Rigidbody rb;
    public float speedUp;
    public float speedDown;
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivatePlatform()
    {
        if (ready)
        {
            StartCoroutine(RunPlatform());
        }
    }

    IEnumerator RunPlatform()
    {
        /*ready = false;
        rb.velocity = Vector3.up * speedUp;
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector3.down * speedDown;
        yield return new WaitForSeconds(1f);
        rb.velocity = Vector3.zero;
        ready = true;*/
        ready = false;
        while (transform.position.y <= initPos.y + 1.5f)
        {
            rb.velocity = Vector3.up * speedUp;
            yield return 1;
        }
        while (transform.position.y >= initPos.y)
        {
            rb.velocity = Vector3.down * speedDown;
            yield return 1;
        }
        transform.position = initPos;
        rb.velocity = Vector3.zero;
        ready = true;
    }
}
