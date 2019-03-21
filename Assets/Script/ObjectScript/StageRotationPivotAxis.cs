using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRotationPivotAxis : MonoBehaviour {
    private float direction;
    private PlayerMove PlayerMove;
    private GameObject StageGroup;
    [SerializeField] private GameObject Pivot;
    [SerializeField] private float startAngle;
    [SerializeField] private float lastAngle;

    void Start () {
        StageGroup = GameObject.Find ("StageGroup");
        PlayerMove = GameObject.Find ("chr_robot").GetComponent<PlayerMove> ();
    }
    void Update () { }

    private void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            transform.localScale = new Vector3 (35, 3, 35);
            transform.parent = null;
            StageGroup.transform.parent = transform;
            float y = StageGroup.transform.rotation.eulerAngles.y;
            direction = PlayerMove.direction;
            if (direction > 0) {
                if (startAngle <= y && y < lastAngle) {
                    PlayerMove.IsMoveFalse ();
                    transform.Rotate (new Vector3 (0, 1, 0));
                } else {
                    transform.rotation = Quaternion.Euler (0, lastAngle, 0);
                    PlayerMove.IsMoveTrue ();
                    StageGroup.transform.parent = null;
                    transform.parent = StageGroup.transform.parent;
                    transform.localScale = new Vector3 (35, 3, 35);
                }
            } else if (direction < 0) {
                if (startAngle + 1 < y && y <= lastAngle + 1) {
                    PlayerMove.IsMoveFalse ();
                    transform.Rotate (new Vector3 (0, -1, 0));
                } else {
                    transform.rotation = Quaternion.Euler (0, startAngle, 0);
                    PlayerMove.IsMoveTrue ();
                    StageGroup.transform.parent = null;
                    transform.parent = StageGroup.transform;
                    transform.localScale = new Vector3 (35, 3, 35);
                }
            }

        }
    }
}
