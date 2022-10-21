using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string areaTransitionName;
    [SerializeField] private AreaEntrance entrance;
    [SerializeField] private float waitToLoad = 10;

    private bool _shouldLoadAfterFade;

    private void Start() 
    {
        entrance.TransitionName = areaTransitionName;
    }

    void Update() 
    {
        if(_shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                _shouldLoadAfterFade = false;
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            PlayerController.instance.AreaTransitionName = areaTransitionName;

            _shouldLoadAfterFade = true;
            UIFade.instance.FadeToBlack();

            //StartCoroutine("LoadNextScene");
        }
    }


    // private IEnumerator LoadNextScene()
    // {
    //     UIFade.instance.FadeToBlack();

    //     PlayerController.instance.AreaTransitionName = areaTransitionName;
    //     yield return new WaitForSeconds(waitToLoad);

    //     SceneManager.LoadScene(sceneToLoad);
    //     UIFade.instance.FadeFromBlack();
    // }

}
