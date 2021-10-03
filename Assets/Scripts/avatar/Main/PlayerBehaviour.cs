using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour :MonoBehaviour
{
    Avatar currentAvatar;
    int taskID;
    float _timeUnit; 

    double[] values;
    DateTime disengageTime;

    public Stack<int> taskList = new Stack<int>();
    bool auto; 

    void Start()
    {
        currentAvatar = gameObject.GetComponent<Avatar>();
        values = new double[7];
        InvokeRepeating("UpdateHealth", 0f, GlobalClass.GlobalTime);
        auto = false;
        _timeUnit = GlobalClass.GlobalTime; 
    }
    void Update()
    {
        if (currentAvatar.isFree && taskList.Count!=0 && auto)
        {
            AutoExecute();
        }
        else if (taskList.Count != 0 && DateTime.Compare(DateTime.Now, disengageTime) >= 0)
        {
            EndTask(taskID);
        }
        else if(taskList.Count == 0)
        {
            auto = false; 
        }
    }
    /// <summary>
    /// List of public functions 
    /// </summary>
    public void AutoExecute()
    {
        int taskID = taskList.Peek();
        auto = true; 
        currentAvatar.isFree = false;
        disengageTime = DateTime.Now;
        values = TaskPool.TaskStats[taskID];   //values is a local copy of taskpool 
        disengageTime.AddSeconds(values[6] * _timeUnit);
    }

    public void AddTaskSelf(int taskID)
    {
        if (!taskList.Contains(taskID) && taskList.Count < 3)
        {
            taskList.Push(taskID);             
        }
        else
        {
            //oops
        }
    }

    public void DoTask(int taskID)
    {
        values = TaskPool.TaskStats[taskID];
        currentAvatar.HealthModifier(values[0], values[1], values[2], values[3], values[4], values[5]);
    }


    /// <summary>
    /// Utils 
    /// </summary>

    void EndTask(int taskID)
    {
        currentAvatar.isFree = true;
        currentAvatar.HealthModifier(values[0], values[1], values[2], values[3], values[4], values[5]);
        taskList.Pop();
    }

    void UpdateHealth()
    {
        currentAvatar.HealthModifier(-0.01, -0.09, -0.08, -0.08, -0.009, -0.09);
    }    
    


    /// <summary>
    /// ACTIONS THAT THE PLAYER CAN TAKE 
    /// these affect other avatars 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="TaskID"></param>
    public void AddTaskManual(String name, int TaskID)
    {
        AvatarBehaviour new_avatar = GameObject.Find(name).GetComponent<AvatarBehaviour>();
        new_avatar.addTask(TaskID);
    }

    public void DeleteTaskManual(String name, int TaskID)
    {
        AvatarBehaviour new_avatar = GameObject.Find(name).GetComponent<AvatarBehaviour>();
        new_avatar.deleteTask(TaskID);
    }
    public void stopAvatar(String name)
    {
        AvatarBehaviour new_avatar = GameObject.Find(name).GetComponent<AvatarBehaviour>();
        new_avatar.onStopTask(name);
    }
}
