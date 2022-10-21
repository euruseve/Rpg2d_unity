using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string TransitionName { get; set; }

    void Start()
    {
        if(TransitionName == PlayerController.instance.AreaTransitionName)
        {
            PlayerController.instance.transform.position = this.transform.position;
        }
    }

}
