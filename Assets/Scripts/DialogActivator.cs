using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    [SerializeField] private string[] lines;
    [SerializeField] private bool isCharacter = true;

    private bool _canActivate;

    void Update() 
    {
        if(_canActivate && Input.GetKeyDown(KeyCode.Space) && !DialogManager.instance.DialogBox.activeInHierarchy)
        {
            DialogManager.instance.ShowDialog(lines, isCharacter);
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
            _canActivate = true;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
            _canActivate = false;
    }
}
