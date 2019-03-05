using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAreaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            other.attachedRigidbody.AddForce(new Vector3(0.1f,0f,0f) , ForceMode.Impulse);
            // other.gameObject.transform.position += new Vector3(0.04f, 0f , 0f);
        }
    }
}
