using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAir : Enemy {
    [SerializeField] LayerMask dibujar;
    private Vector3 startPos, endPos;
    private LineRenderer lineRenderer;
    public GameObject RefstartPos, RefendPos, zoneDamage;
    public bool finish = false;

    private void Start() {
        speed = 2f;
        startPos = RefstartPos.transform.position;
        endPos = RefendPos.transform.position;
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update() {
        lineRenderer.SetPosition(0,transform.position);
        float distance = endPos.x - transform.position.x;

        if(distance >= 0.01f) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        } else {
            finish = true;
        }

        if (finish) {
            coolDown += Time.deltaTime;
            coolDown = Mathf.Clamp(coolDown, 0, timeMax);
            if (coolDown >= timeMax) {
                coolDown = 0f;
                finish = false;
                startPos.z = Random.Range(-23f, 23f);
                endPos.z = Random.Range(-23f, 23f);
                transform.position = startPos;
            }
        }

        lineRenderer.enabled = !finish;
        zoneDamage.gameObject.SetActive(!finish);
    }

    private void FixedUpdate() {
        if (lineRenderer.enabled) {
            RaycastHit hit;
            if(Physics.Raycast(transform.position,Vector3.down,out hit, Mathf.Infinity,dibujar)) {
                lineRenderer.SetPosition(1, hit.point);
                zoneDamage.transform.position = hit.point;
            }
        
        
        }

    }


}
