using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Entity : MonoBehaviour, IGenerateDamage
{
    protected Animator m_Animator;
    [SerializeField] protected float life = 10;
    [SerializeField] protected float speed = 1;

    private void Awake() {
        m_Animator = GetComponentInChildren<Animator>();
    }

    public abstract void GenerateDamage(int D); // << IGenerateDamage
    protected virtual void move() {
        Debug.Log("Caminar");
    }


}
