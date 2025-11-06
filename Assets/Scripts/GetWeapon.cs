using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapon : MonoBehaviour, ISwitchAmmo {
    [SerializeField] private GameObject WeaponType;
    public int _ammo = 20, _ammoMax = 20, _backpackAmmo = 20;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void TypeWeapon(Vector3 localposition, Quaternion localRotation) {
        GameObject bullet = Instantiate(WeaponType, localposition, localRotation);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            WeaponCurrent weapon = other.GetComponentInChildren<WeaponCurrent>();
            if (weapon != null) {
                audioSource.Play();
                weapon.SetAttackType(this);
                weapon.Datapass(_ammo, _ammoMax, _backpackAmmo);
            }
        }
    }

}
