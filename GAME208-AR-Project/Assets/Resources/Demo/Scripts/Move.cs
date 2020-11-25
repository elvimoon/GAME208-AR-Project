using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Camera cam;
    private Touch touch;
    private float speedModifier;

    // Start is called before the first frame update
    void Start()
    {
        speedModifier = 0.001f;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier,
                transform.position.y, transform.position.z + touch.deltaPosition.y * speedModifier);
            }
        }
        */

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
            Plane plane = new Plane(Vector3.up, transform.position);
            float distance = 0;
            if (plane.Raycast(ray, out distance))
            {
                Vector3 pos = ray.GetPoint(distance);
            }
        }


    }
}
