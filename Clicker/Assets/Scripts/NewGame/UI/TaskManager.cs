using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public GameObject taskOpenPanel;
    public Button taskOpenButton;
    public bool taskIsOpened = false;
    public bool rewardIsAvailable = false;
    
    TaskDB taskDB;
    TaskProgressBar taskProgressBar;
    public DataTasks dataTasks;


    public int currentTaskID;
    
    public GlobalValue globalValue;

    public Text taskNameDisplay;
    public Text taskDescriptionDisplay;
    public Text taskReward1Display;
    public Text taskReward2Display;

    public Button claimRewardButton;


    //Upgrade Panel type
    public int currentPanelLvl;

    void Start()
    {
        taskOpenButton.onClick.AddListener(OpenTask);

        taskDB = GetComponent<TaskDB>();

        if (DataTasks.taskIsOpened1 == true && DataTasks.taskIsOpened2 == true)
        {
            dataTasks.SetTaskData(); // do Set Task data
            OpenTaskerinio();
            
        }
        else
        {
            OpenTask();
            dataTasks.GetTaskData();
        }
    }

    public void Update()
    {
        if (taskIsOpened == true)
        {

            if (taskProgressBar.currentProgress <= taskProgressBar.maximumProgress)
            {
                switch (TaskDB.DB[currentTaskID].taskType)
                {

                    case Task.TaskTypes.EarnCash:
                        {   
                            taskProgressBar.currentProgress = taskProgressBar.minimumProgress + GlobalValue.temporaryTaskCash;

                            break;
                        }
                    case Task.TaskTypes.UpgradePanel:
                        {
                            ///////// NEED TO UPDATE IF NEW PANELS WERE ADDED!!!!!!!!!!

                            switch (TaskDB.DB[currentTaskID].panelForUpgrade)
                            {
                                case Task.PanelForUpgrade.Apple:
                                    {
                                        taskProgressBar.currentProgress = GlobalValue.appleUpgradeLvl;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Orange:
                                    {
                                        taskProgressBar.currentProgress = GlobalValue.orangeUpgradeLvl;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Strawberry:
                                    {
                                        taskProgressBar.currentProgress = GlobalValue.strawberryUpgradeLvl;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Banana:
                                    {
                                        taskProgressBar.currentProgress = GlobalValue.bananaUpgradeLvl;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Mango:
                                    {
                                        taskProgressBar.currentProgress = GlobalValue.mangoUpgradeLvl;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Grape:
                                    {
                                        taskProgressBar.currentProgress = GlobalValue.grapeUpgradeLvl;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Blueberry:
                                    {
                                        taskProgressBar.currentProgress = GlobalValue.blueberryUpgradeLvl;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Cherry:
                                    {
                                        taskProgressBar.currentProgress = GlobalValue.cherryUpgradeLvl;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Lemon:
                                    {
                                        taskProgressBar.currentProgress = GlobalValue.lemonUpgradeLvl;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Peach:
                                    {
                                        taskProgressBar.currentProgress = GlobalValue.peachUpgradeLvl;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Melon:
                                    {
                                        taskProgressBar.currentProgress = GlobalValue.melonUpgradeLvl;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Watermelon:
                                    {
                                        taskProgressBar.currentProgress = GlobalValue.watermelonUpgradeLvl;
                                        break;
                                    }
                            }

                            break;
                        }
                 }
            }


            if (taskProgressBar.currentProgress >= taskProgressBar.maximumProgress)
            {
                claimRewardButton.interactable = true;
                rewardIsAvailable = true;
            }



        }


    }

    // using this to open started task
    public void OpenTaskerinio()
    {
        taskProgressBar = GetComponentInChildren<TaskProgressBar>();
        taskProgressBar.GetComponentOfTaskManager();

        claimRewardButton.interactable = false;
        claimRewardButton.onClick.AddListener(ClaimReward);




        ShowTaskInfo();
    }

    // using that to open new task (mostly in app first run, at least i hope so)
    public void OpenTask()
    {
        taskProgressBar = GetComponentInChildren<TaskProgressBar>();
        taskProgressBar.GetComponentOfTaskManager();

        //taskOpenPanel.SetActive(false);
        taskIsOpened = true;

        claimRewardButton.interactable = false;
        claimRewardButton.onClick.AddListener(ClaimReward);
        
        //getting first uncompleted task from first task DB and setting it as a current task
        for (int i = 0; i < taskDB.tasksCount; i++)
        {
            if (TaskDB.DB[i].isTaskCompleted == false && TaskDB.DB[i].isTaskActive == false)
            {
                currentTaskID = i;
                TaskDB.DB[currentTaskID].isTaskActive = true;


                //getting the type of active task
                switch (TaskDB.DB[currentTaskID].taskType)
                {
                    case Task.TaskTypes.EarnCash:
                        {
                            taskProgressBar.minimumProgress = (float)GlobalValue.globalCash;
                            taskProgressBar.currentProgress = (float)GlobalValue.globalCash;
                            taskProgressBar.maximumProgress = (float)GlobalValue.globalCash + TaskDB.DB[currentTaskID].taskGoal;

                            GlobalValue.temporaryTaskCash = 0;
                            break;
                        }
                    case Task.TaskTypes.UpgradePanel:
                        {
                            ///////// NEED TO UPDATE IF NEW PANELS WERE ADDED!!!!!!!!!!
                                                          
                            switch (TaskDB.DB[currentTaskID].panelForUpgrade)
                               {
                                case Task.PanelForUpgrade.Apple:
                                    {
                                        taskProgressBar.minimumProgress = GlobalValue.appleUpgradeLvl;
                                        taskProgressBar.currentProgress = GlobalValue.appleUpgradeLvl;
                                        taskProgressBar.maximumProgress = GlobalValue.appleUpgradeLvl + TaskDB.DB[currentTaskID].taskGoal;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Orange:
                                    {
                                        taskProgressBar.minimumProgress = GlobalValue.orangeUpgradeLvl;
                                        taskProgressBar.currentProgress = GlobalValue.orangeUpgradeLvl;
                                        taskProgressBar.maximumProgress = GlobalValue.orangeUpgradeLvl + TaskDB.DB[currentTaskID].taskGoal;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Strawberry:
                                    {
                                        taskProgressBar.minimumProgress = GlobalValue.strawberryUpgradeLvl;
                                        taskProgressBar.currentProgress = GlobalValue.strawberryUpgradeLvl;
                                        taskProgressBar.maximumProgress = GlobalValue.strawberryUpgradeLvl + TaskDB.DB[currentTaskID].taskGoal;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Banana:
                                    {
                                        taskProgressBar.minimumProgress = GlobalValue.bananaUpgradeLvl;
                                        taskProgressBar.currentProgress = GlobalValue.bananaUpgradeLvl;
                                        taskProgressBar.maximumProgress = GlobalValue.bananaUpgradeLvl + TaskDB.DB[currentTaskID].taskGoal;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Mango:
                                    {
                                        taskProgressBar.minimumProgress = GlobalValue.mangoUpgradeLvl;
                                        taskProgressBar.currentProgress = GlobalValue.mangoUpgradeLvl;
                                        taskProgressBar.maximumProgress = GlobalValue.mangoUpgradeLvl + TaskDB.DB[currentTaskID].taskGoal;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Grape:
                                    {
                                        taskProgressBar.minimumProgress = GlobalValue.grapeUpgradeLvl;
                                        taskProgressBar.currentProgress = GlobalValue.grapeUpgradeLvl;
                                        taskProgressBar.maximumProgress = GlobalValue.grapeUpgradeLvl + TaskDB.DB[currentTaskID].taskGoal;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Blueberry:
                                    {
                                        taskProgressBar.minimumProgress = GlobalValue.blueberryUpgradeLvl;
                                        taskProgressBar.currentProgress = GlobalValue.blueberryUpgradeLvl;
                                        taskProgressBar.maximumProgress = GlobalValue.blueberryUpgradeLvl + TaskDB.DB[currentTaskID].taskGoal;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Cherry:
                                    {
                                        taskProgressBar.minimumProgress = GlobalValue.cherryUpgradeLvl;
                                        taskProgressBar.currentProgress = GlobalValue.cherryUpgradeLvl;
                                        taskProgressBar.maximumProgress = GlobalValue.cherryUpgradeLvl + TaskDB.DB[currentTaskID].taskGoal;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Lemon:
                                    {
                                        taskProgressBar.minimumProgress = GlobalValue.lemonUpgradeLvl;
                                        taskProgressBar.currentProgress = GlobalValue.lemonUpgradeLvl;
                                        taskProgressBar.maximumProgress = GlobalValue.lemonUpgradeLvl + TaskDB.DB[currentTaskID].taskGoal;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Peach:
                                    {
                                        taskProgressBar.minimumProgress = GlobalValue.peachUpgradeLvl;
                                        taskProgressBar.currentProgress = GlobalValue.peachUpgradeLvl;
                                        taskProgressBar.maximumProgress = GlobalValue.peachUpgradeLvl + TaskDB.DB[currentTaskID].taskGoal;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Melon:
                                    {
                                        taskProgressBar.minimumProgress = GlobalValue.melonUpgradeLvl;
                                        taskProgressBar.currentProgress = GlobalValue.melonUpgradeLvl;
                                        taskProgressBar.maximumProgress = GlobalValue.melonUpgradeLvl + TaskDB.DB[currentTaskID].taskGoal;
                                        break;
                                    }
                                case Task.PanelForUpgrade.Watermelon:
                                    {
                                        taskProgressBar.minimumProgress = GlobalValue.watermelonUpgradeLvl;
                                        taskProgressBar.currentProgress = GlobalValue.watermelonUpgradeLvl;
                                        taskProgressBar.maximumProgress = GlobalValue.watermelonUpgradeLvl + TaskDB.DB[currentTaskID].taskGoal;
                                        break;
                                    }
                            }

                            break;
                        }
                }
                
                break;
            }
            
        }

        

        ShowTaskInfo();
    }



    public void ShowTaskInfo()
    {
        taskNameDisplay.text = TaskDB.DB[currentTaskID].taskName;
        taskDescriptionDisplay.text = TaskDB.DB[currentTaskID].taskDescription;
        taskReward1Display.text = TaskDB.DB[currentTaskID].goldReward.ToString();
        taskReward2Display.text = TaskDB.DB[currentTaskID].appleReward.ToString();

    }


    public void ClaimReward()
    {
        GlobalValue.globalGold += TaskDB.DB[currentTaskID].goldReward;
        GlobalValue.globalApple += TaskDB.DB[currentTaskID].appleReward;

        TaskDB.DB[currentTaskID].isTaskActive = false;
        TaskDB.DB[currentTaskID].isTaskCompleted = true;
        

        //taskOpenPanel.SetActive(true);
        
        rewardIsAvailable = false;

        OpenTask();
        dataTasks.GetTaskData();

    }
}


