using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isVisible;
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;
    public Image imageSlot;

    public string[] dialogLines;


    public int currentLine = 0;

    public static DialogManager instance;
    private bool justStarted;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (justStarted == false)
                {
                    if (currentLine < dialogLines.Length - 1)
                    {
                        currentLine += 1;
                        dialogText.text = dialogLines[currentLine];
                    }
                    else if (currentLine >= dialogLines.Length - 1)
                    {
                        isVisible = false;
                        dialogBox.SetActive(isVisible);
                        nameBox.SetActive(isVisible);
                        PlayerController.instance.canMove = true;
                    }
                }
                else
                {
                    justStarted = false;
                }
            }
        }
    }

    public void showDialog(string[] newLines, string nameString, bool isPerson, Sprite profilePic)
    {
        if (isVisible == false)
        {
            dialogLines = newLines;

            currentLine = 0;

            dialogText.text = dialogLines[0];
            dialogBox.SetActive(true);

            if (isPerson)
            {
                nameText.text = nameString;

                imageSlot.sprite = profilePic;
            }
            else
            {
                imageSlot.sprite = null;
            }

            nameBox.SetActive(isPerson);
            imageSlot.enabled = isPerson;

            justStarted = true;


            PlayerController.instance.canMove = false;
        }
    }

    public void hideDialog()
    {
        dialogBox.SetActive(false);
        nameBox.SetActive(false);
        isVisible = false;
        PlayerController.instance.canMove = true;
    }
}