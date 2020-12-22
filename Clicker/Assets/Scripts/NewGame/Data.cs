using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    // Global Value

    public int globalCash;
    public int globalGold;
    public int globalApple;
    public int globalDiamond;
    public int expressProfitAmount;
    public int temporaryTaskCash;

    public int totalCashEarned;
    public int totalBonusesTaken;

    public int currentSoilLvl;
    public int soilRenewLvl;
    public int cashGoalToNextRenewLvl;
    public float currentSoilMultiplier;
    public float soilRenewMultiplier;

    public int currentStarsAchieved;
    public int temporaryCashAmountForStar;
    
    
    // trees
    public List<float> harvestAmountList;
    public List<bool> isUnlockedList;
    public List<float> harvestDurationList;
    public List<int> upgradeCostList;
    public List<bool> managerIsActiveList;
    public List<int> upgradeLevelList;
    public List<int> requiredUpgradeLevelForDurationBoostList;
    public List<float> defaultHarvestAmountRenewedList;



    // artifacts
    public List<bool> isArtifactActiveList;

    // tasks
    public List<bool> isTaskActiveList;
    public List<bool> isTaskCompletedList;

    public int taskID1;
    public bool taskIsOpened1;

    public float taskMinimumProgress1;
    public float taskCurrentProgress1;
    public float taskMaximumProgress1;

    public int taskID2;
    public bool taskIsOpened2;

    public float taskMinimumProgress2;
    public float taskCurrentProgress2;
    public float taskMaximumProgress2;

    // daily rewards
    public int date;
    public string timerStatus;
    //public bool timerStatus;

    public int currentDay;

    public List<bool> daysList;

    // fortune wheel data
    public int spinDate;

    // bonus data
    public int cashBonusValue;
    public int goldBonusValue;

    public float minBonusTime;
    public float maxBonusTime;

    // time data
    public DateTime exitFullDate;

    public Data ()
    {

        // Global Value

        globalCash = GlobalValue.globalCash;
        globalApple = GlobalValue.globalApple;
        globalGold = GlobalValue.globalGold;
        globalDiamond = GlobalValue.globalDiamond;
        expressProfitAmount = GlobalValue.expressProfitAmount;
        temporaryTaskCash = GlobalValue.temporaryTaskCash;

        totalCashEarned = GlobalValue.totalCashEarned;
        totalBonusesTaken = GlobalValue.totalBonusesTaken;

        // soil renew data

        currentSoilLvl = SoilRenew.currentSoilLvl;
        soilRenewLvl = SoilRenew.soilRenewLvl;
        cashGoalToNextRenewLvl = SoilRenew.cashGoalToNextRenewLvl;
        currentSoilMultiplier = SoilRenew.currentSoilMultiplier;
        soilRenewMultiplier = SoilRenew.soilRenewMultiplier;

        // stars data

        currentStarsAchieved = Stars.currentStarsAchieved;
        temporaryCashAmountForStar = GlobalValue.temporaryCashAmountForStar;


        // tree data

        harvestAmountList = DataTrees.harvestAmountList;
        isUnlockedList = DataTrees.isUnlockedList;
        harvestDurationList = DataTrees.harvestDurationList;
        upgradeCostList = DataTrees.upgradeCostList;
        managerIsActiveList = DataTrees.managerIsActiveList;
        upgradeLevelList = DataTrees.upgradeLevelList;
        requiredUpgradeLevelForDurationBoostList = DataTrees.requiredUpgradeLevelForDurationBoostList;
        defaultHarvestAmountRenewedList = DataTrees.defaultHarvestAmountRenewedList;

        // artifacts data

        isArtifactActiveList = DataArtifacts.isArtifactActiveList;

        // tasks data
        isTaskActiveList = DataTasks.isTaskActiveList;
        isTaskCompletedList = DataTasks.isTaskCompletedList;

        taskID1 = DataTasks.taskID1;
        taskIsOpened1 = DataTasks.taskIsOpened1;

        taskMinimumProgress1 = DataTasks.taskMinimumProgress1;
        taskCurrentProgress1 = DataTasks.taskCurrentProgress1;
        taskMaximumProgress1 = DataTasks.taskMaximumProgress1;

        taskID2 = DataTasks.taskID2;;
        taskIsOpened2 = DataTasks.taskIsOpened2;

        taskMinimumProgress2 = DataTasks.taskMinimumProgress2;
        taskCurrentProgress2 = DataTasks.taskCurrentProgress2;
        taskMaximumProgress2 = DataTasks.taskMaximumProgress2;


        // daily reward data
        date = DailyReward.date;
        timerStatus = DailyReward.timerStatus;

        currentDay = DailyReward.currentDay;
        daysList = DailyReward.daysList;


        // fortune wheel data
        spinDate = FortuneWheel.spinDate;


        // bonus data

        cashBonusValue = Bonus.cashBonusValue;
        goldBonusValue = Bonus.goldBonusValue;

        minBonusTime = Bonus.minTime;
        maxBonusTime = Bonus.maxTime;

        // time data
        exitFullDate = DataTime.exitFullDate;



    }
}
