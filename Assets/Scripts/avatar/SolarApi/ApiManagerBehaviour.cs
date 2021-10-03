using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ApiManagerBehaviour : MonoBehaviour {
    
    public GameObject Planet;

    private static SolarBodies solarSystemBodies = null;
    
    // Use this for initialization
    void Start () {
        var apiJson = SolarSystemOpenData.GetSolaireBodies();
        Debug.Log(apiJson);
        solarSystemBodies = (SolarBodies) JsonConvert.DeserializeObject<SolarBodies>(apiJson);
        foreach (SolarBody body in solarSystemBodies.bodies) {
            // First, let's spawn our planets!
            if (body.isPlanet) {
                double X = 0;
                double Y = 0;
                double Z = 0;
                double ROT_Y = 0;
                double SPEED = 10;
                if (body.englishName == "Mercury"){
                    X = 0.771;
                    Y = 0.1156;
                    SPEED = 47.87;
                } else if (body.englishName == "Venus"){
                    X = 1.4;
                    Y = 0.01;
                    Z = -0.856;
                    ROT_Y = 31.3;
                    SPEED = 35.02;
                } else if (body.englishName == "Earth"){ // Some bug with Earth
                    X = 1.96;
                    Y = 0.0000;
                    Z = 1.38;
                    ROT_Y = -35.1;
                    SPEED = 29.78;
                } else if (body.englishName == "Mars"){
                    X = -2.03;
                    Y = 0.14;
                    Z = -2.53;
                    ROT_Y = 128.8;
                    SPEED = 24.07;
                } else if (body.englishName == "Jupiter"){
                    X = 10.58;
                    Y = -0.07;
                    Z = -0.69;
                    ROT_Y = 3.784;
                    SPEED = 13.07;
                } else if (body.englishName == "Saturn"){
                    X = 9.5388;
                    Y = 0.0560;
                    Z = -0.69;
                    ROT_Y = 3.784;
                    SPEED = 9.69;
                } else if (body.englishName == "Uranus"){
                    X = 19.1914;
                    Y = -0.0461;
                    SPEED = 6.81;
                } else if (body.englishName == "Neptune"){
                    X = -7.677;
                    Y = 0.084;
                    Z = 17.685;
                    ROT_Y = -113.47;
                    SPEED = 5.43;
                } else if (body.englishName == "Pluto"){
                    X = 39.5136;
                    Y = 0.2484;
                    SPEED = 4.7;
                }
                if (X != 0){
                    Debug.Log(body.englishName);
                    GameObject obj = Instantiate(Planet, new Vector3((float) X, (float) Y, (float) Z), Quaternion.Euler(new Vector3(0, (float) ROT_Y, 0)));
                    obj.GetComponent<SpaceObjectModel>().rotationSpeed = (float) SPEED;
                    obj.GetComponent<SpaceObjectModel>().Body = body;
                }
            }
        }
    }
    
    // Update is called once per frame
    void Update () {
    }


    [System.Serializable]
    public class SolarBodies {
        public List<SolarBody> bodies;
    }

    [System.Serializable]
    public class SolarBody {
        public string id { get; set; }
        public string name { get; set; }
        public string englishName { get; set; }
        public bool isPlanet { get; set; }
        public object moons { get; set; }
        public Int64 semimajorAxis { get; set; }
        public Int64 perihelion { get; set; }
        public Int64 aphelion { get; set; }
        public double eccentricity { get; set; }
        public double inclination { get; set; }
        public Mass mass { get; set; }
        public Vol vol { get; set; }
        public double density { get; set; }
        public double gravity { get; set; }
        public double escape { get; set; }
        public double meanRadius { get; set; }
        public double equaRadius { get; set; }
        public double polarRadius { get; set; }
        public double flattening { get; set; }
        public string dimension { get; set; }
        public double sideralOrbit { get; set; }
        public double sideralRotation { get; set; }
        public AroundPlanet aroundPlanet { get; set; }
        public string discoveredBy { get; set; }
        public string discoveryDate { get; set; }
        public string alternativeName { get; set; }
        public double axialTilt { get; set; }
        public Int64 avgTemp { get; set; }
        public double mainAnomaly { get; set; }
        public double argPeriapsis { get; set; }
        public double longAscNode { get; set; }
        public string rel { get; set; }
    }

    [System.Serializable]
    public class Mass
    {
        public double massValue { get; set; }
        public Int64 massExponent { get; set; }
    }

    [System.Serializable]
    public class Vol
    {
        public double volValue { get; set; }
        public Int64 volExponent { get; set; }
    }
    
    [System.Serializable]
    public class AroundPlanet
    {
        public string planet { get; set; }
        public string rel { get; set; }
    }

}