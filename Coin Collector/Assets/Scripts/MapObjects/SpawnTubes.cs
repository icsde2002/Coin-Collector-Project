using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTubes : MonoBehaviour
{
    public GameObject Tubes;
    public GameObject TubePlacement1;
    public GameObject TubePlacement2;
    public GameObject TubePlacement3;
    public GameObject TubePlacement4;

    private void Start()
    {
        float RandomFloat1 = Random.Range(-12.5f, 6f);
        TubePlacement1.transform.position = new Vector3(TubePlacement1.transform.position.x, RandomFloat1, TubePlacement1.transform.position.z);
        Instantiate(Tubes, TubePlacement1.transform);
        float RandomFloat2 = Random.Range(-12.5f, 6f);
        TubePlacement2.transform.position = new Vector3(TubePlacement2.transform.position.x, RandomFloat2, TubePlacement2.transform.position.z);
        Instantiate(Tubes, TubePlacement2.transform);
        float RandomFloat3 = Random.Range(-12.5f, 6f);
        TubePlacement3.transform.position = new Vector3(TubePlacement3.transform.position.x, RandomFloat3, TubePlacement3.transform.position.z);
        Instantiate(Tubes, TubePlacement3.transform);
        float RandomFloat4 = Random.Range(-12.5f, 6);
        TubePlacement4.transform.position = new Vector3(TubePlacement4.transform.position.x, RandomFloat4, TubePlacement4.transform.position.z);
        Instantiate(Tubes, TubePlacement4.transform);
    }
}