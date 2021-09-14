using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] pickups;
    public GameObject[] clones;
    
    void Start()
    {
        SpawnObjects();
    }
    void Update()
    {
        for(int i = 0; i<clones.Length-1; i++)
        {
            clones[i].transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        }
        
    }
 

    public void SpawnObjects()
    { 
        for (int i = 0; i < 4; i++)
        {
            clones[i] = Instantiate(pickups[0], spawnLocations[i].transform.position, Quaternion.Euler(45,45,45));
            
        }
        for(int i = 4; i<8; i++)
        {
            clones[i] = Instantiate(pickups[1], spawnLocations[i].transform.position, Quaternion.Euler(45,45,45));
        }

        clones[8] = Instantiate(pickups[2], spawnLocations[8].transform.position, Quaternion.Euler(0,180,0));
    }
}
