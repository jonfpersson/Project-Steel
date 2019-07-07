using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class photonGameLogic : Photon.MonoBehaviour
{

    [SerializeField] private Text txt;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject lobbyCamera;

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
        PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation, 0);
        lobbyCamera.SetActive(false);
    }

    
    // Update is called once per frame
    void Update()
    {
      //TEST
      txt.text = PhotonNetwork.connectionStateDetailed.ToString();
        
    }

}
