using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{

    public void CambiarScenes(int index) {
        SceneManager.LoadScene(index);
    }

    public void Restar(int index) {
        SceneManager.LoadScene(index);
        Arbitro.arbitro.resetPoints();
    }

}
