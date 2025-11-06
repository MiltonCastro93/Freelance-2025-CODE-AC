using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class InEarth : Enemy {
    [SerializeField] int damage = 20, points;
    protected NavMeshAgent agent;
    [SerializeField] LayerMask MascaraPlayer;
    [SerializeField] protected float distanceMax = 2f;
    float distance = 0f;
    Transform player;
    protected Arbitro arbitro;
    protected bool isDead = false;
    public ObjectPool<GameObject> pool;

    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        player = FindObjectOfType<Player>().transform;
        arbitro = FindObjectOfType<Arbitro>();
    }

    // Update is called once per frame
    void Update() {
        if(life >= 1) {
            distance = Vector3.Distance(player.position, transform.position);
            move();
        }else if (!isDead) {
            isDead = true;
            arbitro.UpdatePoints(points);
            agent.enabled = false;
            m_Animator.SetBool("IsDead", true);
            Invoke("Desactivate", 1f);
        }


    }

    protected override void move() {
        if(agent.enabled == true) {
            if (distance >= distanceMax) {
                agent.SetDestination(player.position);
            }
            bool isMoving = agent.velocity.magnitude > 0.1f;
            m_Animator.SetBool("IsMove", isMoving);
            attack();
        }

    }

    protected virtual void attack() {
        if (Physics.CheckBox(transform.position + transform.forward, Vector3.one, transform.rotation, MascaraPlayer)) {
            coolDown += Time.deltaTime;
            coolDown = Mathf.Clamp(coolDown, 0f, timeMax);
            if (coolDown >= timeMax) {
                coolDown = 0f;
                player.GetComponent<IGenerateDamage>().GenerateDamage(damage);
            }
            m_Animator.SetBool("IsAttack", coolDown >= timeMax);
        }

    }

    private void Desactivate() {
        life = 100f;
        agent.enabled = true;
        isDead = false;
        pool.Release(gameObject);
        CancelInvoke("Desactivate");
    }


}
