using System;
using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;
/* 
index goes like this:
* brain = 0
* immune = 1
* bones = 2
* muscle = 3
* heart = 4
* mood = 5  
*/

public class AvatarBehaviour: MonoBehaviour
{
    Avatar currentAvatar;
    public int TasksNumber { get; set; } 
    int taskID;
    DateTime disengageTime;
    bool actionLock;

    public Stack<int> taskList; 
    double[] values;

    float _timeUnit; 

    void Start()
    {
        TasksNumber = 3; 
        currentAvatar = this.GetComponent<Avatar>();
        taskList = new Stack<int>();
        InvokeRepeating("UpdateHealth", 2f, 2f);
        actionLock = false;
        _timeUnit = GlobalClass.GlobalTime; 
    }

    void UpdateHealth()
    {
        currentAvatar.HealthModifier(-0.01, -0.09, -0.08, -0.08, -0.009, -0.09);
    }

    void Update()
    {
        if(taskList.Count == 0)
        {
            randomizer(); 
        }
        else
        {
            if(currentAvatar.isFree && !actionLock)
            {
                StartTask(); 
            }
            else if(DateTime.Compare(DateTime.Now, disengageTime) >= 0)
            {
                EndTask();
            }
        }
    }    


    void StartTask()
    {
        //TODO move to target 
        taskID = taskList.Peek();
        currentAvatar.isFree = false;
        disengageTime = DateTime.Now; 
        values = TaskPool.TaskStats[taskID];
        disengageTime.AddSeconds(values[6] * _timeUnit); 
        //Maybe start couroutine with animation 
    }

    void EndTask()
    {
        try {
            currentAvatar.isFree = true;
            currentAvatar.HealthModifier(values[0], values[1], values[2], values[3], values[4], values[5]);
            taskList.Pop(); 
        } catch (Exception exc){
            UnityEngine.Debug.Log(exc);
        }
    }

    public void onStopTask(string name)
    {
        actionLock = true;
        currentAvatar.isFree = true;
    }
    void onResume()
    {
        actionLock = false;
        StartTask();
    }

    void randomizer()
    {
        var r = new System.Random();
        double picker = r.NextDouble();
        int counter = 0; 
        //int total;
        foreach (int key in TaskPool.TaskStats.Keys)
        {
            taskList.Push(key);
            counter += 1;
            if(taskList.Count == TasksNumber)
            {
                break; 
            }
        }
    }

    public void addTask(int id){
        UnityEngine.Debug.Log("Add task not implemented yet.");
    }
    
    public void deleteTask(int id){
        UnityEngine.Debug.Log("Delete task not implemented yet.");
    }

}
