using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textController : MonoBehaviour
{
    public Text waitingForPlayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMode.gameHasStarted)
        {
            waitingForPlayers.enabled = false;
        }
        else
        {
            waitingForPlayers.enabled = true;

        }
    }
}
