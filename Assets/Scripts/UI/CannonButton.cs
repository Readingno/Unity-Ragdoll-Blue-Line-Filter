using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonButton : MonoBehaviour
{

    public Button on;
    public Button off;
    public GameObject fire;
    public FireButton fireButton;
    public GameObject cannon;

    public void OnButtonPressed()
    {
        on.gameObject.SetActive(false);
        off.gameObject.SetActive(true);
        fire.gameObject.SetActive(false);
        cannon.gameObject.SetActive(false);
    }

    public void OffButtonPressed()
    {
        off.gameObject.SetActive(false);
        on.gameObject.SetActive(true);
        fire.gameObject.SetActive(true);
        cannon.gameObject.SetActive(true);
        fireButton.OnButtonPressed();
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
