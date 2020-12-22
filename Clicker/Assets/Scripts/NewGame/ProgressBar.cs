using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public GameObject parentTree;
    ManualHarvest manualHarvest;

    public float minimumProgress;
    public float maximumProgress;
    public float currentProgress;

    public Image mask;
    public Image fill;
    public Color color;

    void Start()
    {
        minimumProgress = 0;
        currentProgress = 0;
        manualHarvest = parentTree.GetComponent<ManualHarvest>();
    }

    void Update()
    {
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
        }
    }

    void GetCurrentFill()
    {
        float currentOffset = currentProgress - minimumProgress;
        float maximumOffset = maximumProgress - minimumProgress;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }
}
