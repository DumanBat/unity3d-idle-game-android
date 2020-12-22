using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Upgrading : MonoBehaviour
{
    public GlobalValue globalValue;
    public UnityEvent upgradeEvent;
    
    ManualHarvest manualHarvest;

    public Button upgradeButton;
    public Text upgradeCostDisplay;
    public Text upgradeLevelDisplay;

    public AudioSource purchaseSound;

    void Start()
    {
        upgradeButton.onClick.AddListener(Upgrade);
        manualHarvest = GetComponent<ManualHarvest>();
    }

    void Update()
    {
        upgradeCostDisplay.text = "UPGRADE" + "\n" + manualHarvest.tree.upgradeCost + "$";
        upgradeLevelDisplay.text = "Lvl. " + manualHarvest.tree.upgradeLevel;

        if (GlobalValue.globalCash >= manualHarvest.tree.upgradeCost)
         {
            upgradeButton.interactable = true;
         }
         else
         {
            upgradeButton.interactable = false;
         }
    }

    public void Upgrade()
    {
        purchaseSound.Play();
        globalValue.CashValueChange(-manualHarvest.tree.upgradeCost, 0);
        manualHarvest.tree.harvestAmount *= manualHarvest.tree.upgradeMultiplier;
        manualHarvest.tree.upgradeCost *= 2;
        manualHarvest.tree.upgradeLevel += 1;

        if (manualHarvest.tree.upgradeLevel == manualHarvest.tree.requiredUpgradeLevelForDurationBoost)
        {
            //animation
            manualHarvest.appleGrowAnimation.speed *= 2;
            manualHarvest.tree.harvestDuration /= 2;
            manualHarvest.tree.requiredUpgradeLevelForDurationBoost *= 2;
        }

        if (TutorialManager.isTutorialIsGoing == true)
        {
            if (upgradeEvent != null && TutorialManager.tutorialTextIndex == 4)
            {
                upgradeEvent.Invoke();
            }
        }
        
    }

    public void SoilResetingUpgrades()
    {
        manualHarvest.tree.upgradeCost = manualHarvest.tree.defaultUpgradeCost;
        manualHarvest.tree.upgradeLevel = 1;

        manualHarvest.tree.requiredUpgradeLevelForDurationBoost = manualHarvest.tree.defaultRequiredUpgradeLevelForDurationBoost;

        manualHarvest.appleGrowAnimation.speed = 1;
        manualHarvest.tree.harvestDuration = manualHarvest.tree.defaultHarvestDuration;
    }
}
