using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDamage : MonoBehaviour
{
    public bool inTierra = false;
    public int _damage;
    SphereCollider _zoneDanger;
    private AudioSource _audioSource;
    [SerializeField] AudioClip[] _audioClip = new AudioClip[2];

    private void Start() {
        _zoneDanger = GetComponent<SphereCollider>();
        _zoneDanger.enabled = false;

        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip[0];
        _audioSource.Play();
    }

    private void OnCollisionEnter(Collision collision) {
        _audioSource.clip = _audioClip[1];
        _audioSource.Play();
        if (collision.collider != null) {
            _zoneDanger.enabled = true;
            Invoke("restart", 2f);
        }

    }

    private void OnTriggerStay(Collider other) {
        IGenerateDamage damage = other.GetComponent<IGenerateDamage>();
        if (damage != null) {
            damage.GenerateDamage(_damage);
            _zoneDanger.enabled = false;
        }
    }

    private void restart() {
        inTierra = true;
        if (!_audioSource.isPlaying) {

        }
        CancelInvoke("restart");
        Destroy(gameObject);
    }

}
