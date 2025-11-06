using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity 
{
    protected float _ejeX; //Entrada de Impud X/Z
    protected float _ejeZ;
    protected CharacterController _cC; //Character Controler
    protected Arbitro arbitro;

    // Start is called before the first frame update
    void Start() {
        _cC = GetComponent<CharacterController>();
        arbitro = FindObjectOfType<Arbitro>();
    }

    // Update is called once per frame
    void Update() {
        life = Mathf.Clamp(life, 0, 100);
        if (arbitro != null) {
            arbitro.UpdateLife(life);
        }

        if (life >= 1) {
            move();//Mientras que siga con vida seguira llamando a Move..
        } else {
            m_Animator.SetBool("IsDead", life == 0);
        }

    }

    protected override void move() {
        _ejeX = Input.GetAxis("Horizontal");
        _ejeZ = Input.GetAxis("Vertical");
        m_Animator.SetBool("IsMoving", _ejeX != 0 || _ejeZ != 0);
        Vector3 direction = new Vector3(_ejeX, 0f, _ejeZ) * speed;        
        _cC.SimpleMove(direction);
    }

    public override void GenerateDamage(int Damage) {
        life -= Damage;
    }

}
