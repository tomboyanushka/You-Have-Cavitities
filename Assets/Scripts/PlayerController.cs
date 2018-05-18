using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{

    
    public LayerMask mask;
    Camera cam;
    PlayerMovement move;

    public Interact focus;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
        move = GetComponent<PlayerMovement>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                //Debug.Log("We hit" + hit.collider.name + " " + hit.point);

                move.MoveToPoint(hit.point);

                RemoveFocus();
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interact interact = hit.collider.GetComponent<Interact>();
                if (interact != null)
                {
                   
                    SetFocus(interact);
                }
            }
        }
    }
    void SetFocus(Interact currentFocus)
    {
        focus = currentFocus;
        move.FollowTarget(currentFocus);
    }

    void RemoveFocus()
    {

        focus = null;
        move.StopFollowingTarget();
    }

  


}


