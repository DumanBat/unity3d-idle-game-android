using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortuneWheel : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;
    public static bool spinAllowed;
    private int finalAngle;

    private float lastShifts;

    public GameObject wheel;

    public Text winText;

    public static bool isWheelSpinning;
    // time data

    public static int spinDate;
    private int newDate;

    void Awake()
    {
        spinAllowed = true;
        wheel.GetComponent<Button>().onClick.AddListener(WheelSpin);
        
    }

    void Start()
    {
        StartCoroutine("FortuneWheelTimeCheckCoroutine");
    }

    public void WheelSpin()
    {
        if (spinAllowed)
        {
            StartCoroutine(WheelSpinCoroutine());
        }
        
    }

    IEnumerator WheelSpinCoroutine()
    {
        isWheelSpinning = true;
        StartCoroutine(TimeManager.sharedInstance.GetTime());

        spinAllowed = false;
        randomValue = Random.Range(200, 300);
        timeInterval = 0.02f;

        for (int i = 0; i < randomValue; i++)
        {
            transform.Rotate(0, 0, 5f);

            if (i > Mathf.RoundToInt(randomValue * 0.5f))
            {
                timeInterval = 0.05f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.7f))
            {
                timeInterval = 0.07f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.90f))
            {
                timeInterval = 0.1f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
            {
                timeInterval = 0.15f;
            }

            yield return new WaitForSeconds(timeInterval);
        }


        lastShifts = Mathf.RoundToInt(transform.eulerAngles.z) % 45;

        while (lastShifts != 0)
        {
            transform.Rotate(0, 0, 5f);
            lastShifts = Mathf.RoundToInt(transform.eulerAngles.z) % 45;
        }

        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);

        switch (finalAngle)
        {
            case 0:
                winText.text = "You can try again!";
                break;
            case 45:
                winText.text = "You win 3 Diamonds!";
                GlobalValue.globalDiamond += 3;
                break;
            case 90:
                winText.text = "You win 500$!";
                GlobalValue.globalCash += 500;
                break;
            case 135:
                winText.text = "You win 3 Golden Apples!";
                GlobalValue.globalApple += 3;
                break;
            case 180:
                winText.text = "You win 30 min of Profit!";
                GlobalValue.globalCash += Mathf.RoundToInt(GlobalValue.harvestPerSecTotal) * 1800; 
                break;
            case 225:
                winText.text = "You win cool Gay Hat!";
                
                break;
            case 270:
                winText.text = "You doubled your Money!";
                GlobalValue.globalCash *= 2;
                break;
            case 315:
                winText.text = "You win 5 Gold!";
                GlobalValue.globalGold += 5;
                break;
        }
        //spinAllowed = true; ////////////////////////////

        spinDate = TimeManager.sharedInstance.GetCurrentDateNow();
        isWheelSpinning = false;
    }

    IEnumerator FortuneWheelTimeCheckCoroutine()
    {
        yield return StartCoroutine(TimeManager.sharedInstance.GetTime());

        newDate = TimeManager.sharedInstance.GetCurrentDateNow();

        newDate = 43434334;

        if (newDate != spinDate)
        {
            spinAllowed = true;
        }
        else if (newDate == spinDate)
        {
            spinAllowed = false;
        }
        else if (spinDate == 0)
        {
            spinAllowed = true;
        }
    }
}
