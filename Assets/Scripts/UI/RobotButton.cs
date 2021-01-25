using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotButton : MonoBehaviour
{

    public Button on;
    public Button off;
    public GameObject robot;

    public void OnButtonPressed()
    {
        on.gameObject.SetActive(false);
        off.gameObject.SetActive(true);
        robot.gameObject.SetActive(false);
    }

    public void OffButtonPressed()
    {
        off.gameObject.SetActive(false);
        on.gameObject.SetActive(true);
        robot.gameObject.SetActive(true);
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