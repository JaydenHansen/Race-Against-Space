using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManagement : MonoBehaviour {

    public float platformMoveSpeed = 1f;
    public float gameObjectDeleteY = -80f;

    // Update is called once per frame
    void Update () {
        this.gameObject.transform.position -= new Vector3(0, (platformMoveSpeed * 0.01f), 0);
        
        if(this.gameObject.transform.position.y < gameObjectDeleteY)
        {
            Destroy(this.gameObject);
        }
    }
}
