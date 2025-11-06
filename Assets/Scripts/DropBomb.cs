using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    public bool resetBomb;
    bool LaunchBomb;
    private float coolDown;
    public float timeMax = 2;
    public GameObject BombPrefabs;
    private GameObject _currentBoom;

    // Update is called once per frame
    void Update() {
        if(_currentBoom == null) {
            _currentBoom = Instantiate(BombPrefabs, gameObject.transform);
            _currentBoom.GetComponent<Rigidbody>().useGravity = false;
            _currentBoom.transform.localPosition = Vector3.zero;
            LaunchBomb = false;
        }
        if(_currentBoom != null) {
            if (!LaunchBomb) {
                coolDown += Time.deltaTime;
                coolDown = Mathf.Clamp(coolDown, 0f, timeMax);
                if (coolDown >= timeMax) {
                    coolDown = 0f;
                    LaunchBomb = true;
                    _currentBoom.transform.parent = null;
                    _currentBoom.GetComponent<Rigidbody>().useGravity = true;
                }
            }

        }


        resetBomb = _currentBoom.GetComponent<ZoneDamage>().inTierra;
        _currentBoom = resetBomb ? null : _currentBoom;
    }


}
