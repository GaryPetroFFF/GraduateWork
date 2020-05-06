using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private SpriteRenderer sp;
    private float x_orig, y_orig;
    private bool dragging = false;
    private float distance;
    private bool check = false;

    void OnMouseDown()
    {
        if (!dragging)
        {
            x_orig = transform.position.x;
            y_orig = transform.position.y;
            distance = Vector2.Distance(transform.position, Camera.main.transform.position);
            sp = this.GetComponent<SpriteRenderer>();
            sp.sortingOrder = 5;
            dragging = true;
        }
    }

    void OnMouseUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 rayPoint = ray.GetPoint(distance);
        if (rayPoint.x % 2 != 0)
        {
            if (rayPoint.x % 2 > 1)
            {
                rayPoint.Set(rayPoint.x + (2 - rayPoint.x % 2), rayPoint.y);
            }
            if (rayPoint.x % 2 >= -1 && rayPoint.x % 2 <= 1)
            {
                rayPoint.Set(rayPoint.x - (rayPoint.x % 2), rayPoint.y);
            }
            if (rayPoint.x % 2 < -1)
            {
                rayPoint.Set(rayPoint.x - (2 + rayPoint.x % 2), rayPoint.y);
            }

        }
        if (rayPoint.y % 2 != 0)
        {
            if (rayPoint.y % 2 > 1)
            {
                rayPoint.Set(rayPoint.x, rayPoint.y + (2 - rayPoint.y % 2));
            }
            if (rayPoint.y % 2 >= -1 && rayPoint.y % 2 <= 1)
            {
                rayPoint.Set(rayPoint.x, rayPoint.y - (rayPoint.y % 2));
            }
            if (rayPoint.y % 2 < -1)
            {
                rayPoint.Set(rayPoint.x, rayPoint.y - (2 + rayPoint.y % 2));
            }

        }
        RaycastHit2D hit;
        this.gameObject.layer = 2;
        if (rayPoint.x < -4 || rayPoint.x > 4 || rayPoint.y < -6 || rayPoint.y > 2 ||
            Mathf.Abs(rayPoint.x - x_orig) > 2 || Mathf.Abs(rayPoint.y - y_orig) > 2 || 
            Mathf.Abs(rayPoint.y - y_orig) == Mathf.Abs(rayPoint.x - x_orig))
            rayPoint.Set(x_orig, y_orig);
        else
        {
            if (hit = Physics2D.Raycast(rayPoint, Vector3.back))
            {
                if (hit.collider.name == "Blocked" || hit.collider.name == "Blue" ||
                    hit.collider.name == "Red" || hit.collider.name == "Green")
                    rayPoint.Set(x_orig, y_orig);
            }
        }
        this.gameObject.layer = 0;
        transform.position = rayPoint;
        sp = this.GetComponent<SpriteRenderer>();
        sp.sortingOrder = 3;
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
        if (this.name == "Red" && this.transform.position.x == -4 && !check)
        {
            RightPosition.complete++;
            check = true;
        }
        if (this.name == "Green" && this.transform.position.x == 0 && !check)
        {
            RightPosition.complete++;
            check = true;
        }
        if (this.name == "Blue" && this.transform.position.x == 4 && !check)
        {
            RightPosition.complete++;
            check = true;
        }
        if (this.name == "Red" && this.transform.position.x != -4 && check)
        {
            RightPosition.complete--;
            check = false;
        }
        if (this.name == "Green" && this.transform.position.x != 0 && check)
        {
            RightPosition.complete--;
            check = false;
        }
        if (this.name == "Blue" && this.transform.position.x != 4 && check)
        {
            RightPosition.complete--;
            check = false;
        }
    }
}

public static class RightPosition
{
    public static int complete = 0;
}