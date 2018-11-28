using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BlackholeManager : MonoBehaviour {

    public float blackHoleScreenShakeMagnitude = 1000f;
    public float blackHolescreenShakeRoughness = 1000f;
    public float blackHolescreenShakeFadeIn = 0.1f;
    public float blackHolescreenShakeFadeOut = 1f;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        if (other.gameObject.tag.Equals("Player"))
            CameraShaker.Instance.ShakeOnce(blackHoleScreenShakeMagnitude, blackHolescreenShakeRoughness, blackHolescreenShakeFadeIn, blackHolescreenShakeFadeOut);
    }
}
