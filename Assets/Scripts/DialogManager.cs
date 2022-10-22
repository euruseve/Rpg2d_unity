using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public GameObject DialogBox { get => dialogBox;}

    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject nameBox;
    [SerializeField] private Text dialogText;
    [SerializeField] private Text nameText;

    [SerializeField] private string[] dialogLines;

    private int _currentLine;
    private bool _justStarted;

    void Awake() 
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        //dialogText.text = dialogLines[_currentLine];
    }

    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if(!_justStarted)
                {   
                    _currentLine++;

                    if (_currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        PlayerController.instance.CanMove = true;
                    } 
                    else
                    {
                        CheckAName();
                        dialogText.text = dialogLines[_currentLine];
                    }
                
                }
                else
                {
                    _justStarted = false;
                }
            }
        }
    }

    public void ShowDialog(string[] lines, bool isCharacter)
    {
        _justStarted = true;
        dialogLines = lines;

        _currentLine = 0;

        CheckAName();

        dialogText.text = dialogLines[_currentLine];

        dialogBox.SetActive(true);

        nameBox.SetActive(isCharacter);

        PlayerController.instance.CanMove = false;
    }

    public void CheckAName()
    { 
        if(dialogLines[_currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[_currentLine].Replace("n-", "");
            _currentLine++;
        }
    }
}
