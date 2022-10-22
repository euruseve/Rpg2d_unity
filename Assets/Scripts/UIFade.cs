using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade instance;

    [SerializeField] private Image fadeScreen;
    [SerializeField] float fadeSpeed = 1;

    private bool _shouldFadeToBlack;
    private bool _shouldFadeFromBlack;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(_shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, 
                                fadeScreen.color.g, 
                                fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1, fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 1)
            {
                _shouldFadeToBlack = false;
            }
        }
        if(_shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, 
                                fadeScreen.color.g, 
                                fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0, fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 1)
            {
                _shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        _shouldFadeToBlack = true;
        _shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        _shouldFadeFromBlack = true;
        _shouldFadeToBlack = false;
    }
}
