using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionButton : MonoBehaviour
{

    public Button on;
    public Button off;

    public void OnButtonPressed()
    {
        on.gameObject.SetActive(false);
        off.gameObject.SetActive(true);
    }

    public void OffButtonPressed()
    {
        off.gameObject.SetActive(false);
        on.gameObject.SetActive(true);
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
