using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    
    public GlobalValue globalValue;

    // UI
    public GameObject blankPanel;
    public GameObject profitTakingPanel;

    Button profit30minButton;

    public Text expressProfitAmountDisplay;
    public Text expressProfitValueDisplay;

    public ParticleSystem cashParticles;
    public AudioSource cashParticlesSound;

    // DATA
    public static int expressProfitCost;
    public static int expressProfitValue;


    private void Awake()
    {
        profit30minButton = GetComponent<Button>();
        profit30minButton.onClick.AddListener(ExpressProfit);

 
        profitTakingPanel.SetActive(false);
    }

    private void Update()
    {
        // 
        
        /*expressProfitAmountDisplay.text = GlobalValue.expressProfitAmount.ToString();*/
    }


    public void ExpressProfit()
    {
        expressProfitValue = 1800 * Mathf.RoundToInt(GlobalValue.harvestPerSecTotal);
        expressProfitValueDisplay.text = expressProfitValue.ToString() + "$";

        profitTakingPanel.SetActive(true);

        cashParticles.Play();
        cashParticlesSound.Play();

        StartCoroutine("ProfitTaking");
    }

    public void GettingExpressProfit()
    {
        GlobalValue.expressProfitAmount += 1;
        GlobalValue.globalDiamond -= expressProfitCost;
    }

    IEnumerator ProfitTaking()
    {
        blankPanel.GetComponent<Button>().onClick.AddListener(CloseProfitTakingPanel);

        yield return new WaitForSeconds(cashParticles.main.duration);

        CloseProfitTakingPanel();
    }

    public void CloseProfitTakingPanel()
    {
        StopCoroutine("ProfitTaking");

        blankPanel.GetComponent<Button>().onClick.RemoveListener(CloseProfitTakingPanel);
        
        globalValue.CashValueChange(expressProfitValue, expressProfitValue);
        GlobalValue.expressProfitAmount -= 1;

        profitTakingPanel.SetActive(false);
    }
}
