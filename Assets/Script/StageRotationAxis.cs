using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRotationAxis : MonoBehaviour {
    private float direction;
    private PlayerMove PlayerMove;
    public GameObject SRA;
    public GameObject StageGroup;
    private float s;
    void Start () {
        SRA = GameObject.Find ("StageRotationAxis");
        StageGroup = GameObject.Find ("StageGroup");
    }
    void Update () { }

    private void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            StageGroup.transform.parent = SRA.transform;
            float y = StageGroup.transform.rotation.eulerAngles.y;
            PlayerMove = other.GetComponent<PlayerMove> ();
            direction = PlayerMove.direction;

            if (direction > 0) {
                if (0 <= y && y < 90) {
                    PlayerMove.IsMoveFalse ();
                    SRA.transform.Rotate (new Vector3 (0, 1, 0));
                } else {
                    PlayerMove.IsMoveTrue ();
                }
            } else if (direction < 0) {
                if (1 < y && y < 91) {
                    PlayerMove.IsMoveFalse ();
                    SRA.transform.Rotate (new Vector3 (0, -1, 0));
                } else {
                    PlayerMove.IsMoveTrue ();
                }
            }
            GameObject.Find ("StageGroup").transform.parent = null;

        }
    }
}