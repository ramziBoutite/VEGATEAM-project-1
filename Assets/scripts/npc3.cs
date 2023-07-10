using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc3 : MonoBehaviour
{
    public GameObject DialoguePanel;
    public Text DialogueText;
    public string[] Dialogue;
    private int index;

    public GameObject contButton;
    public float WordSpeed;
    public bool playerIsClose;

    private Coroutine dialogueCoroutine;

    void Update()
    {
        if (playerIsClose && !DialoguePanel.activeInHierarchy)
        {
            DialoguePanel.SetActive(true);
            StartDialogue();
        }

        if (DialogueText.text == Dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void ZeroText()
    {
        DialogueText.text = "";
        index = 0;
        DialoguePanel.SetActive(false);
    }

    private void StartDialogue()
    {
        dialogueCoroutine = StartCoroutine(Typing());
    }

    IEnumerator Typing()
    {
        foreach (char letter in Dialogue[index].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(WordSpeed);
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if (index < Dialogue.Length - 1)
        {
            index++;
            DialogueText.text = "";
            dialogueCoroutine = StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            StopCoroutine(dialogueCoroutine);
            ZeroText();
        }
    }
}
