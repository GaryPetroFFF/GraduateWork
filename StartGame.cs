using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class StartGame : MonoBehaviour {

    private static GameObject[] objects;
    private Vector2[] positions = 
        {new Vector2(-4, 2), new Vector2(0, 2), new Vector2(4, 2),
         new Vector2(-4, 0), new Vector2(0, 0), new Vector2(4, 0),
         new Vector2(-4, -2), new Vector2(0, -2), new Vector2(4, -2),
         new Vector2(-4, -4), new Vector2(0, -4), new Vector2(4, -4),
         new Vector2(-4, -6), new Vector2(0, -6), new Vector2(4, -6)};
    private System.Random rand = new System.Random();

	// Use this for initialization
	void Start () {
        objects = GameObject.FindGameObjectsWithTag("Tile");
        var indexes = Enumerable.Range(0, 15).ToList();
        foreach(GameObject obj in objects)
        {
            int pos = rand.Next(0, indexes.Count);
            obj.transform.position = positions[indexes[pos]];
            indexes.RemoveAt(pos);
            obj.SetActive(true);
            obj.GetComponent<Collider2D>().enabled = true;
        }
	}
	
	public static void Disable()
    {
        objects = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject obj in objects)
        {
            obj.GetComponent<Collider2D>().enabled = false;
        }
    }
}
