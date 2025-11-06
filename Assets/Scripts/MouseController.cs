using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
    private GameObject _player;
    public LayerMask LayerMask;

    // Start is called before the first frame update
    void Start() {
        _player = gameObject;
    }

    private void FixedUpdate() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit, Mathf.Infinity, LayerMask)) {
            Vector3 direction = hit.point - transform.position;
            direction.y = 0f;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        Camera.main.gameObject.transform.LookAt(transform.position);
    }

}
