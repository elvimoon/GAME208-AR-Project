using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator_Anim : MonoBehaviour
{

    public Animator indicator_anim;

    public void indicatorRotate()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            indicator_anim.SetTrigger("Rotate");
        }
        else if (rand == 1)
        {
            indicator_anim.SetTrigger("Rotate2");
        }
        else if (rand == 2)
        {
            indicator_anim.SetTrigger("Rotate3");
        }
    }

}
