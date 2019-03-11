using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHeart : MonoBehaviour {
    public GameObject Canvas;
    public PlayerStatus PlayerStatus;
    private float x = 0;
    public List<GameObject> listObj = new List<GameObject> ();
    // Start is called before the first frame update
    void Start () {
        x = 40;
        Canvas = GameObject.Find ("CanvasGUI");
        PlayerStatus = GameObject.Find ("chr_robot").GetComponent<PlayerStatus> ();
        GameObject HeartPrefab = (GameObject) Resources.Load ("Prefabs/Heart");
        for (int i = 0; i < PlayerStatus.PlayerHP; i++) {
            GameObject obj = (GameObject) Instantiate (HeartPrefab);
            obj.transform.SetParent (Canvas.transform, false);
            obj.transform.localPosition = new Vector2 (x - 336, 100);
            listObj.Add (obj);
            x += 30;
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
