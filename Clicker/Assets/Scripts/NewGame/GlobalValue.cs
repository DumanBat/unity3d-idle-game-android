using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalValue : MonoBehaviour
{
    //DATA

    public static int globalCash;
    public Text cashDisplay;
    public static int previouseCash;
    public static int temporaryTaskCash;

    public static int globalGold;
    public Text goldDisplay;

    public static int globalApple;
    public Text appleDisplay;

    public static int globalDiamond;
    public Text diamondDisplay;

    public static int expressProfitAmount;


    public static float harvestPerSecTotal;



    // statistic data
    
    public Stars stars;

    public static int totalCashEarned = 0;
    public static int totalUpgradeLvl;
    public static int totalBonusesTaken;

    public static int temporaryCashAmountForStar;

    // trees data

    public GameObject appleTree, orangeTree, strawberry, banana, mango,
                      grape, blueberry, cherry, lemon, peach, melon, watermelon;


    public ManualHarvest appleHarvest, orangeHarvest, strawberryHarvest, bananaHarvest,
                        mangoHarvest, grapeHarvest, blueberryHarvest, cherryHarvest,
                        lemonHarvest, peachHarvest, melonHarvest, watermelonHarvest;


    AutoHarvesting autoApple, autoOrange, autoStrawberry, autoBanana,
                    autoMango, autoGrape, autoBlueberry, autoCherry,
                    autoLemon, autoPeach, autoMelon, autoWatermelon;


    Upgrading appleUpgrades, orangeUpgrades, strawberryUpgrades, bananaUpgrades,
                mangoUpgrades, grapeUpgrades, blueberryUpgrades, cherryUpgrades,
                lemonUpgrades, peachUpgrades, melonUpgrades, watermelonUpgrades;


    public static float applePerSec, orangePerSec, strawberryPerSec, bananaPerSec,
                        mangoPerSec, grapePerSec, blueberryPerSec, cherryPerSec,
                        lemonPerSec, peachPerSec, melonPerSec, watermelonPerSec;


    public static int appleUpgradeLvl, orangeUpgradeLvl, strawberryUpgradeLvl, bananaUpgradeLvl,
                        mangoUpgradeLvl, grapeUpgradeLvl, blueberryUpgradeLvl, cherryUpgradeLvl,
                        lemonUpgradeLvl, peachUpgradeLvl, melonUpgradeLvl, watermelonUpgradeLvl;


    void Start()
    {
        // references 

        {
            autoApple = appleTree.GetComponent<AutoHarvesting>();
            appleUpgrades = appleTree.GetComponent<Upgrading>();
            appleHarvest = appleTree.GetComponent<ManualHarvest>();

            autoOrange = orangeTree.GetComponent<AutoHarvesting>();
            orangeUpgrades = orangeTree.GetComponent<Upgrading>();
            orangeHarvest = orangeTree.GetComponent<ManualHarvest>();

            autoStrawberry = strawberry.GetComponent<AutoHarvesting>();
            strawberryUpgrades = strawberry.GetComponent<Upgrading>();
            strawberryHarvest = strawberry.GetComponent<ManualHarvest>();

            autoBanana = banana.GetComponent<AutoHarvesting>();
            bananaUpgrades = banana.GetComponent<Upgrading>();
            bananaHarvest = banana.GetComponent<ManualHarvest>();

            autoMango = mango.GetComponent<AutoHarvesting>();
            mangoUpgrades = mango.GetComponent<Upgrading>();
            mangoHarvest = mango.GetComponent<ManualHarvest>();

            autoGrape = grape.GetComponent<AutoHarvesting>();
            grapeUpgrades = grape.GetComponent<Upgrading>();
            grapeHarvest = grape.GetComponent<ManualHarvest>();

            autoBlueberry = blueberry.GetComponent<AutoHarvesting>();
            blueberryUpgrades = blueberry.GetComponent<Upgrading>();
            blueberryHarvest = blueberry.GetComponent<ManualHarvest>();

            autoCherry = cherry.GetComponent<AutoHarvesting>();
            cherryUpgrades = cherry.GetComponent<Upgrading>();
            cherryHarvest = cherry.GetComponent<ManualHarvest>();

            autoLemon = lemon.GetComponent<AutoHarvesting>();
            lemonUpgrades = lemon.GetComponent<Upgrading>();
            lemonHarvest = lemon.GetComponent<ManualHarvest>();

            autoPeach = peach.GetComponent<AutoHarvesting>();
            peachUpgrades = peach.GetComponent<Upgrading>();
            peachHarvest = peach.GetComponent<ManualHarvest>();

            autoMelon = melon.GetComponent<AutoHarvesting>();
            melonUpgrades = melon.GetComponent<Upgrading>();
            melonHarvest = melon.GetComponent<ManualHarvest>();

            autoWatermelon = watermelon.GetComponent<AutoHarvesting>();
            watermelonUpgrades = watermelon.GetComponent<Upgrading>();
            watermelonHarvest = watermelon.GetComponent<ManualHarvest>();
        }

    }


    void Update()
    {
        // global values
        cashDisplay.text = globalCash.ToString() + "$";
        goldDisplay.text = globalGold.ToString();
        appleDisplay.text = globalApple.ToString();
        diamondDisplay.text = globalDiamond.ToString();



        appleUpgradeLvl = appleHarvest.tree.upgradeLevel;
        orangeUpgradeLvl = orangeHarvest.tree.upgradeLevel;
        strawberryUpgradeLvl = strawberryHarvest.tree.upgradeLevel;
        bananaUpgradeLvl = bananaHarvest.tree.upgradeLevel;
        mangoUpgradeLvl = mangoHarvest.tree.upgradeLevel;
        grapeUpgradeLvl = grapeHarvest.tree.upgradeLevel;
        blueberryUpgradeLvl = blueberryHarvest.tree.upgradeLevel;
        cherryUpgradeLvl = cherryHarvest.tree.upgradeLevel;
        lemonUpgradeLvl = lemonHarvest.tree.upgradeLevel;
        peachUpgradeLvl = peachHarvest.tree.upgradeLevel;
        melonUpgradeLvl = melonHarvest.tree.upgradeLevel;
        watermelonUpgradeLvl = watermelonHarvest.tree.upgradeLevel;


        // harvest per sec
        {
            if (appleHarvest.tree.managerIsActive)
            {
                applePerSec = autoApple.harvestPerSec;
            }

            if (orangeHarvest.tree.managerIsActive)
            {
                orangePerSec = autoOrange.harvestPerSec;
            }

            if (strawberryHarvest.tree.managerIsActive)
            {
                strawberryPerSec = autoStrawberry.harvestPerSec;
            }

            if (bananaHarvest.tree.managerIsActive)
            {
                bananaPerSec = autoBanana.harvestPerSec;
            }            

            if (mangoHarvest.tree.managerIsActive)
            {
                mangoPerSec = autoMango.harvestPerSec;
            }

            if (grapeHarvest.tree.managerIsActive)
            {
                grapePerSec = autoGrape.harvestPerSec;
            }
            
            if (blueberryHarvest.tree.managerIsActive)
            {
                blueberryPerSec = autoBlueberry.harvestPerSec;
            }

            if (cherryHarvest.tree.managerIsActive)
            {
                cherryPerSec = autoCherry.harvestPerSec;
            }

            if (lemonHarvest.tree.managerIsActive)
            {
                lemonPerSec = autoLemon.harvestPerSec;
            }

            if (peachHarvest.tree.managerIsActive)
            {
                peachPerSec = autoPeach.harvestPerSec;
            }

            if (melonHarvest.tree.managerIsActive)
            {
                peachPerSec = autoMelon.harvestPerSec;
            }

            if (watermelonHarvest.tree.managerIsActive)
            {
                watermelonPerSec = autoWatermelon.harvestPerSec;
            }

        }

        harvestPerSecTotal = applePerSec + orangePerSec + strawberryPerSec + bananaPerSec + mangoPerSec + grapePerSec
                            + blueberryPerSec + cherryPerSec + lemonPerSec + peachPerSec + melonPerSec + watermelonPerSec;

        totalUpgradeLvl = appleUpgradeLvl + orangeUpgradeLvl + strawberryUpgradeLvl + orangeUpgradeLvl + orangeUpgradeLvl
                             + orangeUpgradeLvl + orangeUpgradeLvl + orangeUpgradeLvl + orangeUpgradeLvl + orangeUpgradeLvl
                              + orangeUpgradeLvl + orangeUpgradeLvl;

        //Debug.Log(harvestPerSecTotal + " harvest per sec total");
    }

    public void CashValueChange(int valueChanger, int taskValueIncrease)
    {
        if (previouseCash > globalCash || previouseCash == 0)
        {
            previouseCash = globalCash;
        }
        globalCash += valueChanger;
        temporaryTaskCash += taskValueIncrease;

        if (valueChanger >= 0)
        {
            totalCashEarned += valueChanger;
        }

        if (Stars.currentStarsAchieved < 10)
        {
            if (totalCashEarned >= temporaryCashAmountForStar)
            {
                
                if (LSideUIContoller.isAnyPanelisActive == false)
                {
                    stars.ActivateStar();
                }

            }
        }
        

    }
}
