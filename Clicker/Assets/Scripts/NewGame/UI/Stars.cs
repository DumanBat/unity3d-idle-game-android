using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{
    public GlobalValue globalValue;
    public Stats stats;


    //UI

    public ParticleSystem starParticles;
    public AudioSource starTakingSound;

    public GameObject starTakingPanel;
    public GameObject blankPanel;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject star5;
    public GameObject star6;
    public GameObject star7;
    public GameObject star8;
    public GameObject star9;
    public GameObject star10;


    //DATA
    public static int cashAmountForStar1 = 500;
    public static int cashAmountForStar2 = 1000;
    public static int cashAmountForStar3 = 1500;
    public static int cashAmountForStar4 = 20000;
    public static int cashAmountForStar5 = 25000;
    public static int cashAmountForStar6 = 30000;
    public static int cashAmountForStar7 = 35000;
    public static int cashAmountForStar8 = 40000;
    public static int cashAmountForStar9 = 45000;
    public static int cashAmountForStar10 = 500000;

    public static List<int> starList = new List<int>();
    public static int currentCashGoal;

    public static int currentNumberInList;

    public static int currentStarsAchieved;

    List<GameObject> starImageList = new List<GameObject>();
    

    void Awake()
    {

        // DATA
        starList.Add(cashAmountForStar1);
        starList.Add(cashAmountForStar2);
        starList.Add(cashAmountForStar3);
        starList.Add(cashAmountForStar4);
        starList.Add(cashAmountForStar5);
        starList.Add(cashAmountForStar6);
        starList.Add(cashAmountForStar7);
        starList.Add(cashAmountForStar8);
        starList.Add(cashAmountForStar9);
        starList.Add(cashAmountForStar10);

        starImageList.Add(star1);
        starImageList.Add(star2);
        starImageList.Add(star3);
        starImageList.Add(star4);
        starImageList.Add(star5);
        starImageList.Add(star6);
        starImageList.Add(star7);
        starImageList.Add(star8);
        starImageList.Add(star9);
        starImageList.Add(star10);


        currentStarsAchieved = 0;

    }
    // Start is called before the first frame update
    void Start()
    {



        // UI
        starTakingPanel.SetActive(false);

        ///////


        if (currentStarsAchieved != 0)
        {
            for (int i = 0; i < (currentStarsAchieved); i++)
            {
                starImageList[i].SetActive(true);
                if (i == (currentStarsAchieved - 1))
                {
                    if (currentStarsAchieved <= 9)
                    {
                        GlobalValue.temporaryCashAmountForStar = starList[i + 1];
                        Debug.Log(GlobalValue.temporaryCashAmountForStar + " temporary cash amount");
                    }
                    
                    else
                    {
                        Debug.Log("Max stars achieved");
                    }
                }
                
            }
        }

        if (currentStarsAchieved == 0)
        {
            GlobalValue.temporaryCashAmountForStar = starList[0];
        }

    }


    public void ActivateStar()
    {
        starParticles.Play();
        starTakingSound.Play();

        currentStarsAchieved++;
        Debug.Log(currentStarsAchieved + " current stars achi");

        if (currentStarsAchieved < 10)
        {
            GlobalValue.temporaryCashAmountForStar = starList[currentStarsAchieved];
        }

        else
        {
            GlobalValue.temporaryCashAmountForStar = starList[currentStarsAchieved - 1];
            Debug.Log("Max stars achieved");
        }

        starTakingPanel.SetActive(true);
        StartCoroutine("StarCoroutine");

    }

    IEnumerator StarCoroutine()
    {
        blankPanel.GetComponent<Button>().onClick.AddListener(CloseStarTakingPanel);

        yield return new WaitForSeconds(5);
        
        
        CloseStarTakingPanel();
    }

    public void CloseStarTakingPanel()
    {
        StopCoroutine("StarCoroutine");

        blankPanel.GetComponent<Button>().onClick.RemoveListener(CloseStarTakingPanel);


        starImageList[currentStarsAchieved - 1].SetActive(true);


        

        starTakingPanel.SetActive(false);

    }
}
