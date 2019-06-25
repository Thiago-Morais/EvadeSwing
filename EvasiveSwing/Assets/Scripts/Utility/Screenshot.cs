using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public string path = "/Screenshot";
    [EasyButtons.Button]
    public void TakeScreenshot()
    {
        ScreenCapture.CaptureScreenshot(Application.dataPath+path+"/Screenshot"+System.DateTime.Now.ToString("dd.mm.yyyy_hh.mm.ss")+".png");//+System.DateTime.Now.ToString());
    }
}
