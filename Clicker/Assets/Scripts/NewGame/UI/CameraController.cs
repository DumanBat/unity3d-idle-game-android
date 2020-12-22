using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CameraController : MonoBehaviour
{
    public Canvas uiCanvas;
    public Canvas sceneCanvas;

    private float sceneHeight;
    private float sceneWidth;

    private RectTransform sceneCanvasRT;
    private RectTransform uiCanvasRT;

    float yAxisSceneCoord;
    float currentHeaderHeight;


    private void Awake()
    {
        /* if ((Screen.width / Screen.height) < 0.5)
         {
             uiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
         }

         else
         {
             uiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.75f;
         }*/

        sceneCanvasRT = sceneCanvas.GetComponent<RectTransform>();
        uiCanvasRT = uiCanvas.GetComponent<RectTransform>();
    }

    private void Update()
    {
        //Debug.Log(Screen.width + "width");
        //Debug.Log(Screen.height + " height");

        float screenRatio = (float)Screen.width / (float)Screen.height;
        sceneHeight = uiCanvasRT.rect.height;
        sceneWidth = uiCanvasRT.rect.width;
        //Debug.Log(screenRatio + "screen ratio");

        if (screenRatio <= 0.5625f)
        {
            uiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;

            float orthoSize = 900 * ((float)Screen.height / (float)Screen.width) * 0.5f;
            Camera.main.orthographicSize = orthoSize;

            sceneCanvasRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sceneWidth);
            sceneCanvasRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, sceneHeight);
        }

        else
        {
            uiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;

            float orthoSize = 900 * ((float)Screen.height / (float)Screen.width) * 0.5f;
            Camera.main.orthographicSize = orthoSize;


            sceneCanvasRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sceneWidth);
            sceneCanvasRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, sceneHeight);

            if (screenRatio < 1)
            {
                currentHeaderHeight = (sceneHeight / 1600) * 328.8164f;
                yAxisSceneCoord = (((800 / (float)orthoSize) * currentHeaderHeight) - currentHeaderHeight) /** 2f*/;

                Vector3 yAxisSceneCoordVector = new Vector3(0, -yAxisSceneCoord, 0);
                sceneCanvasRT.SetPositionAndRotation(yAxisSceneCoordVector, Quaternion.identity);
            }
            else
            {
                /*currentHeaderHeight = (sceneHeight / 1600) * 328.8164f;
                yAxisSceneCoord = (((800 / (float)orthoSize) * currentHeaderHeight) - currentHeaderHeight)/* * 0.5f*/;

                Vector3 yAxisSceneCoordVector = new Vector3(0, -yAxisSceneCoord, 0);
                sceneCanvasRT.SetPositionAndRotation(yAxisSceneCoordVector, Quaternion.identity);
            }
            

          
        }

        // 900 reference reso
        
    }


    void Start()
    {
        /*float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = 645 / 331;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = 645 / 2;

        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = (645 / 2) * differenceInSize;
        }*/

        /*float orthoSize = 645 * Screen.height / Screen.width * 0.5f;
        Camera.main.orthographicSize = orthoSize;*/
    }


}
