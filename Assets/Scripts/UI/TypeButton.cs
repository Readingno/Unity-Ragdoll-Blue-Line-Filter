using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeButton : MonoBehaviour
{

    public Button tb;
    public Button lr;

    public void TBButtonPressed()
    {
        tb.gameObject.SetActive(false);
        lr.gameObject.SetActive(true);
    }

    public void LRButtonPressed()
    {
        lr.gameObject.SetActive(false);
        tb.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}