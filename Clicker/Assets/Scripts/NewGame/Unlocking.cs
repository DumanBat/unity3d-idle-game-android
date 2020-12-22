using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Unlocking : MonoBehaviour
{
    public int unlockCost = 50;
    public GameObject blankPanel;
    public Button unlockButton;
    public AudioSource purchaseSound;
    public GlobalValue globalValue;

    public Text unlockCostDisplay;

    private bool isUnlocked = false;

    public UnityEvent unlockingTreeEvent;


    void Start()
    {
        if (isUnlocked == false)
        {
            blankPanel.SetActive(true);
            unlockButton.onClick.AddListener(UnlockTree);
            unlockCostDisplay.text = unlockCost + "$";
        }
        if (isUnlocked)
        {
            blankPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalValue.globalCash >= unlockCost)
        {
            unlockButton.interactable = true;
        }
        else
        {
            unlockButton.interactable = false;
        }

    }

    public void UnlockTree()
    {
        purchaseSound.Play();
        globalValue.CashValueChange(-unlockCost, 0);
        blankPanel.SetActive(false);
        isUnlocked = true;

        if (TutorialManager.isTutorialIsGoing == true)
        {
            if (unlockingTreeEvent != null && TutorialManager.tutorialTextIndex == 8)
            {
                unlockingTreeEvent.Invoke();
            }
        }

    }
}
