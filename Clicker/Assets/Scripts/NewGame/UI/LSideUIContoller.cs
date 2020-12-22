using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LSideUIContoller : MonoBehaviour
{
    public static bool isAnyPanelisActive = false;
    

    // fortune wheel panel
    public Button fortuneWheelButton;
    public GameObject fortuneWheelPanel;
    public GameObject fortuneWheelExclamationMark;


    // tasks panel
    public Button tasksButton;
    public GameObject tasksPanel;
    public GameObject tasksExclamationMark;

    public GameObject taskPanel1;
    TaskManager taskManager;
    public GameObject taskPanel2;
    TaskManager taskManager2;

    // artifacts panel
    public Button artifactsButton;
    public GameObject artifactsPanel;
    public GameObject artifactsExclamationMark;

    // daily reward panel
    public Button dailyRewardButton;
    public GameObject dailyRewardPanel;
    public GameObject dailyRewardExclamationMark;

    // shop panel
    public Button shopButton;
    public GameObject shopPanel;


    void Start()
    {
        fortuneWheelButton.onClick.AddListener(OpenFortuneWheelPanel);
        fortuneWheelPanel.SetActive(false);

        tasksButton.onClick.AddListener(OpenTasksPanel);
        tasksPanel.SetActive(false);

        taskManager = taskPanel1.GetComponent<TaskManager>();
        taskManager2 = taskPanel2.GetComponent<TaskManager>();


        artifactsButton.onClick.AddListener(OpenArtifactsPanel);
        artifactsPanel.SetActive(false);

        dailyRewardButton.onClick.AddListener(OpenDailyRewardPanel);
        dailyRewardPanel.SetActive(false);

        shopButton.onClick.AddListener(OpenShopPanel);
        shopPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (taskManager.taskIsOpened == true)
            {
                taskManager.Update();
            }
            if (taskManager2.taskIsOpened == true)
            {
                taskManager2.Update();
            }
        }

        // moved button control part to separate function, gonna check this out with UnityEvents

        /*{
            if (InternetCheck.isInternetAccesable == false)
            {
                shopButton.interactable = false;
                dailyRewardButton.interactable = false;
                fortuneWheelButton.interactable = false;
            }
            if (InternetCheck.isInternetAccesable == true)
            {
                if (!TutorialManager.isTutorialIsGoing)
                {
                    shopButton.interactable = true;
                    dailyRewardButton.interactable = true;
                    fortuneWheelButton.interactable = true;
                }
                else
                {
                    shopButton.interactable = false;
                    dailyRewardButton.interactable = false;
                    fortuneWheelButton.interactable = false;
                }
                
            }
        }*/

        {   //
            if (taskManager.rewardIsAvailable == true || taskManager2.rewardIsAvailable == true)
            {
                tasksExclamationMark.SetActive(true);
            }
            if (taskManager.rewardIsAvailable == false || taskManager2.rewardIsAvailable == false)
            {
                tasksExclamationMark.SetActive(false);
            }
        }
    }

    public void OpenFortuneWheelPanel()
    {
        fortuneWheelPanel.SetActive(true);
        isAnyPanelisActive = true;
    }

    public void OpenTasksPanel()
    {
        tasksPanel.SetActive(true);
        isAnyPanelisActive = true;
    }

    public void OpenArtifactsPanel()
    {
        artifactsPanel.SetActive(true);
        isAnyPanelisActive = true;
    }

    public void OpenDailyRewardPanel()
    {
        dailyRewardPanel.SetActive(true);
        isAnyPanelisActive = true;
    }

    public void OpenShopPanel()
    {
        shopPanel.SetActive(true);
        isAnyPanelisActive = true;
    }

    public void CheckInternetDependingButtons()
    {
        if (InternetCheck.isInternetAccesable == false)
        {
            shopButton.interactable = false;
            dailyRewardButton.interactable = false;
            fortuneWheelButton.interactable = false;
        }
        if (InternetCheck.isInternetAccesable == true)
        {
            if (!TutorialManager.isTutorialIsGoing)
            {
                shopButton.interactable = true;
                dailyRewardButton.interactable = true;
                fortuneWheelButton.interactable = true;
            }
            else
            {
                shopButton.interactable = false;
                dailyRewardButton.interactable = false;
                fortuneWheelButton.interactable = false;
            }

        }
    }

}
