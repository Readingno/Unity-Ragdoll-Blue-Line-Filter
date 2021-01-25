using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerButton : MonoBehaviour
{

    public Button on;
    public Button off;
    public GameObject hammer;

    public void OnButtonPressed()
    {
        on.gameObject.SetActive(false);
        off.gameObject.SetActive(true);
        hammer.gameObject.SetActive(false);
    }

    public void OffButtonPressed()
    {
        off.gameObject.SetActive(false);
        on.gameObject.SetActive(true);
        hammer.gameObject.SetActive(true);
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