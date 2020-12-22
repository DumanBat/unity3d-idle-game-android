using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    // UI
    public Button closeDailyRewardPanelButton;
    public GameObject dailyRewardPanel;

    public GameObject dayButton1;
    public GameObject dayButton2;
    public GameObject dayButton3;
    public GameObject dayButton4;
    public GameObject dayButton5;
    public GameObject dayButton6;
    public GameObject dayButton7;

    List<GameObject> dayButtonsList = new List<GameObject>();

    // DATA
    public TimeManager timeManager;

    public static int oldDay;
    public static int newDay;

    public static int date;
    public static string timerStatus;
    //public static bool timerStatus;

    public static int currentDay;

    public static bool day0;
    public static bool day1;
    public static bool day2;
    public static bool day3;
    public static bool day4;
    public static bool day5;
    public static bool day6;

    public static List<bool> daysList = new List<bool>();


    private void Awake()
    {
        dayButtonsList.Add(dayButton1);
        dayButtonsList.Add(dayButton2);
        dayButtonsList.Add(dayButton3);
        dayButtonsList.Add(dayButton4);
        dayButtonsList.Add(dayButton5);
        dayButtonsList.Add(dayButton6);
        dayButtonsList.Add(dayButton7);

        daysList.Add(day0);
        daysList.Add(day1);
        daysList.Add(day2);
        daysList.Add(day3);
        daysList.Add(day4);
        daysList.Add(day5);
        daysList.Add(day6);


        timerStatus = "FirstRun";
    }


    void Start()
    {
        closeDailyRewardPanelButton.onClick.AddListener(CloseDailyRewardPanel);

        


        for (int i = 0; i < dayButtonsList.Count; i++)
        {
            dayButtonsList[i].GetComponent<Button>().interactable = false;
        }


        StartCoroutine("WaitForLoading1");
    }

    public void CloseDailyRewardPanel()
    {
        
        dailyRewardPanel.SetActive(false);
        LSideUIContoller.isAnyPanelisActive = false;
    }

    IEnumerator StartTimer()
    {
        Debug.Log("1   starting timer");
        yield return StartCoroutine(TimeManager.sharedInstance.GetTime());

        //PlayerPrefs.SetInt("date", TimeManager.sharedInstance.GetCurrentDateNow());
        date = TimeManager.sharedInstance.GetCurrentDateNow();

        Debug.Log(/*(PlayerPrefs.GetInt("date"))*/ date + " setted date");

        //PlayerPrefs.SetString("timerStatus", "Active");
        timerStatus = "Active";
        //timerStatus = true;

    }

    IEnumerator CheckDate()
    {
        Debug.Log("1  checking Date");
        yield return StartCoroutine(TimeManager.sharedInstance.GetTime());

        oldDay = /*PlayerPrefs.GetInt("date")*/ date;

        Debug.Log(oldDay + " old day");
        newDay = TimeManager.sharedInstance.GetCurrentDateNow();

        //newDay = 12341212;

        if (oldDay != newDay)
        {
            EnablingClaimButton();
            Debug.Log("old day != new day, so enabling claim button");
        }

    

    }


    IEnumerator FirstRun()
    {
        Debug.Log("1  first run");
        yield return StartCoroutine(TimeManager.sharedInstance.GetTime());

        date = TimeManager.sharedInstance.GetCurrentDateNow();

        EnablingClaimButton();
        Debug.Log("first run, enabling claim button");
    }

    // Reset function
    public void RewardsReset()
    {
        /*PlayerPrefs.SetString("timerStatus", "Inactive");

        PlayerPrefs.SetString("day0", "notTaken");
        PlayerPrefs.SetString("day1", "notTaken");
        PlayerPrefs.SetString("day2", "notTaken");
        PlayerPrefs.SetString("day3", "notTaken");
        PlayerPrefs.SetString("day4", "notTaken");
        PlayerPrefs.SetString("day5", "notTaken");
        PlayerPrefs.SetString("day6", "notTaken");*/

        timerStatus = "Inactive";
        //timerStatus = false;

        /*day0 = false;
        day1 = false;
        day2 = false;
        day3 = false;
        day4 = false;
        day5 = false;
        day6 = false;*/

        for (int i = 0; i < 7; i++)
        {
            daysList[i] = false;
        }

    }

    public void EnablingClaimButton()
    {
        Debug.Log("2  enabling claim button");

        /*dayButtonsList[Convert.ToInt32(PlayerPrefs.GetString("currentDay"))].gameObject.GetComponent<Button>().interactable = true;
        dayButtonsList[Convert.ToInt32(PlayerPrefs.GetString("currentDay"))].gameObject.GetComponent<Button>().onClick.AddListener(ClaimingReward);*/

        dayButtonsList[currentDay].GetComponent<Button>().interactable = true;
        dayButtonsList[currentDay].GetComponent<Button>().onClick.AddListener(ClaimingReward);
    }

    public void ClaimingReward()
    {
        Debug.Log("3  claiming reward");

        daysList[currentDay] = true;

        switch (/*Convert.ToInt32(PlayerPrefs.GetString("currentDay"))*/ currentDay)
        {
            case 0:
                {
                    GlobalValue.globalGold += 3;
                    break;
                }
            case 1:
                {
                    GlobalValue.globalApple += 2;
                    GlobalValue.globalDiamond += 3;
                    break;
                }
            case 2:
                {
                    GlobalValue.globalCash *= 2;
                    break;
                }
            case 3:
                {
                    break;
                }
            case 4:
                {
                    break;
                }
            case 5:
                {
                    break;
                }
            case 6:
                {
                    RewardsReset();
                    break;
                }
        }

        /*dayButtonsList[Convert.ToInt32(PlayerPrefs.GetString("currentDay"))].gameObject.GetComponent<Button>().interactable = false;
        dayButtonsList[Convert.ToInt32(PlayerPrefs.GetString("currentDay"))].gameObject.GetComponent<Button>().onClick.RemoveListener(ClaimingReward);*/

        dayButtonsList[currentDay].GetComponent<Button>().interactable = false;
        dayButtonsList[currentDay].GetComponent<Button>().onClick.RemoveListener(ClaimingReward);



        /*PlayerPrefs.SetString("day" + Convert.ToInt32(PlayerPrefs.GetString("currentDay")), "Taken");*/
        

        /*PlayerPrefs.SetString("timerStatus", "Inactive");*/
        timerStatus = "Inactive";
        //timerStatus = false;
        

        StartingChecks();
    }

    public void StartingChecks()
    {
        Debug.Log("0  starting checks");

        for (int i = 0; i < dayButtonsList.Count; i++)
        {
            if (/*PlayerPrefs.GetString("day" + i) == "notTaken"*/ daysList[i] == false)
            {
                //PlayerPrefs.SetString("currentDay", i.ToString());

                currentDay = i;
                Debug.Log("current day " + /*PlayerPrefs.GetString("currentDay")*/ currentDay);
                break;
            }
        }

        Debug.Log(timerStatus);

        if (/*PlayerPrefs.GetString("timerStatus") == "Active"*/ timerStatus == "Active" /*timerStatus == true*/)// ?????????????????????????
        {
            StartCoroutine("CheckDate");
        }
        else if (/*PlayerPrefs.GetString("timerStatus") == "Inactive"*/ timerStatus == "Inactive" /*timerStatus == false*/)
        {
            StartCoroutine("StartTimer");
        }
        else if (timerStatus == "FirstRun")
        {
            StartCoroutine("FirstRun");
        }

    }

    IEnumerator WaitForLoading1()
    {
        yield return new WaitForSeconds(5);
        if (InternetCheck.isInternetAccesable == true)
        {
            StartingChecks();
        }
        
    }
}
