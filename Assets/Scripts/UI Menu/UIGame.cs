using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour, IObserve
{
    private Scrollbar barLife;
    public TextMeshProUGUI points, texto;
    public GameObject menu;
    private float puntos, vida;
    public float WinnerPoints = 100;

    // Start is called before the first frame update
    void Start() {
        barLife = GetComponentInChildren<Scrollbar>();
        Arbitro arbitro = FindObjectOfType<Arbitro>();
        arbitro.RegisterObserver(this);
    }

    private void Update()
    {
        if(puntos >= WinnerPoints) {
            menu.SetActive(true);
            texto.text = "Ganaste";
        }
        if(vida <= 0) {
            menu.SetActive(true);
            texto.text = "Perdiste";
        }

    }

    public void Points(float p) {
        puntos = p;
        points.text = p.ToString();
    }

    public void Life(float l) {
        vida = l;
        barLife.size = l / 100;
    }
}
