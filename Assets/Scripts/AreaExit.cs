using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string areaTransitionName;
    [SerializeField] private AreaEntrance entrance;

    private void Start() 
    {
        entrance.TransitionName = areaTransitionName;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            PlayerController.instance.AreaTransitionName = areaTransitionName;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
