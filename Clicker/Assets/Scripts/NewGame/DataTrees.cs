using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTrees : MonoBehaviour
{
    TreeDB treeDB;

    public static List<float> harvestAmountList = new List<float>();

    public static List<bool> isUnlockedList = new List<bool>();

    public static List<float> harvestDurationList = new List<float>();

    public static List<int> upgradeCostList = new List<int>();

    public static List<bool> managerIsActiveList = new List<bool>();

    public static List<int> upgradeLevelList = new List<int>();

    public static List<int> requiredUpgradeLevelForDurationBoostList = new List<int>();

    public static List<float> defaultHarvestAmountRenewedList = new List<float>();

    private void Awake()
    {
        treeDB = gameObject.GetComponent<TreeDB>();
    }

    public static void SaveTreesData()
    {
        

        for (int i = 0; i < TreeDB.treeDataBase.Count; i++)
        {
            harvestAmountList.Add(TreeDB.treeDataBase[i].harvestAmount);
            isUnlockedList.Add(TreeDB.treeDataBase[i].isUnlocked);
            harvestDurationList.Add(TreeDB.treeDataBase[i].harvestDuration);
            upgradeCostList.Add(TreeDB.treeDataBase[i].upgradeCost);
            managerIsActiveList.Add(TreeDB.treeDataBase[i].managerIsActive);
            upgradeLevelList.Add(TreeDB.treeDataBase[i].upgradeLevel);
            requiredUpgradeLevelForDurationBoostList.Add(TreeDB.treeDataBase[i].requiredUpgradeLevelForDurationBoost);
            defaultHarvestAmountRenewedList.Add(TreeDB.treeDataBase[i].defaultHarvestAmountRenewed);
            
        }
    } 

}
