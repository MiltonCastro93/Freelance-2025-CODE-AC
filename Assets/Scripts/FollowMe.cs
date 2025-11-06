using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMe : MonoBehaviour
{
    public float HeightMax = 5f;
    public float followSpeed = 5f;
    public Vector3 _diferencia = Vector3.zero;

    private void LateUpdate() {
        Vector3 targetPosition = transform.position + Vector3.up * HeightMax;
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition + _diferencia, followSpeed * Time.deltaTime);
    }

}
