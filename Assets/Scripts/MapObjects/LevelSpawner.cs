using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject GameplayArea;     // This is the area the Player has to avoid the Tubes and Collect the Coins. This contains the Background.
    public GameObject PlayerArea;       // This is the area the Player Spawns. This is Player Area with no Obstacles.
    public GameObject BackgroundArea;   // This is the Background area. This is without a playable area.
    public GameObject SpawnTo;          // This is the Reference Point to Spawn the GameObjects.
    private float DistanceTravelled = 0;// This is the Distance that the Player has travelled, starting from 0.
    
    // Spawn a preset for when the play begins.
    // Takes the Current Position of the Object 'SpawnTo' and then spawns Prefabs called 'GameplayArea', 'PlayerArea', 'BackgroundArea'.
    // After each Prefab spawned the 'SpawnTo' move to a specified location then spawns another Prefab to which the cycle repeats,
    // Unitil the a specific distance, then after the player has travelled a set distance, a new Prefab of 'GameplayArea' will be spawned at the 'SpawnTo' current location.

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

    // After every 60 units Travelled, spawn another GameplayArea at the SpawnTo object.

    public void Update()
    {
        // Move the object forward along the z-axis at a speed of 5 units per second.
        transform.position += new Vector3(0, 0, 5 * Time.deltaTime);

        // Check if the object has traveled a distance of 60 units along the z-axis.
        if (transform.position.z - DistanceTravelled >= 60)
        {
            // Update the distance traveled trackler to the current z position.
            DistanceTravelled = transform.position.z;

            // Spawn a new gameplay area at the specified spawn location.
            GameObject GameplayArea1 = Instantiate(GameplayArea, SpawnTo.transform);

            // Set the new gameplay area's parent to this object.
            GameplayArea1.transform.parent = transform;
        }
    }
}