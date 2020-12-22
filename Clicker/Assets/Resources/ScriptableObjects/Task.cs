using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Task", menuName = "ScriptableObjects/Task", order = 1)]
public class Task : ScriptableObject
{
    public int taskID;
    public bool isTaskActive;
    public bool isTaskCompleted;

    public string taskName;
    public string taskDescription;

    public int taskGoal;

    public int goldReward;
    public int appleReward;

    public enum TaskTypes {EarnCash, UpgradePanel, TakeBonus, nothing};
    public TaskTypes taskType;

    public enum PanelForUpgrade {nothing, Apple, Orange, Strawberry, Banana, Mango, Grape, Blueberry, Cherry, Lemon, Peach, Melon, Watermelon};
    public PanelForUpgrade panelForUpgrade;

    
}
