using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public GameObject[] listOfEvents;

    public float eventInterval = 30f;
    private float eventTimer = 0f;

    public float eventCountdown = 5.0f;

    public GameObject upcomingEvent;
    public GameObject previousEvent;
	
	// Update is called once per frame
	void Update () {
        eventTimer += Time.deltaTime;

        if (eventTimer >= eventInterval)
        {
            eventCountdown -= Time.deltaTime;
            NextEventSelection();

            if (eventCountdown <= 0)
            {
                Instantiate(upcomingEvent, new Vector3(0, 0, 0), Quaternion.identity);
                previousEvent = upcomingEvent;
                upcomingEvent = null;

                eventTimer = 0f;
                eventCountdown = 5f;
            }
        }
	}

    void NextEventSelection()
    {
        int eventNumber;

        eventNumber = Random.Range(0, listOfEvents.Length);
        upcomingEvent = listOfEvents[eventNumber];

        if(previousEvent = upcomingEvent)
        {
            NextEventSelection();
        }
    }
}
