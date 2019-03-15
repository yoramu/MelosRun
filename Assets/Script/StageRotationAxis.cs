using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRotationAxis : MonoBehaviour {
    private float direction;
    private PlayerMove PlayerMove;
    public GameObject StageGroup;
    [SerializeField] private float startAngle;
    [SerializeField] private float lastAngle;

    void Start () {
        StageGroup = GameObject.Find ("StageGroup");
    }
    void Update () { }

    private void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            transform.localScale = new Vector3 (10, 2, 10);
            StageGroup.transform.parent = transform;
            float y = StageGroup.transform.rotation.eulerAngles.y;
            PlayerMove = other.GetComponent<PlayerMove> ();
            direction = PlayerMove.direction;

            if (direction > 0) {
                Debug.Log (y);

                if (startAngle <= y && y < lastAngle) {
                    PlayerMove.IsMoveFalse ();
                    transform.Rotate (new Vector3 (0, 5, 0));
                } else {
                    PlayerMove.IsMoveTrue ();
                }
            } else if (direction < 0) {
                if (startAngle + 1 < y && y < lastAngle + 1) {
                    PlayerMove.IsMoveFalse ();
                    transform.Rotate (new Vector3 (0, -5, 0));
                } else {
                    PlayerMove.IsMoveTrue ();
                }
            }
            GameObject.Find ("StageGroup").transform.parent = null;
        }
    }
    private void OnTriggerExit (Collider other) {
        transform.localScale = new Vector3 (0.1f, 2, 0.1f);
        PlayerMove.IsMoveTrue ();
    }
}