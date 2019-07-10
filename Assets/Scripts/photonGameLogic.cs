using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class photonGameLogic : Photon.MonoBehaviour
{

    [SerializeField] private Text txt;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject lobbyCamera;

    int numberPlayers;

    // Start is called before the first frame update
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings("version 1");
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("joined lobby");
        // RoomOptions roomOptions = new RoomOptions();

        PhotonNetwork.JoinOrCreateRoom("New", null, null);
    }

    public virtual void OnJoinedRoom()
    {
        CheckPlayers();
        //  PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation, 0);
        if (numberPlayers == 1)
        {
            PhotonNetwork.Instantiate(player.name, spawnPoints[0].position, spawnPoints[0].rotation, 0);
            numberPlayers = 2;
        }

        else if (numberPlayers == 2)
        {
            PhotonNetwork.Instantiate(player.name, spawnPoints[1].position, spawnPoints[1].rotation, 0);
            numberPlayers = 3;
        }
        else if (numberPlayers == 3)
        {
            PhotonNetwork.Instantiate(player.name, spawnPoints[2].position, spawnPoints[2].rotation, 0);
            numberPlayers = 4;
        }
        else if (numberPlayers == 4)
        {
            PhotonNetwork.Instantiate(player.name, spawnPoints[3].position, spawnPoints[3].rotation, 0);
            numberPlayers = 1;
        }
            lobbyCamera.SetActive(false);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckPlayers()
    {
        numberPlayers = PhotonNetwork.countOfPlayers;
        //if the number of player is heigher than the number of spawnpoint in the game (in this case 4),
        //spawn the players in round order
        for (int i = 0; i <= numberPlayers; i++)
        {
            if (numberPlayers > 4)
            {
                numberPlayers -= 4;
            }

        }
    }

}
