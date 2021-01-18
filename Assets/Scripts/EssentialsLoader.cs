using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UIScreen;
    public GameObject player;
    public DialogManager dialogManager;

    void Start()
    {
        if (UIFade.instance == null)
        {
            UIFade clone = Instantiate(UIScreen).GetComponent<UIFade>();
            UIFade.instance = clone;
        }

        if (dialogManager == null)
        {
            DialogManager clone = Instantiate(dialogManager).GetComponent<DialogManager>();
            DialogManager.instance = clone;
        }

        if (PlayerController.instance == null)
        {
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}