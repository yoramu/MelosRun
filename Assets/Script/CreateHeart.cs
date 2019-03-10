using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHeart : MonoBehaviour {
    public GameObject Canvas;
    public PlayerStatus PlayerStatus;
    public float x = 0;
    // Start is called before the first frame update
    void Start () {
        x = 40;
        Canvas = GameObject.Find ("CanvasGUI");
        PlayerStatus = GameObject.Find ("chr_robot").GetComponent<PlayerStatus> ();
        GameObject HeartPrefab = (GameObject) Resources.Load ("Prefabs/Heart");
        for (int i = 0; i < PlayerStatus.PlayerHP; i++) {
            GameObject obj = (GameObject) Instantiate (HeartPrefab, new Vector3 (x, 223, 0), Quaternion.identity);
            obj.transform.parent = Canvas.transform;
            x += 30;
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
