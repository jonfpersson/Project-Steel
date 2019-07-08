using UnityEngine;
using System.Collections;

public class checkBallVelocity : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y < -2)
            PhotonNetwork.Destroy(gameObject);
    }
}