using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataTime : MonoBehaviour
{
    // UI
    public GameObject offlineRewardPanel;
    public GameObject blankPanel;

    public Text offlineProfitDisplay;
    public Text youWereOfflineFor;

    public GlobalValue globalValue;
    
    public static DateTime exitFullDate;
    public static DateTime enterFullDate;
    //public static DateTime nullFullDate;

    public static TimeSpan timeInterval;
    public static int cashEarnedOffline;

    private static int exitYear;
    private static int exitMonth;
    private static int exitDay;


    private static int exitHour;
    private static int exitMinute;
    private static int exitSecond;

    private static int enterYear;
    private static int enterMonth;
    private static int enterDay;


    private static int enterHour;
    private static int enterMinute;
    private static int enterSecond;

    private void Start()
     {
         StartCoroutine("WaitForLoading3");

        offlineRewardPanel.SetActive(false);
     }

    public IEnumerator SaveCurrentTimeCoroutine()
    {
        yield return StartCoroutine(TimeManager.sharedInstance.GetTime());

        string[] wordsDate = TimeManager._currentDate.Split('-');

        string[] wordsTime = TimeManager._currentTime.Split(':');

        exitDay = int.Parse(wordsDate[1]);
        exitMonth = int.Parse(wordsDate[0]);
        exitYear = int.Parse(wordsDate[2]);

        exitHour = int.Parse(wordsTime[0]);
        exitMinute = int.Parse(wordsTime[1]);
        exitSecond = int.Parse(wordsTime[2]);

        exitFullDate = new DateTime(exitYear, exitMonth, exitDay, exitHour, exitMinute, exitSecond);
        Debug.Log(exitFullDate.ToString() + " exit full date suka");


    }


    IEnumerator CheckPassedTimeCoroutine()
    {
        yield return StartCoroutine(TimeManager.sharedInstance.GetTime());



        string[] wordsDate = TimeManager._currentDate.Split('-');

        string[] wordsTime = TimeManager._currentTime.Split(':');

        enterDay = int.Parse(wordsDate[1]);
        enterMonth = int.Parse(wordsDate[0]);
        enterYear = int.Parse(wordsDate[2]);

        enterHour = int.Parse(wordsTime[0]);
        enterMinute = int.Parse(wordsTime[1]);
        enterSecond = int.Parse(wordsTime[2]);

        enterFullDate = new DateTime(enterYear, enterMonth, enterDay, enterHour, enterMinute, enterSecond);

        // if exit full date = 0 blah blah blah
        if (exitFullDate != DateTime.MinValue)
        {
            offlineRewardPanel.SetActive(true);
            StartCoroutine(OfflineProfitTakingCoroutine());

            Debug.Log(exitFullDate + " exit full date suka saved value");

            timeInterval = enterFullDate - exitFullDate;
            cashEarnedOffline = Mathf.RoundToInt(Convert.ToSingle(timeInterval.TotalSeconds) * GlobalValue.harvestPerSecTotal);

            offlineProfitDisplay.text = cashEarnedOffline.ToString();
            youWereOfflineFor.text = "You were offline for " + timeInterval.ToString();

            Debug.Log(timeInterval.TotalSeconds.ToString() + " time interval suka");
            Debug.Log(cashEarnedOffline + "cash earned offline");
        }
        else
        {
            Debug.LogError("ExitFullDate = 0. No offline profit.");
        }
    }

    IEnumerator WaitForLoading3()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(CheckPassedTimeCoroutine());
    }

    IEnumerator OfflineProfitTakingCoroutine()
    {
        blankPanel.GetComponent<Button>().onClick.AddListener(CloseOfflineProfitPanel);
        yield return new WaitForSeconds(5f);
        CloseOfflineProfitPanel();
    }

    public void CloseOfflineProfitPanel()
    {
        StopCoroutine(OfflineProfitTakingCoroutine());
        blankPanel.GetComponent<Button>().onClick.RemoveListener(CloseOfflineProfitPanel);

        offlineRewardPanel.SetActive(false);

        globalValue.CashValueChange(cashEarnedOffline, cashEarnedOffline);
    }
}
