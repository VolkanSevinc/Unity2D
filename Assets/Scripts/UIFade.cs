using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    // Start is called before the first frame update

    public static UIFade instance;

    public Image fadeScreen;
    public float fadeSpeed;

    private bool shouldFadeToBlack;
    private bool shouldFadeFromBlack;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var fadeScreenColor = fadeScreen.color;
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreenColor.r, fadeScreenColor.g, fadeScreenColor.b,
                Mathf.MoveTowards(fadeScreenColor.a, 1, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }
        else if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreenColor.r, fadeScreenColor.g, fadeScreenColor.b,
                Mathf.MoveTowards(fadeScreenColor.a, 0, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void fadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }


    public void fadeFromBlack()
    {
        fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 1);


        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
}