using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject GameplayArea;     // This is the area the Player has to avoid the Tubes and Collect the Coins. This contains the Background.
    public GameObject PlayerArea;       // This is the area the Player Spawns. This is Player Area with no Obstacles.
    public GameObject BackgroundArea;   // This is the Background area. This is without a playable area.
    public GameObject SpawnTo;          // This is the Reference Point to Spawn the GameObjects.
    private float DistanceTravelled = 0;// This is the Distance the Player Travelled.

    // Spawn a preset for when the play begins.
    private void Start()
    {

        ///////////////////////////////////////////////////
        /////////////////   Player Area   /////////////////
        ///////////////// [Obstacle Free] /////////////////
        ///////////////////////////////////////////////////

        GameObject PlayerZone1 = Instantiate(PlayerArea, SpawnTo.transform);
        PlayerZone1.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, 0);
        GameObject PlayerZone2 = Instantiate(PlayerArea, SpawnTo.transform);
        PlayerZone2.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, 60);
        GameObject PlayerZone3 = Instantiate(PlayerArea, SpawnTo.transform);
        PlayerZone3.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, -60);

        ///////////////////////////////////////////////////
        ///////////////// BackGround Area /////////////////
        ///////////////////////////////////////////////////

        GameObject BackGroundZone1 = Instantiate(BackgroundArea, SpawnTo.transform);
        BackGroundZone1.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, 360);
        GameObject BackGroundZone2 = Instantiate(BackgroundArea, SpawnTo.transform);
        BackGroundZone2.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, 300);
        GameObject BackGroundZone3 = Instantiate(BackgroundArea, SpawnTo.transform);
        BackGroundZone3.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, 240);
        GameObject BackGroundZone4 = Instantiate(BackgroundArea, SpawnTo.transform);
        BackGroundZone4.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, 180);
        GameObject BackGroundZone5 = Instantiate(BackgroundArea, SpawnTo.transform);
        BackGroundZone5.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, 120);
        GameObject BackGroundZone6 = Instantiate(BackgroundArea, SpawnTo.transform);
        BackGroundZone6.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, 60);
        GameObject BackGroundZone7 = Instantiate(BackgroundArea, SpawnTo.transform);
        BackGroundZone7.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, 0);
        GameObject BackGroundZone8 = Instantiate(BackgroundArea, SpawnTo.transform);
        BackGroundZone8.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, -60);

        ////////////////////////////////////////////////////
        ///////////// Gameplay Area Pre-Spawn //////////////
        ////////////////////////////////////////////////////

        GameObject GameplayZone1 = Instantiate(GameplayArea, SpawnTo.transform);
        GameplayZone1.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, -120);
        GameObject GameplayZone2 = Instantiate(GameplayArea, SpawnTo.transform);
        GameplayZone2.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, -180);
        GameObject GameplayZone3 = Instantiate(GameplayArea, SpawnTo.transform);
        GameplayZone3.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, -240);
        GameObject GameplayZone4 = Instantiate(GameplayArea, SpawnTo.transform);
        GameplayZone4.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, -300);
        GameObject GameplayZone5 = Instantiate(GameplayArea, SpawnTo.transform);
        GameplayZone5.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, -360);
        GameObject GameplayZone6 = Instantiate(GameplayArea, SpawnTo.transform);
        GameplayZone6.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, -420);

        ////////////////////////////////////////////////////
        /////////////////// Gameplay Area //////////////////
        ////////////////////////////////////////////////////

        GameObject GameplayArea1 = Instantiate(GameplayArea, SpawnTo.transform);
        GameplayArea1.transform.parent = transform;
        SpawnTo.transform.position = new Vector3(0, 0, -420);

    }

    // After every Gameplay Area Template Travelled, spawn anotherone after it.

    public void Update()
    {
        transform.position += new Vector3(0, 0, 5 * Time.deltaTime);

        if (transform.position.z - DistanceTravelled >= 60)
        {
            DistanceTravelled = transform.position.z;
            GameObject GameplayArea1 = Instantiate(GameplayArea, SpawnTo.transform);
            GameplayArea1.transform.parent = transform;
        }
    }
}