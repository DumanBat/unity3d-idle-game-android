using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    // UI
    
    public GameObject uiCanvas;
    public Component[] uiButtons;

    public GameObject tutorialPanel;
    public GameObject tutorialPanelMain;
    public GameObject blankPanel;
    public Text textDisplay;

    public GameObject tutorialButtonHarvest;
    public GameObject tutorialButtonManager;
    public GameObject tutorialButtonUpgrade;
    public GameObject tutorialButtonUnlock;
    public GameObject tutorialKolhozPanel;
    private static bool isButtonEnabled;


    public AudioSource typewritingSound;

    public GameObject tutorialArrow1;
    public GameObject tutorialArrow2;
    public GameObject tutorialArrow3;
    public GameObject tutorialArrow4;

    
    
    // DATA
    public static bool appFirstRun;
    public static int tutorialStepIndex;

    private bool nextStepIsAllowed;
    public static bool isTutorialIsGoing;
    public static bool isTutorialCompleted;

    public List<GameObject> tutorialArrowList;
    public List<bool> tutorialStepIsCompletedList;
    public List<string> tutorialTextList;

    // tutorial text
    public string tutorialText1;
    public string tutorialText2;
    public string tutorialText3;
    public string tutorialText4;
    public string tutorialText5;
    public string tutorialText6;
    public string tutorialText7;
    public string tutorialText8;
    public string tutorialText9;
    public string tutorialText10;
    
    public static int tutorialTextIndex;



    // typewriting text 
    public static float textDelay = 0.07f;

    private string currentFullText;
    private string currentTutorialText = "";



    // there's around 4 key steps in tutorial, around 10 total. most of the time is gonna be text
    // key steps index is tutorialStepIndex;
    // text steps index is tutorialTextIndex;


    // DUMA!!! YA ETO TI IZ PROSHLOGO!!! DON'T FORGET TO TURN ON TREE BUTTONs AT THE END OF TUTORIAL SECTION OR YOU WILL FUCKING DESTROY YOUR SHIT PROJECT DUMBASS
    private void Awake()
    {
        tutorialPanelMain.SetActive(false);

        tutorialPanel.GetComponent<Button>().interactable = false;

        tutorialTextList = new List<string>();
        tutorialTextList.Add(tutorialText1);
        tutorialTextList.Add(tutorialText2);
        tutorialTextList.Add(tutorialText3);
        tutorialTextList.Add(tutorialText4);
        tutorialTextList.Add(tutorialText5);
        tutorialTextList.Add(tutorialText6);
        tutorialTextList.Add(tutorialText7);
        tutorialTextList.Add(tutorialText8);
        tutorialTextList.Add(tutorialText9);
        tutorialTextList.Add(tutorialText10);


        tutorialArrowList = new List<GameObject>();
        tutorialArrowList.Add(tutorialArrow1);
        tutorialArrowList.Add(tutorialArrow2);
        tutorialArrowList.Add(tutorialArrow3);
        tutorialArrowList.Add(tutorialArrow4);

        for (int i = 0; i < tutorialArrowList.Count; i++)
        {
            tutorialArrowList[i].SetActive(false);
        }

    }

    public void StartTutorial()
    {
        isButtonEnabled = false;
        EnableButtons(isButtonEnabled);

        tutorialPanelMain.SetActive(true);

        isTutorialIsGoing = true;
        nextStepIsAllowed = true;
        
        tutorialTextIndex = 0;
        tutorialStepIndex = 999; // velosiped



        uiButtons = uiCanvas.GetComponentsInChildren<Button>();
        
        foreach (Button button in uiButtons)
        {
            button.interactable = false;
        }

        tutorialPanel.SetActive(true);
        blankPanel.SetActive(true);

        currentFullText = tutorialTextList[tutorialTextIndex];
       
        StartCoroutine(TypewritingTextCoroutine(currentFullText));

    }

    IEnumerator TypewritingTextCoroutine(string typewritingText)
    {
        blankPanel.SetActive(true);
        tutorialPanel.GetComponent<Button>().interactable = false;

        string exclamationMark = "!";
        string questionMark = "?";
        string dotMark = ".";

        typewritingText = typewritingText.Replace("!", "!\n");
        typewritingText = typewritingText.Replace("?", "?\n");
        typewritingText = typewritingText.Replace(".", ".\n");

        for (int i = 0; i < typewritingText.Length; i++)
        {
            currentTutorialText = typewritingText.Substring(0, i + 1);
            textDisplay.text = currentTutorialText;

            typewritingSound.Play();

            if (Equals(typewritingText[i].ToString(), exclamationMark)
                || Equals(typewritingText[i].ToString(), questionMark)
                || Equals(typewritingText[i].ToString(), dotMark))
            {
                yield return new WaitForSeconds(0.5f);
            }
            
            yield return new WaitForSeconds(textDelay);
        }

        DistributeTutorialStep(tutorialStepIndex);

        if (nextStepIsAllowed)
        {
            tutorialPanel.GetComponent<Button>().interactable = true;
            tutorialPanel.GetComponent<Button>().onClick.AddListener(ProceedToNextStep);
        }
        
    }

    public void ProceedToNextStep()
    {
        tutorialPanel.GetComponent<Button>().onClick.RemoveAllListeners();
        
        foreach (GameObject arrow in tutorialArrowList)
        {
            arrow.SetActive(false);
        }

        isButtonEnabled = false;
        EnableButtons(isButtonEnabled);

        blankPanel.SetActive(true);

        nextStepIsAllowed = true;

        tutorialTextIndex += 1;



        switch (tutorialTextIndex)
            {
            case 2:
                {
                    tutorialStepIndex = 0;
                    nextStepIsAllowed = false;
                    break;
                }
            case 4:
                {
                    tutorialStepIndex = 1;
                    nextStepIsAllowed = false;
                    break;
                }
            case 6:
                {
                    tutorialStepIndex = 2;
                    nextStepIsAllowed = false;
                    break;
                }
            case 8:
                {
                    tutorialStepIndex = 3;
                    nextStepIsAllowed = false;
                    break;
                }
            case 10:
                {
                    tutorialStepIndex = 999;
                    isTutorialIsGoing = false;
                    isTutorialCompleted = true;
                    blankPanel.SetActive(false);
                    isButtonEnabled = true;
                    EnableButtons(isButtonEnabled);
                    tutorialPanel.SetActive(false);
                    tutorialPanelMain.SetActive(false);

                    foreach (Button button in uiButtons)
                    {
                        button.interactable = true;
                    }
                    return;
                }
            default:
                {
                    tutorialStepIndex = 999;
                    break;
                }

            }

        currentFullText = tutorialTextList[tutorialTextIndex];

        StartCoroutine(TypewritingTextCoroutine(currentFullText));
    }

    public void DistributeTutorialStep(int index)
    {
        switch (index)
        {
            case 999:
                {
                    break;
                }
                
            case 0:
                {
                    blankPanel.SetActive(false);
                    tutorialArrowList[index].SetActive(true);
                    tutorialButtonHarvest.GetComponent<Button>().interactable = true;
                    break;
                }
                
            case 1:
                {
                    blankPanel.SetActive(false);
                    tutorialArrowList[index].SetActive(true);
                    tutorialButtonUpgrade.GetComponent<Button>().interactable = true;
                    break;
                }

            case 2:
                {
                    blankPanel.SetActive(false);
                    tutorialArrowList[index].SetActive(true);
                    tutorialButtonManager.GetComponent<Button>().interactable = true;
                    tutorialKolhozPanel.SetActive(false);
                    break;
                }

            case 3:
                {
                    blankPanel.SetActive(false);
                    tutorialArrowList[index].SetActive(true);
                    tutorialButtonUnlock.GetComponent<Button>().interactable = true;
                    break;
                }
        }
    }

    public void EnableButtons(bool daNet)
    {
            tutorialButtonHarvest.GetComponent<Button>().interactable = daNet;
            tutorialButtonManager.GetComponent<Button>().interactable = daNet;
            tutorialButtonUpgrade.GetComponent<Button>().interactable = daNet;
            tutorialButtonUnlock.GetComponent<Button>().interactable = daNet;
            tutorialKolhozPanel.SetActive(!daNet);
           
    }


}
