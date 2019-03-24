using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHeart : MonoBehaviour {
    private PlayerStatus PlayerStatus;
    private GameObject HeartPrefab;
    private float x = 0;
    public List<GameObject> listObj { get; private set; } = new List<GameObject> ();
    void Start () {
        x = 40;
        PlayerStatus = GameObject.Find ("chr_robot").GetComponent<PlayerStatus> ();
        HeartPrefab = (GameObject) Resources.Load ("Prefabs/Object/Heart");
        for (int i = 0; i < PlayerStatus.PlayerHP; i++) {
            GameObject obj = (GameObject) Instantiate (HeartPrefab);
            listObj.Add (obj);
            listObj[i].transform.SetParent (transform.GetChild (0), false);
            RectTransform RectTransform = listObj[i].GetComponent<RectTransform> ();
            RectTransform.anchorMin = new Vector2 (0, 1);
            RectTransform.anchorMax = new Vector2 (0, 1);
            RectTransform.pivot = new Vector2 (0, 1);
            RectTransform.anchoredPosition = new Vector2 (x, -10);
            x += 30;
        }
    }
    void Update () { }
    public void AddHearts () {
        GameObject obj = (GameObject) Instantiate (HeartPrefab);
        listObj.Add (obj);
        listObj[PlayerStatus.PlayerHP - 1].transform.SetParent (transform.GetChild (0), false);
        RectTransform RectTransform = listObj[PlayerStatus.PlayerHP - 1].GetComponent<RectTransform> ();
        RectTransform.anchorMin = new Vector2 (0, 1);
        RectTransform.anchorMax = new Vector2 (0, 1);
        RectTransform.pivot = new Vector2 (0, 1);
        RectTransform.anchoredPosition = new Vector2 (x, -10);
        x += 30;
    }
    public void LeftHearts () {
        listObj.RemoveAt (PlayerStatus.PlayerHP);
        x -= 30;
    }
}
