using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using System;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public GameObject playerControl;
    public GameObject watch;
    public GameObject logbook;
    public GameObject instruct;
    public string[] lines;
    public float textSpeed;
    private int dialogueLine;

    void Start()
    {
        textComp.text = string.Empty;
        logbook.SetActive(false);
        watch.SetActive(false);
        instruct.SetActive(false);
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (textComp.text == lines[dialogueLine])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[dialogueLine];
            }
        }
    }

    void StartDialogue()
    {
        playerControl.SetActive(false);
        dialogueLine = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[dialogueLine].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (dialogueLine < (lines.Length-1))
        {
            dialogueLine++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            playerControl.SetActive(true);
            logbook.SetActive(true);
            watch.SetActive(true);
            instruct.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
