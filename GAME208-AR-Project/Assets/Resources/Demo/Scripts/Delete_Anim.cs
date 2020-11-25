using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Anim : MonoBehaviour
{
    public Animator delete_anim;

    public void deleteRotate()
    {
        delete_anim.SetTrigger("Shake");
    }
}
