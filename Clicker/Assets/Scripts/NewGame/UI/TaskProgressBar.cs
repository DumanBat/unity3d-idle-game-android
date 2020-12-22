using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//[ExecuteInEditMode()]
public class TaskProgressBar : MonoBehaviour
{
    TaskManager taskManager;

    public float minimumProgress;
    public float maximumProgress;
    public float currentProgress;

    public Image mask;
    public Image fill;
    public Color color;

    public bool componentIsTaken = false;


    void Awake()
    {
        
    }

    void Start()
    {
        minimumProgress = 0;
        currentProgress = 0;
        //taskManager = GetComponentInParent<TaskManager>();
    }

    void Update()
    {

        if (componentIsTaken == true) 
        {
            GetCurrentFill();
        }

        else
        {
            currentProgress = 0;
            GetCurrentFill();
        }
    }

    void GetCurrentFill()
    {
        float currentOffset = currentProgress - minimumProgress;
        float maximumOffset = maximumProgress - minimumProgress;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }

    public void GetComponentOfTaskManager()
    {
        taskManager = GetComponentInParent<TaskManager>();
        componentIsTaken = true;
    }
}
