using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetClass : MonoBehaviour
{
    public Tree Apple;
    public Tree Orange;
    public Tree Strawberry;
    public Tree Banana;
    public Tree Mango;
    public Tree Grape;
    public Tree Blueberry;
    public Tree Cherry;
    public Tree Lemon;
    public Tree Peach;
    public Tree Melon;
    public Tree Watermelon;



    List<Tree> treesList = new List<Tree>();
    public void ResetAllThisShit()
    {
        GlobalValue.globalCash = 0;
        GlobalValue.globalApple = 0;
        GlobalValue.globalDiamond = 0;
        GlobalValue.globalGold = 0;

        Stars.currentStarsAchieved = 0;




        treesList.Add(Apple);
        treesList.Add(Orange);
        treesList.Add(Strawberry);
        treesList.Add(Banana);
        treesList.Add(Mango);
        treesList.Add(Grape);
        treesList.Add(Blueberry);
        treesList.Add(Cherry);
        treesList.Add(Lemon);
        treesList.Add(Peach);
        treesList.Add(Melon);
        treesList.Add(Watermelon);

        for (int i = 0; i < treesList.Count; i++)
        {
            treesList[i].harvestAmount = treesList[i].defaultHarvestAmount;
            treesList[i].harvestDuration = treesList[i].defaultHarvestDuration;
            treesList[i].upgradeCost = treesList[i].defaultUpgradeCost;
            treesList[i].upgradeLevel = 1;
            treesList[i].requiredUpgradeLevelForDurationBoost = treesList[i].defaultRequiredUpgradeLevelForDurationBoost;
            treesList[i].defaultHarvestAmountRenewed = treesList[i].defaultHarvestAmount;
            treesList[i].managerIsActive = false;

        }
    }
}
