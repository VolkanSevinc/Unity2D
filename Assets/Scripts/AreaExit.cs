using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    // Start is called before the first frame update

    public string sceneToLoad;
    public string targetPoint;
    public string receivePoint;
    public Transform entranceTransform;

    public float waitToLoad = 1f;
    private float waitToLoadNewScene;
    private bool shouldWaitToLoad;
    private bool shouldWaitToLoadNewScene;

    void Start()
    {
        waitToLoadNewScene = waitToLoad;

        if (receivePoint.Equals(PlayerController.instance.areaTransitionName))
        {
            shouldWaitToLoadNewScene = true;

            UIFade.instance.fadeFromBlack();

            PlayerController.instance.transform.position = new Vector3(entranceTransform.position.x,
                PlayerController.instance.transform.position.y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldWaitToLoad == true)
        {
            waitToLoad -= Time.deltaTime;

            if (waitToLoad <= 0)
            {
                shouldWaitToLoad = false;
                SceneManager.LoadScene(sceneToLoad);
            }
        }

        if (shouldWaitToLoadNewScene == true)
        {
            waitToLoadNewScene -= Time.deltaTime;

            if (waitToLoadNewScene <= 0)
            {
                shouldWaitToLoadNewScene = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldWaitToLoad = true;
            UIFade.instance.fadeToBlack();

            PlayerController.instance.areaTransitionName = targetPoint;
        }
    }
}