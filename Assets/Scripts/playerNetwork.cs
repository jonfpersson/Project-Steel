using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNetwork : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private MonoBehaviour[] playerControlScripts;

    private PhotonView pw;

    //private delegate void UpdateUI(string playerName);  
    //private event UpdateUI updateUI;

    string inputName = "Nisse";
    // Start is called before the first frame update
    void Start()
    {
        pw = GetComponent<PhotonView>();
       // updateUI += FindObjectOfType<playerUI>().UpdateUI;

        ini();
    }

    public void ini()
    {
        if (pw.isMine)
        {

        }
        else
        {
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
      //      stream.SendNext(name);
        }
        else if (stream.isReading)
        {
            //string name = (string)stream.ReceiveNext();
        }
    }

}
