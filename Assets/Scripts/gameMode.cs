using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMode : MonoBehaviour
{
    int numberPlayers;
    public static bool gameHasStarted;
    public MonoBehaviour playerScript;
    private PhotonView pw;

    public Rigidbody playerRigidbody;

    public bool isTesting;
    // Start is called before the first frame update
    void Start()
    {
        pw = GetComponent<PhotonView>();
        gameHasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTesting)
        {
            if (!pw.isMine)
                return;

            if (!gameHasStarted)
            {
                playerRigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                playerScript.enabled = false;
            }

            GameObject[] numPlayer;
            numPlayer = GameObject.FindGameObjectsWithTag("Player");
            //numberPlayers = PhotonNetwork.countOfPlayers;

            if (numPlayer.Length > 1)
            {

                gameHasStarted = true;
                playerRigidbody.constraints = RigidbodyConstraints.None;
                playerScript.enabled = true;
            }
            else if (numPlayer.Length < 2)
                gameHasStarted = false;
        }
       
    }
}
