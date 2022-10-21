using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialLoader : MonoBehaviour
{
   [SerializeField] private GameObject UIScreen;
   [SerializeField] private GameObject player;

    void Awake() 
    {
        if(UIFade.instance == null)
        {
            Instantiate(UIScreen);
        }
        if(PlayerController.instance == null)
        {
            Instantiate(player);
        }
    }

}
