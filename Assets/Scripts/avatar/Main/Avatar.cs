using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO make probabilities 

public class Avatar : MonoBehaviour
{
	private HealthStat Brain = new HealthStat();
	private HealthStat Bone = new HealthStat();
	private HealthStat Muscle = new HealthStat();
	private HealthStat Immune = new HealthStat();
	private HealthStat Heart = new HealthStat();
	private HealthStat Mood = new HealthStat();

	public float _foodTimer { get; set;  }
	public float _peeTimer { get; set; }
	public bool isFree { get; set; }

	AvatarBehaviour avatarBehaviour;
	List<double> idle = GlobalClass.IdleList; 

	bool isDead = false;
	float SpeedMod = 1; //UNKNOWN REFERENCE 
	float NoStress = 1; //UNKNOWN REFERENCE

	void Start(){
		avatarBehaviour = this.GetComponent<AvatarBehaviour>();
	}	

	public void HealthModifier(double brain, double immune, double bones, double muscle, double heart, double mood)
    {
		if (Brain.Modifier((float) brain) && Immune.Modifier((float) immune) && Bone.Modifier((float) bones) && Muscle.Modifier((float) muscle) && Heart.Modifier((float) heart) && Mood.Modifier((float) mood))
		{
			isDead = false;
		}
		else
		{
			isDead = true;
		}

		// TODO: Debug 
		// InjuredModifiers(); 
    }

	public void InjuredModifiers()
    {
		if (Brain.IsInjured())
		{
			
			avatarBehaviour.TasksNumber = 2;
			Mood.Modifier((float) idle[5] * ((1 - Brain.GetPercent())*2)); 

			//player.screen = dizzy*(1 - Bone.GetPercent()); //wtf??

		}
		if (Immune.IsInjured())
		{
			Brain.Modifier((float) idle[0] * (1 - Immune.GetPercent()) * (float) 0.5);
			Bone.Modifier((float) idle[2] * (1 - Immune.GetPercent()) * (float) 0.5); 
			Muscle.Modifier((float) idle[3] * (1 - Immune.GetPercent()) * (float) 0.5);
			Heart.Modifier((float) idle[4] * (1 - Immune.GetPercent()) * (float) 0.5);
			Mood.Modifier((float) idle[5] * (1 - Immune.GetPercent()) * (float) 0.5);
		}
		if (Bone.IsInjured())
		{
			if (UnityEngine.Random.value >= (1 - Bone.GetPercent()))     //RANDOM ---- ---- ---- ALERT ---- ---- ---- RANDOM
			{ 
				Mood.Modifier((float) idle[5] * (1 - Bone.GetPercent()));
			}
			if(UnityEngine.Random.value >= (1- Bone.GetPercent())*0.2)      //RANDOM ---- ---- ---- ALERT ---- ---- ---- RANDOM
			{
				Muscle.Modifier((float) idle[3] * ((1 - Bone.GetPercent()) * 20));
				Bone.Modifier((float) idle[2] * ((1 - Bone.GetPercent()) * 20));
			}
		}
		if (Muscle.IsInjured())
		{
			SpeedMod = (1 - Muscle.GetPercent());
		}
		if (Heart.IsInjured())
		{
			if (UnityEngine.Random.value >= (1 - Heart.GetPercent())*(1 - Heart.GetPercent())* 0.1)
            {
				Heart.Modifier((float) -100000); // avatar.kill()
            }
		}
		if (Mood.IsInjured())
		{
			NoStress = 1 - Mood.GetPercent();
		}
	}

	//public wahtever Habits ;
	//public wahtever Skills;



}


