using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ClosestObjectsOutliner : MonoBehaviour {

    GameObject[] objects; 
    Shader selectedShader, defaultShader;
    GameObject currentObject;
    Avatar avatar;  

    private GameObject lastObject; 
    void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("Planet");  //returns GameObject[]
        avatar = this.GetComponent<Avatar>();
        selectedShader = Shader.Find("UltimateOutline"); 
    }

    void Update()
    {
        if(avatar.isFree)
        {
            currentObject = getClosestObject(objects);
            UpdateTexture(currentObject); 
        }        
    }

    public GameObject getClosestObject(GameObject[] objects)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in objects)
        {
            float dist = Vector3.Distance(currentPosition, potentialTarget.transform.position);
            if (dist < closestDistanceSqr)
            {
                closestDistanceSqr = dist;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }
    void UpdateTexture(GameObject gameObject)
    {
        if(gameObject != lastObject)
        {
            defaultShader = gameObject.GetComponent<Renderer>().material.shader; 
            gameObject.GetComponent<Renderer>().material.shader = selectedShader;
            if(lastObject != null){
               lastObject.GetComponent<Renderer>().material.shader = defaultShader;
            }
            Debug.Log("shader works"); 
            lastObject = gameObject;
        }
    }

}/*
    public List<GameObject> NearGameobjects = new List<GameObject>();
    public GameObject closestObject;
    public float oldDistance = 9999;
    public Shader m_Selected;
    private Shader m_Default = null;
    Renderer m_Renderer;

    private int i; //wtf is i 
    private void Update()
    {
        if(i%3==0) {
            UpdateClosest();
        }
        i++;
    }

    private void UpdateClosest()
    {
        float currDistance = 9999;
        GameObject currObject = null;
        foreach (GameObject g in NearGameobjects)
        {
            float dist = Vector3.Distance(this.gameObject.transform.position, g.transform.position);
            
            if (dist < currDistance)
            {
                currObject = g;
                currDistance = dist;
            }
        }
        if (currObject != closestObject){
            if (m_Default != null) {
                UpdateTextureBack(closestObject);
            }
            UpdateTexture(currObject);
        }
        closestObject = currObject;
        oldDistance = currDistance;
    }
    public GameObject getClosestObject()
    {
        return closestObject; 
    }
    

    private void UpdateTexture(GameObject closest) {
        //Fetch the Renderer from the GameObject
        m_Renderer = closest.GetComponent<Renderer>();

        m_Default = m_Renderer.material.shader;
        //Make sure to enable the Keywords
        m_Renderer.material.shader = m_Selected;
    }
    private void UpdateTextureBack(GameObject closest) {
        //Fetch the Renderer from the GameObject
        m_Renderer = closest.GetComponent<Renderer>();
        //Make sure to enable the Keywords
        m_Renderer.material.shader = m_Default;
    }
}*/