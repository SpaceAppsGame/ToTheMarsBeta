using System;
using UnityEngine;

/* game     real
 * 1 hour = 40 s  
 */

public class PlayerController: MonoBehaviour 
{	
	GameObject closestObject;
    ClosestObjectsOutliner outliner;
    Rigidbody rb;
    public float thrust { get; set;  }
    Avatar player; 
    PlayerBehaviour playerBehaviour; 
    
    public int _time = 40; //in seconds 

    void Start()
    {
        //or make it static idk
        outliner = new ClosestObjectsOutliner();
        rb = this.GetComponent<Rigidbody>();
        player = this.GetComponent<Avatar>();
        playerBehaviour = this.GetComponent<PlayerBehaviour>();
    }

	void update()
    { 
        if (Input.GetKeyDown(KeyCode.Space) && player.isFree)
        {
            // No idea what is it suppose to outline here, need an array of GameObjects, E.g.
            GameObject[] objectsToSearch = GameObject.FindGameObjectsWithTag("Searchable");
            closestObject = outliner.getClosestObject(objectsToSearch);
            var dist = Vector3.Distance(closestObject.transform.position, transform.position);
            if(dist<5)
            {
                rb.AddForce(Vector3.forward * dist * thrust);
            }  
            else
            {
                //not close enough
            } 
        }
        else if(Input.GetKeyDown(KeyCode.Backspace) && player.isFree)
        {
            //need the closest wall but nvm lets just use this
            rb.AddForce(Vector3.back * thrust); 
        }
        //rotation 
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, (float) 0.5, 0);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, (float) -0.5, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (player.isFree)
            {
                SearchObject();
            }            
        }
    }

    
    void SearchObject()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5, 3); //3 is layer mask for food
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.tag=="Food")
            {
                // if avatar can eat every for hours and time taken to eat - 0 
                if(Time.time - player._foodTimer  >=4*_time)
                {
                    playerBehaviour.DoTask(1); 
                    player._foodTimer = Time.time; 
                }
            }
            if (hitCollider.tag == "pee")
            {
                if (Time.time - player._peeTimer >= 2*_time)
                {
                    playerBehaviour.DoTask(2); // TODO: Replace with actual tasks id
                    player._peeTimer = Time.time;
                }
                                
            }

        }
        
    }
    
}
