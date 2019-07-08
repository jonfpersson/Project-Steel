using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerNetwork : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private MonoBehaviour[] playerControlScripts;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private GameObject[] playerParts;

    public TextMesh floatingName;

    private PhotonView pw;

    //private delegate void UpdateUI(string playerName);  
    //private event UpdateUI updateUI;

    string inputName = "Nisse";
    // Start is called before the first frame update
    void Start()
    {
        floatingName.text = inputName;
        pw = GetComponent<PhotonView>();
       // updateUI += FindObjectOfType<playerUI>().UpdateUI;

        ini();
    }

    public void ini()
    {
        if (pw.isMine)
        {
            foreach(GameObject g in playerParts)
            {
                g.SetActive(false);
            }
        }
        else
        {
            playerRigidbody.isKinematic = true;
            playerRigidbody.useGravity = false;
            playerCamera.SetActive(false);
            foreach(MonoBehaviour m in playerControlScripts)
            {
                m.enabled = false;
            }
        }

        //updateUI(inputName);
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting){
            stream.SendNext(floatingName.text);
        }
        else if (stream.isReading)
        {
            string name = (string)stream.ReceiveNext();
            floatingName.text = name;
        }
    }

}
