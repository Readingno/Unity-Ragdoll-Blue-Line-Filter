using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraButton : MonoBehaviour
{

    public Button on;
    public Button off;
    public GameObject type;
    public Button shoot;

    public void OnButtonPressed()
    {
        on.gameObject.SetActive(false);
        off.gameObject.SetActive(true);
        type.gameObject.SetActive(false);
        shoot.gameObject.SetActive(false);
    }

    public void OffButtonPressed()
    {
        off.gameObject.SetActive(false);
        on.gameObject.SetActive(true);
        type.gameObject.SetActive(true);
        shoot.gameObject.SetActive(true);
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
