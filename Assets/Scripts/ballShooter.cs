using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballShooter : MonoBehaviour
{
    public GameObject projectileAsset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = (GameObject)PhotonNetwork.Instantiate("bullet", transform.position + Camera.main.transform.up * 0.75f + Camera.main.transform.forward * 1.3f, Quaternion.identity, 0);
            //projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 60;
            
        }
    }
}
