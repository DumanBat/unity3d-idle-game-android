using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ManualHarvest : MonoBehaviour
{
    //references
    public GlobalValue globalValue;
    AutoHarvesting autoHarvesting;
    public Tree tree;

    //UI
    public Text harvestTimeDisplay;
    public Text harvestAmountDisplay;
    public AudioSource productSound;
    public Animator appleGrowAnimation;

    //data

    public UnityEvent harvestEvent; 
    
    /*public float harvestAmount = 3;
    public float harvestDuration = 3;*/
    //public float animationDuration = 3;
    public float remainingTime;


    private bool timerIsRunning = false;
    public bool isHarvesting = false;



    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Harvesting);
        autoHarvesting = GetComponent<AutoHarvesting>();
        remainingTime = tree.harvestDuration;
        
    }

    void Update()
    {
        harvestAmountDisplay.text = Mathf.RoundToInt(tree.harvestAmount) + "$" + " per ";

        if (timerIsRunning == true)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
               // print(remainingTime);
                RemainingTimeDisplay(remainingTime);
            }
            else
            {
                remainingTime = 0;
                remainingTime = tree.harvestDuration;
                timerIsRunning = false;
            }
        }


    }

    public void Harvesting()
    {
        

        if (isHarvesting == false && tree.managerIsActive == false)
        {
            productSound.Play();
            timerIsRunning = true;
            isHarvesting = true;
            appleGrowAnimation.SetTrigger("StartAnimation");
            StartCoroutine(HarvestCoroutine());
        } 
        
        if (isHarvesting == false)
        {
            timerIsRunning = true;
            isHarvesting = true;
            appleGrowAnimation.SetTrigger("StartAnimation");
            StartCoroutine(HarvestCoroutine());
        }
    }


    public void RemainingTimeDisplay(float remainingTimeToDisplay)
    {
        remainingTimeToDisplay += 1;

        float minutes = Mathf.FloorToInt(remainingTimeToDisplay / 60);
        float seconds = Mathf.FloorToInt(remainingTimeToDisplay % 60);

        harvestTimeDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator HarvestCoroutine()
    {
        yield return new WaitForSeconds(tree.harvestDuration);
        appleGrowAnimation.SetTrigger("EndAnimation");
        globalValue.CashValueChange(Mathf.RoundToInt(tree.harvestAmount), Mathf.RoundToInt(tree.harvestAmount));
        isHarvesting = false;

        if (TutorialManager.isTutorialIsGoing == true)
        {
            if (harvestEvent != null && TutorialManager.tutorialTextIndex == 2)
            {
                harvestEvent.Invoke();
            }
        }
        
    }

    /*IEnumerator GrowAnimation()
    {
        
        yield return new WaitForSeconds(animationDuration);
        
    }*/

}
