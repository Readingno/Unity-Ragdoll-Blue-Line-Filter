using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public bool isShooting = false;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootTimer()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootBullet()
    {
        isShooting = true;
    }

    public void StopShootBullet()
    {
        isShooting = false;
    }
    IEnumerator ShootTimer()
    {
        while (true)
        {
            if (isShooting)
            {
                GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                newBullet.transform.SetParent(transform);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
