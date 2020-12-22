using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tree", menuName = "ScriptableObjects/Tree", order = 2)]
public class Tree : ScriptableObject
{
    public string treeName;
    public int treeID;

    [Header("Default values")]
    public float defaultHarvestAmount;
    public float defaultHarvestDuration;
    public int defaultUpgradeCost;
    public int defaultRequiredUpgradeLevelForDurationBoost;
    public int defaultManagerCost;
    public int unlockCost;

    [Header("Current values")]
    public float harvestAmount;
    public float harvestDuration;
    public int upgradeCost;
    public int upgradeLevel;
    public bool isUnlocked;
    public bool managerIsActive;

    [Header("Upgrades")]
    public float upgradeMultiplier;
    public int requiredUpgradeLevelForDurationBoost;
    
    [Header("Default values after reset")]
    public float defaultHarvestAmountRenewed;
    public float defaultUpgradeCostRenewed;


}
