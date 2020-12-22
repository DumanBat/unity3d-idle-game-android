using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AutoHarvesting : MonoBehaviour
{
    public GlobalValue globalValue;

    public UnityEvent buyingManagerEvent;

    public Button buyManagerButton;
    public Text managerCostDisplay;
    ManualHarvest manualHarvest;

    public AudioSource purchaseSound;

    public GameObject managerSprite;

    public int managerCost = 3;
    //public bool managerIsActive = false;

    public float harvestPerSec;

    ColorBlock defaultButtonColorBlock;

    void Start()
    {
        buyManagerButton.onClick.AddListener(BuyingManager);
        manualHarvest = GetComponent<ManualHarvest>();
        buyManagerButton.interactable = false;

        if (manualHarvest.tree.managerIsActive)
        {
            DisableBuyManagerButton();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (manualHarvest.tree.managerIsActive == false)
        {
            if (GlobalValue.globalCash >= managerCost)
            {
                buyManagerButton.interactable = true;
                managerCostDisplay.text = "WORKER" + "\n" + managerCost + "$";
            }
            else
            {
                buyManagerButton.interactable = false;
                managerCostDisplay.text = "WORKER" + "\n" + managerCost + "$";
            }
        }

        if (manualHarvest.tree.managerIsActive)
        {
            buyManagerButton.interactable = false;
            manualHarvest.Harvesting();
            harvestPerSec = manualHarvest.tree.harvestAmount / manualHarvest.tree.harvestDuration;
        }
    }

    public void BuyingManager()
    {
        purchaseSound.Play();
        managerSprite.SetActive(true);

        var buyManagerButtonColor = buyManagerButton.colors;
        defaultButtonColorBlock = buyManagerButton.colors;
        buyManagerButtonColor.disabledColor = new Color32(71, 181, 79, 255);
        buyManagerButton.colors = buyManagerButtonColor;

        globalValue.CashValueChange(-managerCost, 0);
        manualHarvest.tree.managerIsActive = true;
        managerCostDisplay.text = "WORKER" + "\n" + "IS BOUGHT";

        if (TutorialManager.isTutorialIsGoing == true)
        {
            if (buyingManagerEvent != null && TutorialManager.tutorialTextIndex == 6)
            {
                buyingManagerEvent.Invoke();
            }
        }
        
        
    }

    public void SoilResetingManager()
    {
        managerSprite.SetActive(false);
        buyManagerButton.colors = defaultButtonColorBlock;

        manualHarvest.tree.managerIsActive = false;

    }

    public void DisableBuyManagerButton()
    {
        managerSprite.SetActive(true);

        var buyManagerButtonColor = buyManagerButton.colors;
        defaultButtonColorBlock = buyManagerButton.colors;
        buyManagerButtonColor.disabledColor = new Color32(71, 181, 79, 255);
        buyManagerButton.colors = buyManagerButtonColor;

        managerCostDisplay.text = "WORKER" + "\n" + "IS BOUGHT";
    }
}
