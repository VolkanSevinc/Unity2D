﻿using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    // Start is called before the first frame update

    public string[] lines;

    private bool canActivate;

    public string characterName;

    public bool isPerson = true;

    public Sprite profilePic;

    private bool isOwnerOfCurrent = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (canActivate && Input.GetButtonDown("Fire1") &&
            DialogManager.instance.dialogBox.activeInHierarchy == false && lines.Length != 0)
        {
            DialogManager.instance.showDialog(lines, characterName, isPerson, profilePic);
            isOwnerOfCurrent = true;
        }
        else if (canActivate == false && isOwnerOfCurrent)
        {
            DialogManager.instance.hideDialog();
            isOwnerOfCurrent = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = false;
        }
    }
}