using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using NUnit.Framework;
using System;
using UnityEngine.Rendering;

public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialogueData dialogueData;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText, nameText;
    public Image portrait;
    public GameObject playerControl, watch, logbook, player;
    private Animator animator;

    private int dialogueLine;
    private bool typing, dialogueActive;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    public bool CanInteract()
    {
        return !dialogueActive;
    }
    
    public void Interact()
    {
        if (dialogueData == null || (playerControl.activeSelf == false && !dialogueActive))
        {
            return;
        }

        if (dialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    /*void Update()
    {
        Vector2 directionToPlayer = (Vector2)player.transform.localPosition - (Vector2)transform.localPosition;
        String trig = "";
        if (Mathf.Abs(directionToPlayer.x) > Mathf.Abs(directionToPlayer.y))
        {
            if (directionToPlayer.x > 0 && animator.GetBool("FaceRight") == false)
            {
                trig = "FaceRight";
                
                animator.SetBool("switch", true);
                
                animator.ResetTrigger("FaceUp");
                animator.ResetTrigger("FaceLeft");
                animator.ResetTrigger("FaceDown");
            }
            else if (directionToPlayer.x <= 0 && animator.GetBool("FaceLeft") == false)
            {
                trig = "FaceLeft";
                
                animator.SetBool("switch", true);
                //animator.SetTrigger("FaceLeft");
                animator.ResetTrigger("FaceUp");
                animator.ResetTrigger("FaceRight");
                animator.ResetTrigger("FaceDown");
            }
        }
        else
        {
            if (directionToPlayer.y > 0 && animator.GetBool("FaceUp") == false)
            {
                trig = "FaceUp";
                
                animator.SetBool("switch", true);
                ///animator.SetTrigger("FaceUp");
                animator.ResetTrigger("FaceLeft");
                animator.ResetTrigger("FaceRight");
                animator.ResetTrigger("FaceDown");
            }
            else if (directionToPlayer.y <= 0 && animator.GetBool("FaceDown") == false)
            {
                trig = "FaceDown";
                animator.SetBool("switch", true);
                
                animator.ResetTrigger("FaceUp");
                animator.ResetTrigger("FaceRight");
                animator.ResetTrigger("FaceLeft");
            }
        }
        if (trig != "")
        {
            animator.SetTrigger(trig);
        }
        
    }*/
    
    void StartDialogue()
    {
        dialogueText.text = string.Empty;
        dialoguePanel.SetActive(true);
        playerControl.SetActive(false);
        dialogueActive = true;
        dialogueLine = 0;
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (typing)
        {
            StopAllCoroutines();
            dialogueText.text = dialogueData.dialogueLines[dialogueLine];
            typing = false;
        }
        else if (dialogueLine < (dialogueData.dialogueLines.Length)-1) 
        {
            dialogueLine++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        typing = true;
        foreach (char c in dialogueData.dialogueLines[dialogueLine])
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }
        typing = false;
    }
   
    public void EndDialogue()
    {
        StopAllCoroutines();
        dialogueActive = false;
        dialogueText.text = string.Empty;
        dialoguePanel.SetActive(false);
        watch.SetActive(true);
        logbook.SetActive(true);
        playerControl.SetActive(true);
    }

}
