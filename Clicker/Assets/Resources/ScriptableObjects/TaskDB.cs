using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskDB : MonoBehaviour
{
    public int tasksCount;

    public static SortedDictionary<int, Task> DB = new SortedDictionary<int, Task>();


    void Awake()
    {
        foreach (Task tasksSO in Resources.LoadAll<Task>("ScriptableObjects/Tasks"))
        {
            if (!DB.ContainsKey(tasksSO.taskID))
            {
                DB.Add(tasksSO.taskID, tasksSO);
            }
        }

        tasksCount = DB.Count;
    }
    

}
