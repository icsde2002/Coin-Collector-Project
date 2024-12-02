using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTubes : MonoBehaviour
{
    // Reference to the Tube prefab that will be instantiated
    public GameObject Tubes;

    // Reference to tube placement positions in the scene
    public GameObject TubePlacement1;
    public GameObject TubePlacement2;
    public GameObject TubePlacement3;
    public GameObject TubePlacement4;

    private void Start()
    {
        // Randomize the Y-position of TubePlacement1 within the given range and instantiate a Tube at its location
        float RandomFloat1 = Random.Range(-12.5f, 6f);
        TubePlacement1.transform.position = new Vector3(TubePlacement1.transform.position.x, RandomFloat1, TubePlacement1.transform.position.z);
        Instantiate(Tubes, TubePlacement1.transform);

        // Randomize the Y-position of TubePlacement2 within the given range and instantiate a Tube at its location
        float RandomFloat2 = Random.Range(-12.5f, 6f);
        TubePlacement2.transform.position = new Vector3(TubePlacement2.transform.position.x, RandomFloat2, TubePlacement2.transform.position.z);
        Instantiate(Tubes, TubePlacement2.transform);

        // Randomize the Y-position of TubePlacement3 within the given range and instantiate a Tube at its location
        float RandomFloat3 = Random.Range(-12.5f, 6f);
        TubePlacement3.transform.position = new Vector3(TubePlacement3.transform.position.x, RandomFloat3, TubePlacement3.transform.position.z);
        Instantiate(Tubes, TubePlacement3.transform);

        // Randomize the Y-position of TubePlacement4 within the given range and instantiate a Tube at its location
        float RandomFloat4 = Random.Range(-12.5f, 6f);
        TubePlacement4.transform.position = new Vector3(TubePlacement4.transform.position.x, RandomFloat4, TubePlacement4.transform.position.z);
        Instantiate(Tubes, TubePlacement4.transform);
    }
}