using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCheck : MonoBehaviour {

    public static bool check;
    private CompleteGameMenu menu;

    // Use this for initialization
    void Start () {
        check = false;
        RightPosition.complete = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (RightPosition.complete == 15 && !check)
        {
            menu = gameObject.AddComponent<CompleteGameMenu>();
            menu.Open();
            check = true;
            StartGame.Disable();
        }
    }
}