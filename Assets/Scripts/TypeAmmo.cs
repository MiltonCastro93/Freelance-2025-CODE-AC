using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TypeAmmo : MonoBehaviour
{
    public int _damage = 10;// (10 = pistola; 25 = RPG)
    public float speed = 2f;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision) {
        IGenerateDamage damage = collision.gameObject.GetComponent<IGenerateDamage>();
        if (damage != null) {
            damage.GenerateDamage(_damage);
        }
        Destroy(gameObject);
    }

}
