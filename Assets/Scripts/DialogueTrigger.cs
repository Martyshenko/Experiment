using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    //moe
    public static DialogueTrigger Instance { set; get; }

    public Dialogue dialogue;

    //moe 
    private void Start()
    {
        Instance = this;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
