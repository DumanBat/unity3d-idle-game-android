using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    public GlobalValue globalValue;

    public GameObject blankObject;

    public GameObject cashBonus;
    public GameObject goldBonus;

    public static int cashBonusValue = 1000;
    public static int goldBonusValue = 1;

    public GameObject temporaryGO;
    public GameObject spawnedTemporaryGO;
    public int temporaryBonusValue;

    private int bonusDetermine;
    public bool bonusIsTaken = false;
    //public int bonusChance;
    private float bonusSpawnTime;

    public int bonusXPos;
    public int bonusYPos;

    public float currentTime;
    public static float minTime = 5f;
    public static float maxTime = 7f;

    public float bonusActiveTime = 5f;

    public float minBonusMultiplier = 0.6f;
    public float maxBonusMultiplier = 2f;


    public bool isSpawnTimeSetted;

    void Start()
    {
        StartCoroutine("WaitForLoading2");
    }

    void Update()
    {
        if (LSideUIContoller.isAnyPanelisActive == false && isSpawnTimeSetted == true)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= bonusSpawnTime)
            {
                SpawnBonus();
            }
        }

    }

    IEnumerator WaitForLoading2()
    {
        yield return new WaitForSeconds(2);
        SetBonusSpawnTime();
    }

    void SetBonusSpawnTime()
    {
        if (minTime == 0 && maxTime == 0)
        {
            minTime = 5f;
            maxTime = 7f;
        }

        if (cashBonusValue == 0 && goldBonusValue == 0)
        {
            cashBonusValue = 1000;
            goldBonusValue = 1;
        }
        bonusSpawnTime = Random.Range(minTime, maxTime);
        bonusDetermine = Random.Range(1, 3);

        bonusXPos = Random.Range(200, 700);
        bonusYPos = Random.Range(-1100, -200);

        isSpawnTimeSetted = true;

    }

    void SpawnBonus()
    {
        isSpawnTimeSetted = false;

        if (bonusDetermine == 1)
        {
            temporaryGO = cashBonus.gameObject;



            // NEED TO BALANCE AND ADD NEW "IF" STATEMENTS
            if (GlobalValue.harvestPerSecTotal <= 20)
            {          
                temporaryBonusValue = Mathf.RoundToInt((cashBonusValue * Random.Range(minBonusMultiplier, maxBonusMultiplier)));
            }

            if (GlobalValue.harvestPerSecTotal > 20 && GlobalValue.harvestPerSecTotal <= 100)
            {
                temporaryBonusValue = Mathf.RoundToInt(((cashBonusValue * 5) * Random.Range(minBonusMultiplier, maxBonusMultiplier)));
            }

            //temporaryBonusValue = Mathf.RoundToInt((GlobalValue.globalCash * Random.Range(minBonusMultiplier, maxBonusMultiplier)));
        }

        if (bonusDetermine == 2)
        {
            // NEED TO DECIDE THE AMOUNT OF GOLD
            temporaryGO = goldBonus.gameObject;
            temporaryBonusValue = Mathf.RoundToInt((goldBonusValue * Random.Range(minBonusMultiplier, maxBonusMultiplier)));
        }

        currentTime = 0;
        blankObject.transform.localPosition = new Vector3(bonusXPos, bonusYPos);
        spawnedTemporaryGO = Instantiate(temporaryGO, this.gameObject.transform, false);
        spawnedTemporaryGO.transform.position = blankObject.transform.position;
        spawnedTemporaryGO.GetComponent<Button>().onClick.AddListener(TakingBonus);
        StartCoroutine(SpawnBonusCoroutine());
    }

    IEnumerator SpawnBonusCoroutine()
    {
        //add animation here;
        yield return new WaitForSeconds(bonusActiveTime);

        if (bonusIsTaken == false)
        {
            blankObject.transform.localPosition = Vector3.zero;
            spawnedTemporaryGO.GetComponent<Button>().onClick.RemoveListener(TakingBonus);
            Destroy(spawnedTemporaryGO);
            SetBonusSpawnTime();
        }

        if (bonusIsTaken == true)
        {
            bonusIsTaken = false;
        }
        
    }

    public void TakingBonus()
    {
        if (bonusDetermine == 1)
        {
            globalValue.CashValueChange(temporaryBonusValue, temporaryBonusValue);
        }

        if (bonusDetermine == 2)
        {
            GlobalValue.globalGold += temporaryBonusValue;
        }

        bonusIsTaken = true;

        GlobalValue.totalBonusesTaken += 1;
        blankObject.transform.localPosition = Vector3.zero;
        spawnedTemporaryGO.GetComponent<Button>().onClick.RemoveListener(TakingBonus);
        Destroy(spawnedTemporaryGO);
        SetBonusSpawnTime();
    }
}
