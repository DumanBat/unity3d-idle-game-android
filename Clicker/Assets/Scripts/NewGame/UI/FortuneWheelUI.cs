using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortuneWheelUI : MonoBehaviour
{
    public Button exitButton;
    public Button tryAgainButton;
    public GameObject fortuneWheelPanel1;

    void Start()
    {
        exitButton.onClick.AddListener(CloseFortuneWheel);
        tryAgainButton.onClick.AddListener(SpinAgain);
    }

    // Update is called once per frame
    void Update()
    {
        if(FortuneWheel.isWheelSpinning == true)
        {
            exitButton.interactable = false;
        }
        else
        {
            exitButton.interactable = true;
        }
    }

    public void CloseFortuneWheel()
    {
        fortuneWheelPanel1.SetActive(false);
        LSideUIContoller.isAnyPanelisActive = false;
    }

    public void SpinAgain()
    {

    }
}
