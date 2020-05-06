using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteGameMenu : MonoBehaviour
{
    // 200x300 px window will apear in the center of the screen.
    private Rect windowRect = new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 200, 100);
    // Only show it if needed.
    private bool show = false;

    void OnGUI()
    {
        if (show)
            windowRect = GUI.Window(0, windowRect, DialogWindow, "You won!");
    }

    // This is the actual window.
    void DialogWindow(int windowID)
    {
        float y = 20;
        GUI.Label(new Rect(5, y, windowRect.width, 20), "Again?");

        if (GUI.Button(new Rect(5, y + 25, windowRect.width - 10, 20), "New game"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EasyGameplay");
            show = false;
        }

        if (GUI.Button(new Rect(5, y + 50, windowRect.width - 10, 20), "Exit"))
        {
            Application.Quit();
            VictoryCheck.check = false;
            show = false;
        }
    }

    // To open the dialogue from outside of the script.
    public void Open()
    {
        show = true;
    }
}

