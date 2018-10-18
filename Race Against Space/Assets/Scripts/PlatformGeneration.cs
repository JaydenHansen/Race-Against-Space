using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* !! List of chunk prefabs must be added manually in the Unity Inspector !! */

public class PlatformGeneration : MonoBehaviour {

    public GameObject[] numOfPlatforms;

    public GameObject[] chunkPrefabs;
    public GameObject selectedChunk;

    // Indicates where the next chunk should be spawned
    public GameObject heightMarker;

    // Number of platforms remaining before next chunk is spawned
    public int numOfPlatformsRemaining = 8;

	// Use this for initialization
	void Start ()
    {
        NextChunkSelection();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Gets the number of platforms currrently in the scene
        numOfPlatforms = GameObject.FindGameObjectsWithTag("Platforms");
        
        // Finds the Height indicator placed at the top of each chunk
        heightMarker = GameObject.FindGameObjectWithTag("HeightMarker");

        // When the number of platforms drops below a certain amount...
        if (numOfPlatforms.Length <= numOfPlatformsRemaining)
        {
            // ...Spawn a new chunk at the height marker
            Instantiate(selectedChunk, new Vector3(0, heightMarker.transform.position.y, -2.75f), Quaternion.identity);
            // ...Delete the current height marker
            Destroy(heightMarker);
            // ...Select the next chunk
            NextChunkSelection();
        }
	}

    // Selects which chunk will be spawned next
    void NextChunkSelection()
    {
        int chunkNumber;
        
        // Generates a random number up to the amount of prefabs in the list
        chunkNumber = Random.Range(0, chunkPrefabs.Length);
        // Sets the selected number as the index of the list and spawns that chunk
        selectedChunk = chunkPrefabs[chunkNumber];
    }
}
