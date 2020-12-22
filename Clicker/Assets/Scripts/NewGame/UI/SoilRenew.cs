using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoilRenew : MonoBehaviour
{
    //soil Renew Panel
    Button soilRenewPanelOpenButton;
    public GameObject soilRenewPanel;
    public Button upgradeWithResetButton;
    public Button upgradeWithoutResetButton;
    
    public Button soilRenewPanelCloseButton;
    
    //data
    public static int currentSoilLvl;
    public static int soilRenewLvl;
    public static float soilRenewMultiplier = 1;
    public static float currentSoilMultiplier;

    
    //confirm panel
    public GameObject confirmBoostPanel;
    public Button closeConfirmPanelButton;
    public Button upgradeBoostWithAdButton;
    public Button upgradeBoostWithGoldButton;


    //references                                                // NEED TO UPDATE
    public GameObject appleTree, orangeTree, strawberry, banana, mango,
                       grape, blueberry, cherry, lemon, peach, melon, watermelon;


    ManualHarvest appleHarvest, orangeHarvest, strawberryHarvest, bananaHarvest,
                        mangoHarvest, grapeHarvest, blueberryHarvest, cherryHarvest,
                        lemonHarvest, peachHarvest, melonHarvest, watermelonHarvest;


    AutoHarvesting appleAuto, orangeAuto, strawberryAuto, bananaAuto,
                    mangoAuto, grapeAuto, blueberryAuto, cherryAuto,
                    lemonAuto, peachAuto, melonAuto, watermelonAuto;


    Upgrading appleUpgrade, orangeUpgrade, strawberryUpgrade, bananaUpgrade,
                mangoUpgrade, grapeUpgrade, blueberryUpgrade, cherryUpgrade,
                lemonUpgrade, peachUpgrade, melonUpgrade, watermelonUpgrade;


    //need to balance
    public static int cashGoalToNextRenewLvl = 1000;



    void Start()
    {
        // soil renew panel
        soilRenewPanel.SetActive(false);

        soilRenewPanelOpenButton = this.gameObject.GetComponent<Button>();
        
        soilRenewPanelOpenButton.interactable = false;

        soilRenewPanelOpenButton.onClick.AddListener(OpenSoilRenewPanel);
        soilRenewPanelCloseButton.onClick.AddListener(CloseSoilRenewPanel);

        // confirm panel
        confirmBoostPanel.SetActive(false);

        upgradeBoostWithAdButton.onClick.AddListener(UpgradeBoostWithAd);
        upgradeBoostWithGoldButton.onClick.AddListener(UpgradeBoostWithGold);

        closeConfirmPanelButton.onClick.AddListener(CloseConfirmBoostPanel);

        
        // upgrade buttons
        upgradeWithResetButton.onClick.AddListener(UpgradeAndReset);
        upgradeWithoutResetButton.onClick.AddListener(UpgradeWithoutReset);


        // references        NEED TO UPDATE
        {
            appleAuto = appleTree.GetComponent<AutoHarvesting>();
            appleUpgrade = appleTree.GetComponent<Upgrading>();
            appleHarvest = appleTree.GetComponent<ManualHarvest>();

            orangeAuto = orangeTree.GetComponent<AutoHarvesting>();
            orangeUpgrade = orangeTree.GetComponent<Upgrading>();
            orangeHarvest = orangeTree.GetComponent<ManualHarvest>();

            strawberryAuto = strawberry.GetComponent<AutoHarvesting>();
            strawberryUpgrade = strawberry.GetComponent<Upgrading>();
            strawberryHarvest = strawberry.GetComponent<ManualHarvest>();

            bananaAuto = banana.GetComponent<AutoHarvesting>();
            bananaUpgrade = banana.GetComponent<Upgrading>();
            bananaHarvest = banana.GetComponent<ManualHarvest>();

            mangoAuto = mango.GetComponent<AutoHarvesting>();
            mangoUpgrade = mango.GetComponent<Upgrading>();
            mangoHarvest = mango.GetComponent<ManualHarvest>();

            grapeAuto = grape.GetComponent<AutoHarvesting>();
            grapeUpgrade = grape.GetComponent<Upgrading>();
            grapeHarvest = grape.GetComponent<ManualHarvest>();

            blueberryAuto = blueberry.GetComponent<AutoHarvesting>();
            blueberryUpgrade = blueberry.GetComponent<Upgrading>();
            blueberryHarvest = blueberry.GetComponent<ManualHarvest>();

            cherryAuto = cherry.GetComponent<AutoHarvesting>();
            cherryUpgrade = cherry.GetComponent<Upgrading>();
            cherryHarvest = cherry.GetComponent<ManualHarvest>();

            lemonAuto = lemon.GetComponent<AutoHarvesting>();
            lemonUpgrade = lemon.GetComponent<Upgrading>();
            lemonHarvest = lemon.GetComponent<ManualHarvest>();

            peachAuto = peach.GetComponent<AutoHarvesting>();
            peachUpgrade = peach.GetComponent<Upgrading>();
            peachHarvest = peach.GetComponent<ManualHarvest>();

            melonAuto = melon.GetComponent<AutoHarvesting>();
            melonUpgrade = melon.GetComponent<Upgrading>();
            melonHarvest = melon.GetComponent<ManualHarvest>();

            watermelonAuto = watermelon.GetComponent<AutoHarvesting>();
            watermelonUpgrade = watermelon.GetComponent<Upgrading>();
            watermelonHarvest = watermelon.GetComponent<ManualHarvest>();
        }
    }

    void Update()
    {
        if (GlobalValue.totalCashEarned >= cashGoalToNextRenewLvl)
        {
            soilRenewLvl += 1;
            cashGoalToNextRenewLvl *= 3;
            soilRenewMultiplier *= 1.05f;
        }

        {

        
            if (soilRenewLvl != 0 && currentSoilLvl < soilRenewLvl)
            {
                soilRenewPanelOpenButton.interactable = true;
                
            }

            else
            {
                soilRenewPanelOpenButton.interactable = false;
            }
        }
    }
    
    public void OpenSoilRenewPanel()
    {
        soilRenewPanel.SetActive(true);
        LSideUIContoller.isAnyPanelisActive = true;
    }

    public void CloseSoilRenewPanel()
    {
        LSideUIContoller.isAnyPanelisActive = false;
        soilRenewPanel.SetActive(false);
    }

    public void OpenConfirmBoostPanel()
    {
        confirmBoostPanel.SetActive(true);
    }

    public void CloseConfirmBoostPanel()
    {
        confirmBoostPanel.SetActive(false);
    }

    public void UpgradeAndReset()
    {
        Debug.Log(soilRenewMultiplier + "multiplier");
        Debug.Log(soilRenewLvl + "soilRenewLvl");

        GlobalValue.globalCash = 0;

        // NEED TO UPDATE IF NEW PANELS WERE ADDED                          IMPORTANT!!!!! YOBANII KOSTYL!!!
        {
            appleHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
            orangeHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
            strawberryHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
            bananaHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
            mangoHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
            grapeHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
            blueberryHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
            cherryHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
            lemonHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
            peachHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
            melonHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
            watermelonHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;



            appleHarvest.tree.harvestAmount = appleHarvest.tree.defaultHarvestAmountRenewed;
            orangeHarvest.tree.harvestAmount = orangeHarvest.tree.defaultHarvestAmountRenewed;
            strawberryHarvest.tree.harvestAmount = strawberryHarvest.tree.defaultHarvestAmountRenewed;
            bananaHarvest.tree.harvestAmount = bananaHarvest.tree.defaultHarvestAmountRenewed;
            mangoHarvest.tree.harvestAmount = mangoHarvest.tree.defaultHarvestAmountRenewed;
            grapeHarvest.tree.harvestAmount = grapeHarvest.tree.defaultHarvestAmountRenewed;
            blueberryHarvest.tree.harvestAmount = blueberryHarvest.tree.defaultHarvestAmountRenewed;
            cherryHarvest.tree.harvestAmount = cherryHarvest.tree.defaultHarvestAmountRenewed;
            lemonHarvest.tree.harvestAmount = lemonHarvest.tree.defaultHarvestAmountRenewed;
            peachHarvest.tree.harvestAmount = peachHarvest.tree.defaultHarvestAmountRenewed;
            melonHarvest.tree.harvestAmount = melonHarvest.tree.defaultHarvestAmountRenewed;
            watermelonHarvest.tree.harvestAmount = watermelonHarvest.tree.defaultHarvestAmountRenewed;

            appleUpgrade.SoilResetingUpgrades();
            orangeUpgrade.SoilResetingUpgrades();
            strawberryUpgrade.SoilResetingUpgrades();
            bananaUpgrade.SoilResetingUpgrades();
            mangoUpgrade.SoilResetingUpgrades();
            grapeUpgrade.SoilResetingUpgrades();
            blueberryUpgrade.SoilResetingUpgrades();
            cherryUpgrade.SoilResetingUpgrades();
            lemonUpgrade.SoilResetingUpgrades();
            peachUpgrade.SoilResetingUpgrades();
            melonUpgrade.SoilResetingUpgrades();
            watermelonUpgrade.SoilResetingUpgrades();

            appleAuto.SoilResetingManager();
            orangeAuto.SoilResetingManager();
            strawberryAuto.SoilResetingManager();
            bananaAuto.SoilResetingManager();
            mangoAuto.SoilResetingManager();
            grapeAuto.SoilResetingManager();
            blueberryAuto.SoilResetingManager();
            cherryAuto.SoilResetingManager();
            lemonAuto.SoilResetingManager();
            peachAuto.SoilResetingManager();
            melonAuto.SoilResetingManager();
            watermelonAuto.SoilResetingManager();
        }

        // check out this later

        currentSoilMultiplier = soilRenewMultiplier;


        currentSoilLvl = soilRenewLvl;
        soilRenewMultiplier = 1;
        OpenConfirmBoostPanel();
    }

    public void UpgradeWithoutReset()
    {
        Debug.Log(soilRenewMultiplier + "multiplier");
        Debug.Log(soilRenewLvl + "soilRenewLvl");


        // NEED TO UPDATE IF NEW PANELS WERE ADDED
        appleHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
        orangeHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
        strawberryHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
        bananaHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
        mangoHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
        grapeHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
        blueberryHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
        cherryHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
        lemonHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
        peachHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
        melonHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;
        watermelonHarvest.tree.defaultHarvestAmountRenewed *= soilRenewMultiplier;


        appleHarvest.tree.harvestAmount *= soilRenewMultiplier;
        orangeHarvest.tree.harvestAmount *= soilRenewMultiplier;
        strawberryHarvest.tree.harvestAmount *= soilRenewMultiplier;
        bananaHarvest.tree.harvestAmount *= soilRenewMultiplier;
        mangoHarvest.tree.harvestAmount *= soilRenewMultiplier;
        grapeHarvest.tree.harvestAmount *= soilRenewMultiplier;
        blueberryHarvest.tree.harvestAmount *= soilRenewMultiplier;
        cherryHarvest.tree.harvestAmount *= soilRenewMultiplier;
        lemonHarvest.tree.harvestAmount *= soilRenewMultiplier;
        peachHarvest.tree.harvestAmount *= soilRenewMultiplier;
        melonHarvest.tree.harvestAmount *= soilRenewMultiplier;
        watermelonHarvest.tree.harvestAmount *= soilRenewMultiplier;


        currentSoilLvl = soilRenewLvl;
        soilRenewMultiplier = 1;
        OpenConfirmBoostPanel();
    }

    public void UpgradeBoostWithAd()
    {
        // insert Ad function here

        CloseConfirmBoostPanel();
        CloseSoilRenewPanel();
    }

    public void UpgradeBoostWithGold()
    { 
        appleHarvest.tree.harvestAmount *= 1.5f;
        orangeHarvest.tree.harvestAmount *= 1.5f;
        strawberryHarvest.tree.harvestAmount *= 1.5f;
        bananaHarvest.tree.harvestAmount *= 1.5f;
        mangoHarvest.tree.harvestAmount *= 1.5f;
        grapeHarvest.tree.harvestAmount *= 1.5f;
        blueberryHarvest.tree.harvestAmount *= 1.5f;
        cherryHarvest.tree.harvestAmount *= 1.5f;
        lemonHarvest.tree.harvestAmount *= 1.5f;
        peachHarvest.tree.harvestAmount *= 1.5f;
        melonHarvest.tree.harvestAmount *= 1.5f;
        watermelonHarvest.tree.harvestAmount *= 1.5f;

        GlobalValue.globalGold -= 10;

        CloseConfirmBoostPanel();
        CloseSoilRenewPanel();
    }
}
