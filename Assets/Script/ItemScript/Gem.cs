using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
    private PlayerStatus PlayerStatus;
    private ShowGem ShowGem;
    private bool isMoveUp = false;
    [SerializeField] private float upTime;
    private float tmpTime;
    [SerializeField] private AudioClip gemSound;
    private AudioSource audioSource;
    private bool flag = true;
    void Start () {
        ShowGem = GameObject.Find ("CanvasGUI").GetComponent<ShowGem> ();
        PlayerStatus = GameObject.Find ("chr_robot").GetComponent<PlayerStatus> ();
        upTime = 2;
        tmpTime = upTime;
        audioSource = GetComponent<AudioSource> ();
    }
    void Update () {
        transform.Rotate (new Vector3 (0, 2, 0));
        if (isMoveUp) {
            if (tmpTime > 0) {
                if (flag) {
                    flag = false;
                }
                transform.position += new Vector3 (0, 0.01f, 0);
                transform.Rotate (new Vector3 (0, 20, 0));
                tmpTime -= Time.deltaTime;
            } else {
                if (transform.tag == "Red")
                    ShowGem.uGUI_GemRed.SetActive (true);
                if (transform.tag == "Green")
                    ShowGem.uGUI_GemGreen.SetActive (true);
                if (transform.tag == "Blue")
                    ShowGem.uGUI_GemBlue.SetActive (true);
                tmpTime = upTime;
                isMoveUp = false;
                Destroy (gameObject);
            }
        }
    }
    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Player") && !isMoveUp) {
            PlayerStatus.getScore (1000);
            audioSource.PlayOneShot (gemSound);
            isMoveUp = true;
        }
    }
}
