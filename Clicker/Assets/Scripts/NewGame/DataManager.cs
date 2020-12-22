using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public DataTime dataTime;

    TutorialManager tutorialManager;

    public InternetCheck internetCheck;



    private void Awake()
    {
        tutorialManager = GetComponent<TutorialManager>();

        

        
    }
    void Start()
    {

        Load();

        if (TutorialManager.appFirstRun == false)
        {
            Debug.LogError("app govno");
            StartCoroutine(AutoSaveCoroutine());
        }
        else
        {
            Debug.Log("App first run. Starting Tutorial");
            tutorialManager.StartTutorial();

        }

    }

    IEnumerator AutoSaveCoroutine()
    {

        while(true)
        {
            yield return new WaitForSeconds(30f);
            yield return internetCheck.StartCoroutine("CheckForInternetConnectionCoroutine");
            if (InternetCheck.isInternetAccesable == true)
            {
                yield return StartCoroutine(dataTime.SaveCurrentTimeCoroutine());
                DataTrees.SaveTreesData();
                DataArtifacts.SaveArtifactsData();
                DataTasks.SaveTasksData();
                DataSave.SaveData();
            }
            else
            {
                DataTrees.SaveTreesData();
                DataArtifacts.SaveArtifactsData();
                DataTasks.SaveTasksData();
                DataSave.SaveData();
            }
            
            yield return new WaitForSeconds(30f);
        }
       
    }

    public void Save()
    {
        /*StartCoroutine(dataTime.SaveCurrentTimeCoroutine());
      
        DataTrees.SaveTreesData();
        DataArtifacts.SaveArtifactsData();
        DataTasks.SaveTasksData();
        DataSave.SaveData();*/

        StartCoroutine(SaveShitCoroutine());
        
    }

    public IEnumerator SaveShitCoroutine()
    {
        yield return StartCoroutine(dataTime.SaveCurrentTimeCoroutine());

        DataTrees.SaveTreesData();
        DataArtifacts.SaveArtifactsData();
        DataTasks.SaveTasksData();
        DataSave.SaveData();
    }

    public void Load()
    {
        Data data = DataSave.LoadData();

        if (data != null)
        {

            TutorialManager.appFirstRun = false;
            // Global Value
            GlobalValue.globalCash = data.globalCash;
            GlobalValue.globalApple = data.globalApple;
            GlobalValue.globalGold = data.globalGold;
            GlobalValue.globalDiamond = data.globalDiamond;
            GlobalValue.expressProfitAmount = data.expressProfitAmount;
            GlobalValue.temporaryTaskCash = data.temporaryTaskCash;

            GlobalValue.totalCashEarned = data.totalCashEarned;
            GlobalValue.totalBonusesTaken = data.totalBonusesTaken;


            // Soil Renew
            SoilRenew.currentSoilLvl = data.currentSoilLvl;
            SoilRenew.soilRenewLvl = data.soilRenewLvl;
            SoilRenew.cashGoalToNextRenewLvl = data.cashGoalToNextRenewLvl;
            SoilRenew.currentSoilMultiplier = data.currentSoilMultiplier;
            SoilRenew.soilRenewMultiplier = data.soilRenewMultiplier;


            // Stars
            Stars.currentStarsAchieved = data.currentStarsAchieved;
            GlobalValue.temporaryCashAmountForStar = data.temporaryCashAmountForStar;


            // Trees Data

            for (int i = 0; i < TreeDB.treeDataBase.Count; i++)
            {
                TreeDB.treeDataBase[i].harvestAmount = data.harvestAmountList[i];
                TreeDB.treeDataBase[i].isUnlocked = data.isUnlockedList[i];
                TreeDB.treeDataBase[i].harvestDuration = data.harvestDurationList[i];
                TreeDB.treeDataBase[i].upgradeCost = data.upgradeCostList[i];
                TreeDB.treeDataBase[i].managerIsActive = data.managerIsActiveList[i];
                TreeDB.treeDataBase[i].upgradeLevel = data.upgradeLevelList[i];
                TreeDB.treeDataBase[i].requiredUpgradeLevelForDurationBoost = data.requiredUpgradeLevelForDurationBoostList[i];
                TreeDB.treeDataBase[i].defaultHarvestAmountRenewed = data.defaultHarvestAmountRenewedList[i];
            }

            // artifacts Data

            for (int i = 0; i < ArtifactDB.DB.Count; i++)
            {
                ArtifactDB.DB[i].isArtifactActive = data.isArtifactActiveList[i];
            }

            // tasks Data

            for (int i = 0; i < TaskDB.DB.Count; i++)
            {
                TaskDB.DB[i].isTaskActive = data.isTaskActiveList[i];
                TaskDB.DB[i].isTaskCompleted = data.isTaskCompletedList[i];
            }

            DataTasks.taskID1 = data.taskID1;
            DataTasks.taskIsOpened1 = data.taskIsOpened1;

            DataTasks.taskMinimumProgress1 = data.taskMinimumProgress1;
            DataTasks.taskCurrentProgress1 = data.taskCurrentProgress1;
            DataTasks.taskMaximumProgress1 = data.taskMaximumProgress1;


            DataTasks.taskID2 = data.taskID2;
            DataTasks.taskIsOpened2 = data.taskIsOpened2;

            DataTasks.taskMinimumProgress2 = data.taskMinimumProgress2;
            DataTasks.taskCurrentProgress2 = data.taskCurrentProgress2;
            DataTasks.taskMaximumProgress2 = data.taskMaximumProgress2;


            // daily reward data

            DailyReward.date = data.date;
            DailyReward.timerStatus = data.timerStatus;

            DailyReward.currentDay = data.currentDay;

            for (int i = 0; i < 7; i++)
            {
                DailyReward.daysList[i] = data.daysList[i];
            }


            // fortune wheel data

            FortuneWheel.spinDate = data.spinDate;


            // bonus data

            Bonus.cashBonusValue = data.cashBonusValue;
            Bonus.goldBonusValue = data.goldBonusValue;

            Bonus.minTime = data.minBonusTime;
            Bonus.maxTime = data.maxBonusTime;

            // time data

            DataTime.exitFullDate = data.exitFullDate;
        }



        else
        {
            TutorialManager.appFirstRun = true;
        }


        
    }    
}
