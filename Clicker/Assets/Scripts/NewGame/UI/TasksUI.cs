using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasksUI : MonoBehaviour
{
    public Button exitButton;
    public GameObject tasksPanel;


    void Start()
    {
        exitButton.onClick.AddListener(CloseTasksPanel);
    }


    public void CloseTasksPanel()
    {
        tasksPanel.SetActive(false);
        LSideUIContoller.isAnyPanelisActive = false;
    }
}
