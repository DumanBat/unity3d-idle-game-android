using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Button exitButton;
    public StarProgressBar starProgressBar;

    public Text totalEarnedDisplay;
    public Text profitPerSecDisplay;
    public Text profitPerHourDisplay;
    public Text upgradesPurchasedDisplay;
    public Text bonusesTakenDisplay;
    public Text soilRenewedDisplay;
    public Text currentAchievedCash;
    public Text nextStarCash;


    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject star5;
    public GameObject star6;
    public GameObject star7;
    public GameObject star8;
    public GameObject star9;
    public GameObject star10;

    List<GameObject> starsInStats = new List<GameObject>();


    private void Awake()
    {
        starsInStats.Add(star1);
        starsInStats.Add(star2);
        starsInStats.Add(star3);
        starsInStats.Add(star4);
        starsInStats.Add(star5);
        starsInStats.Add(star6);
        starsInStats.Add(star7);
        starsInStats.Add(star8);
        starsInStats.Add(star9);
        starsInStats.Add(star10);
    }

    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(CloseStatsPanel);

      
    }

    // Update is called once per frame
    void Update()
    {
        totalEarnedDisplay.text = GlobalValue.totalCashEarned.ToString();

        if (Stars.currentStarsAchieved == 10)
        {
            currentAchievedCash.text = GlobalValue.temporaryCashAmountForStar.ToString() + "$";
            nextStarCash.text = GlobalValue.temporaryCashAmountForStar.ToString() + "$";
        }
        else
        {
            if (GlobalValue.totalCashEarned <= GlobalValue.temporaryCashAmountForStar)
            {
                currentAchievedCash.text = GlobalValue.totalCashEarned.ToString() + "$";
                nextStarCash.text = GlobalValue.temporaryCashAmountForStar.ToString() + "$";
            }
            else
            {
                currentAchievedCash.text = GlobalValue.temporaryCashAmountForStar.ToString() + "$";
                nextStarCash.text = GlobalValue.temporaryCashAmountForStar.ToString() + "$";
            }
         

            
        }
    }

    public void ShowStats()
    {
        starProgressBar.GetDataForProgressBar();


        totalEarnedDisplay.text = GlobalValue.totalCashEarned.ToString();
        profitPerSecDisplay.text = GlobalValue.harvestPerSecTotal.ToString();
        profitPerHourDisplay.text = (GlobalValue.harvestPerSecTotal * 3600).ToString();
        soilRenewedDisplay.text = SoilRenew.currentSoilLvl.ToString();

        //NEED TO UPDATE IF NEW PANELS WERE ADDED
        //YOBANII KOSTYL NA YOBANNOM KOSTYLE
        upgradesPurchasedDisplay.text = (GlobalValue.totalUpgradeLvl - 12).ToString();

        //need to check if it works properly after reboot
        bonusesTakenDisplay.text = GlobalValue.totalBonusesTaken.ToString();

        for (int i = 0; i < Stars.currentStarsAchieved; i++)
        {
            starsInStats[i].SetActive(true);

        }
        
        if (Stars.currentStarsAchieved == 10)
        {
            currentAchievedCash.text = GlobalValue.temporaryCashAmountForStar.ToString() + "$";
            nextStarCash.text = GlobalValue.temporaryCashAmountForStar.ToString() + "$";
        }
        else
        {
            currentAchievedCash.text = GlobalValue.totalCashEarned.ToString() + "$";
            nextStarCash.text = GlobalValue.temporaryCashAmountForStar.ToString() + "$";
        }
        
    }

    public void CloseStatsPanel()
    {
        LSideUIContoller.isAnyPanelisActive = false;
        this.gameObject.SetActive(false);
    }
}
