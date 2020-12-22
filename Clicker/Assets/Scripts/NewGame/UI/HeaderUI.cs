using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderUI : MonoBehaviour
{
    public GameObject statsPanelButton;
    public GameObject statsPanel;

    void Start()
    {
        statsPanelButton.GetComponent<Button>().onClick.AddListener(OpenStatsPanel);
        statsPanel.SetActive(false);
    }


    public void OpenStatsPanel()
    {
        statsPanel.SetActive(true);
        statsPanel.GetComponent<Stats>().ShowStats();
        LSideUIContoller.isAnyPanelisActive = true;
    }
}
