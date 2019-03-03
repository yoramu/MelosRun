using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuruBuruScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayMethod(0.05f, -0.03f, 0.029f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {
            transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
        } 
        if (transform.localScale.x > 50){
            //explosion flag    
        }
    }

    IEnumerator DelayMethod(float delay, float para, float next_para) {
        yield return new WaitForSeconds(delay);
        transform.localScale += new Vector3(para, para, para);
        StartCoroutine(DelayMethod(delay, next_para, para));
    }
}
