using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Events;

public class InternetCheck : MonoBehaviour
{

    private string url = "https://idlefarm2000.000webhostapp.com";

    public static bool isInternetAccesable;

    public GameObject checkConnectionPanel;
    public GameObject okButton;

    public UnityEvent internetAccesableEvent;

    private void Awake()
    {
        CheckForInternetConnection();
        //CheckForInternetConnectionCoroutine();
        checkConnectionPanel.SetActive(false);
    }


    IEnumerator CheckForInternetConnectionCoroutine()
    {
        Debug.Log("checking internet connection");
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.isHttpError)
        {
            Debug.Log("Error HTTP");
            isInternetAccesable = false;
            CheckYourInternetConnectionPanel();
            if (internetAccesableEvent != null)
            {
                internetAccesableEvent.Invoke();
            }
        }
        if (request.isNetworkError)
        {
            Debug.Log("Error Network");
            isInternetAccesable = false;
            CheckYourInternetConnectionPanel();
            if (internetAccesableEvent != null)
            {
                internetAccesableEvent.Invoke();
            }
        }
        else
        {
            isInternetAccesable = true;
            Debug.Log("internet accesable");
            if (internetAccesableEvent != null)
            {
                internetAccesableEvent.Invoke();
            }
        }

    }

    public void CheckForInternetConnection()
    {
        StartCoroutine("CheckForInternetConnectionCoroutine");

    }

    public void CheckYourInternetConnectionPanel()
    {
        checkConnectionPanel.SetActive(true);
        okButton.GetComponent<Button>().onClick.AddListener(CloseCheckConnectionPanel);
    }

    public void CloseCheckConnectionPanel()
    {
        checkConnectionPanel.SetActive(false);
        okButton.GetComponent<Button>().onClick.RemoveListener(CloseCheckConnectionPanel);
    }
}
