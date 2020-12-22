using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//[ExecuteInEditMode()]
public class StarProgressBar : MonoBehaviour
{

    public float minimumProgress;
    public float maximumProgress;
    public float currentProgress;

    public Image mask;
    public Image fill;
    public Color color;

    void Start()
    {
    
    }

    void Update()
    {
        
        currentProgress = GlobalValue.totalCashEarned;
        GetCurrentFill();
        
        /*
        maximumProgress = manualHarvest.tree.harvestDuration;

        if (manualHarvest.isHarvesting == true) 
        {
            currentProgress = maximumProgress - manualHarvest.remainingTime;
            GetCurrentFill();
        }

        else
        {
            currentProgress = 0;
            GetCurrentFill();
        }*/
    }

    void GetCurrentFill()
    {
        
        float currentOffset = currentProgress - minimumProgress;
        float maximumOffset = maximumProgress - minimumProgress;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }

    public void GetDataForProgressBar()
    {
        if (Stars.currentStarsAchieved != 0 && Stars.currentStarsAchieved != 10)
        {
            minimumProgress = Stars.starList[Stars.currentStarsAchieved - 1];
            maximumProgress = Stars.starList[Stars.currentStarsAchieved];
        }
        if (Stars.currentStarsAchieved == 0)
        {
            minimumProgress = 0;
            maximumProgress = Stars.starList[0];
        }
        if (Stars.currentStarsAchieved == 10)
        {
            maximumProgress = Stars.starList[9];
            currentProgress = maximumProgress;
        }
    }
}
