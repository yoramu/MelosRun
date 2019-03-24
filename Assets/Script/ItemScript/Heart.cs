using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    private PlayerStatus PlayerStatus;
    private CreateHeart CreateHeart;
    private bool isMoveUp = false;
    [SerializeField] private float upTime;
    private float tmpTime;
    [SerializeField] private AudioClip heartSound;
    private AudioSource audioSource;
    void Start () {
        PlayerStatus = GameObject.Find ("chr_robot").GetComponent<PlayerStatus> ();
        CreateHeart = GameObject.Find ("CanvasGUI").GetComponent<CreateHeart> ();
        upTime = 2;
        tmpTime = upTime;
        audioSource = GetComponent<AudioSource> ();
    }
    void Update () {
        //transform.Rotate (new Vector3 (0, 0, 5));
        if (isMoveUp) {
            if (tmpTime > 0) {
                transform.position += new Vector3 (0, 0.01f, 0);
                //transform.Rotate (new Vector3 (0, 0, 100));
                tmpTime -= Time.deltaTime;
            } else {
                tmpTime = upTime;
                isMoveUp = false;
                Destroy (gameObject);
            }
        }
    }
    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Player") && !isMoveUp) {
            PlayerStatus.AddPlayerHP ();
            CreateHeart.AddHearts ();
            audioSource.PlayOneShot (heartSound);
            isMoveUp = true;
        }
    }
}
