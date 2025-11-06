using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCurrent : MonoBehaviour {
    private ISwitchAmmo switchAmmo;
    private int _ammo, _ammoMax, _backpackAmmo;
    private float _timeShoot = 0f;
    [SerializeField] private float Maxtime = 2f;
    [SerializeField] private AudioSource _audioSource;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if(switchAmmo != null) {
            action();
        }
    }

    public void SetAttackType(ISwitchAmmo newSwitch) {
        switchAmmo = newSwitch;
    }

    private void action() {
        bool autorecharge = _ammo <= 0;
        if (_ammo >= 1) {
            _timeShoot += Time.deltaTime;
            _timeShoot = Mathf.Clamp(_timeShoot, 0f, Maxtime);
            if (Input.GetButtonDown("Fire1") && _timeShoot >= Maxtime) {
                switchAmmo.TypeWeapon(transform.position, transform.rotation);
                _timeShoot = 0f;
                _ammo--;
                _audioSource.Play();
            }

        }

        if ((Input.GetKeyDown(KeyCode.R) || autorecharge) && _backpackAmmo >= 1) {
            int recharge = _ammoMax - _ammo; //Verifica cuantas balas disparaste
            _backpackAmmo -= recharge; //le descuenta cuantas balas me tengo que sacar de la mochila
            _ammo += recharge; //le paso la municion al cargador
        }

        if (_ammo <= 0 && _ammoMax <= 0 && _backpackAmmo <= 0) {
            switchAmmo = null;
        }

    }

    public void Datapass(int newAmmo, int newMax, int Back) {
        _ammo = newAmmo;
        _ammoMax = newMax;
        _backpackAmmo = Back;
    }

}
