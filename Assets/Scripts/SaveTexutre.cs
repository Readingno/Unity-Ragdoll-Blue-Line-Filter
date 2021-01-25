using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveTexutre : MonoBehaviour
{

    public Camera cam;
    public RenderTexture frameImg;
    Texture2D img;
    //public SpriteRenderer sr;
    public RawImage rawImg;
    public int scanWidth;

    public Image TB_line;
    public Image LR_line;

    public GameObject TB_button;
    public GameObject LR_button;
    public GameObject gameUI;
    public GameObject closeButton;

    public enum PhotoType { left_right, top_bottom };
    public PhotoType photoType;

    bool ready = true;
    bool finished = false;

    void Start()
    {
        img = new Texture2D(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            StartCoroutine(GenerateImg());
        }
    }

    public void Generate()
    {
        if (TB_button.activeSelf && !LR_button.activeSelf)
        {
            photoType = PhotoType.top_bottom;
        }
        if (!TB_button.activeSelf && LR_button.activeSelf)
        {
            photoType = PhotoType.left_right;
        }
        if (ready)
        {
            StartCoroutine(GenerateImg());
        }
    }

    IEnumerator GenerateImg()
    {
        ready = false;

        //--Set the img to transparent --


        for (int w = 0; w < Screen.width; w++)
            for (int h = 0; h < Screen.height; h++)
                img.SetPixel(w, h, Color.clear);
        img.Apply();
        rawImg.texture = img;

        //--From top to bottom, generate the img--


        if (photoType == PhotoType.top_bottom)
        {
            TB_line.transform.position = new Vector3(600, 750);
            for (int h = Screen.height; h > 0; h -= scanWidth / 2)
            {
                yield return new WaitForEndOfFrame();
                TB_line.rectTransform.position -= new Vector3(0, scanWidth / 2);
                RenderTexture.active = frameImg;
                Texture2D newImg = new Texture2D(Screen.width, scanWidth / 2);
                newImg.ReadPixels(new Rect(0, Screen.height - h, Screen.width, Screen.height - h + scanWidth/2), 0, 0, false);    //Windows Build
                //newImg.ReadPixels(new Rect(0, h - scanWidth / 2, Screen.width, h), 0, 0, false);    //WebGL Build
                newImg.Apply();
                RenderTexture.active = null;
                var pix = newImg.GetPixels32();
                img.SetPixels32(0, h - scanWidth / 2, Screen.width, scanWidth / 2, pix);
                img.Apply();
                rawImg.texture = img;
            }
            TB_line.rectTransform.position = new Vector3(600, 800);
        }

        //--From left to right, generate the img--


        else if (photoType == PhotoType.left_right)
        {
            LR_line.transform.position = new Vector3(0, 375);
            for (int w = 0; w < Screen.width; w += scanWidth)
            {
                yield return new WaitForEndOfFrame();
                LR_line.rectTransform.position += new Vector3(scanWidth, 0);
                RenderTexture.active = frameImg;
                Texture2D newImg = new Texture2D(scanWidth, Screen.height);
                newImg.ReadPixels(new Rect(w, 0, w + scanWidth, Screen.height), 0, 0, false);
                newImg.Apply();
                RenderTexture.active = null;
                var pix = newImg.GetPixels32();
                img.SetPixels32(w, 0, scanWidth, Screen.height, pix);
                img.Apply();
                rawImg.texture = img;
            }
            LR_line.rectTransform.position = new Vector3(-50, 375);
        }


        //--Inactive game UI --

       gameUI.SetActive(false);
        closeButton.SetActive(true);
    }

    public void CloseImg()
    {

        //--Set the img to transparent --


        for (int w = 0; w < Screen.width; w++)
            for (int h = 0; h < Screen.height; h++)
                img.SetPixel(w, h, Color.clear);
        img.Apply();
        rawImg.texture = img;

        //--Active game UI --

       gameUI.SetActive(true);
        closeButton.SetActive(false);
        ready = true;
    }
}
