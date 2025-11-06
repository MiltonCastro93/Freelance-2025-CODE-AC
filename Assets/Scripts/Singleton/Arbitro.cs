using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbitro : MonoBehaviour
{
    private static Arbitro _arbitro;
    public static Arbitro arbitro => _arbitro;

    private List<IObserve> observes = new List<IObserve>();
    private float _score, _life;

    private void Awake() {
        if(_arbitro == null) {
            _arbitro = this;
            DontDestroyOnLoad(this);
        } else {
            Destroy(gameObject);
        }
    }

    public void RegisterObserver(IObserve newObservador) {
        if (!observes.Contains(newObservador)) {
            observes.Add(newObservador);
        }
    }

    public void UnregisterObserver(IObserve FindObserver) {
        if (observes.Contains(FindObserver)) {
            observes.Remove(FindObserver);
        }
    }

    public void UpdatePoints(float points) {
        _score += points;
        NotifyUI();
    }

    public void UpdateLife(float life) {
        _life = Mathf.Clamp(life, 0.0f, 100.0f);
        NotifyUI();
    }

    private void NotifyUI() {
        foreach(IObserve observador in observes) {
            observador.Points(_score);
            observador.Life(_life);
        }
    }

    public void resetPoints() {
        _score = 0.0f;
    }

}
