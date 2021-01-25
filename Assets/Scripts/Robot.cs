using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    Vector3 p1, p2, p3;
    public Transform pos1;
    public Transform pos2;
    bool t1, t2, t3;
    // Start is called before the first frame update
    void Start()
    {
        p1 = transform.position;
        p2 = pos1.position;
        p3 = pos2.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - p1).magnitude < 0.02)
        {
            t1 = true; t2 = false; t3 = false;
        }
        if ((transform.position - p2).magnitude < 0.02)
        {
            t1 = false; t2 = true; t3 = false;
        }
        if ((transform.position - p3).magnitude < 0.02)
        {
            t1 = false; t2 = false; t3 = true;
        }

        if (t1)
        {
            transform.position = Vector3.MoveTowards(transform.position, p2, 1.5f * Time.deltaTime);
        }
        if (t2)
        {
            transform.position = Vector3.MoveTowards(transform.position, p3, 1.5f * Time.deltaTime);
        }
        if (t3)
        {
            transform.position = Vector3.MoveTowards(transform.position, p1, 1.5f * Time.deltaTime);
        }
    }
}
