using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTasks : MonoBehaviour
{
    // task 1
    public GameObject taskPanel1;
    TaskManager taskManager1;
    public TaskProgressBar taskProgressBar1;

    public static int taskID1;
    public static bool taskIsOpened1;

    public static float taskMinimumProgress1;
    public static float taskCurrentProgress1;
    public static float taskMaximumProgress1;

    // task 2
    public GameObject taskPanel2;
    TaskManager taskManager2;
    public TaskProgressBar taskProgressBar2;

    public static int taskID2;
    public static bool taskIsOpened2;

    public static float taskMinimumProgress2;
    public static float taskCurrentProgress2;
    public static float taskMaximumProgress2;


    // data to save
    public static List<bool> isTaskActiveList = new List<bool>();

    public static List<bool> isTaskCompletedList = new List<bool>();


    private void Awake()
    {
        taskManager1 = taskPanel1.GetComponent<TaskManager>();
        taskManager2 = taskPanel2.GetComponent<TaskManager>();
    }

    private void Update()
    {
       /* if (TaskDB.DB[taskManager1.currentTaskID].isTaskActive == true && TaskDB.DB[taskManager1.currentTaskID].isTaskCompleted == false &&
            TaskDB.DB[taskManager2.currentTaskID].isTaskActive == true && TaskDB.DB[taskManager2.currentTaskID].isTaskCompleted == false)
        {
            

        }*/
    }

    public void GetTaskData()
    {
        taskID1 = taskManager1.currentTaskID;
        taskIsOpened1 = taskManager1.taskIsOpened;

        taskMinimumProgress1 = taskProgressBar1.minimumProgress;
        taskCurrentProgress1 = taskProgressBar1.currentProgress;
        taskMaximumProgress1 = taskProgressBar1.maximumProgress;

        Debug.Log(taskID1 + " taskID1");
        Debug.Log(taskIsOpened1 + " task 1 state");


        taskID2 = taskManager2.currentTaskID;           
        taskIsOpened2 = taskManager2.taskIsOpened;

        taskMinimumProgress2 = taskProgressBar2.minimumProgress;
        taskCurrentProgress2 = taskProgressBar2.currentProgress;
        taskMaximumProgress2 = taskProgressBar2.maximumProgress;

        Debug.Log(taskID2 + " taskID2");
        Debug.Log(taskIsOpened2 + " task 2 state");

    }

    public void SetTaskData()
    {
        taskManager1.currentTaskID = taskID1;
        taskManager1.taskIsOpened = taskIsOpened1;

        taskProgressBar1.minimumProgress = taskMinimumProgress1;
        taskProgressBar1.currentProgress = taskCurrentProgress1;
        taskProgressBar1.maximumProgress = taskMaximumProgress1;


        taskManager2.currentTaskID = taskID2;
        taskManager2.taskIsOpened = taskIsOpened2;

        taskProgressBar2.minimumProgress = taskMinimumProgress2;
        taskProgressBar2.currentProgress = taskCurrentProgress2;
        taskProgressBar2.maximumProgress = taskMaximumProgress2;

    }

    public static void SaveTasksData()
    {
        for (int i = 0; i < TaskDB.DB.Count; i++)
        {
            isTaskActiveList.Add(TaskDB.DB[i].isTaskActive);
            isTaskCompletedList.Add(TaskDB.DB[i].isTaskCompleted);
        }


    }

    public static void LoadTasksData()
    {

    }
}
