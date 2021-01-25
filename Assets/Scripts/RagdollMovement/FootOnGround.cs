using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootOnGround : MonoBehaviour
{
    public bool onGround = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Items"))
        {
            onGround = true;
        }
    }
}