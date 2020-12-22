using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDragMoving : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    public bool cameraDragging = true;

    public float outerDown = -3200f;
    public float outerUp = 3200f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float down = Screen.height * 0.2f;
        float up = Screen.height - (Screen.height * 0.2f);

        if (mousePosition.y < down)
        {
            cameraDragging = true;
        }
        else if (mousePosition.y > up)
        {
            cameraDragging = true;
        }






        if (cameraDragging)
        {

            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(0, -(pos.y * dragSpeed), 0);

            if (move.y > 0f)
            {
                if (this.transform.position.y < outerUp)
                {
                    transform.Translate(move, Space.World);
                }
            }
            else
            {
                if (this.transform.position.y > outerDown)
                {
                    transform.Translate(move, Space.World);
                }
            }
        }
    }
}
