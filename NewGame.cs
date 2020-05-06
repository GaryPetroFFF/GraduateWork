using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour {

    void OnMouseDown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("DifficultyMenu");
    }
}
