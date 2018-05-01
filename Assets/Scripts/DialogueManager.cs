using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager Instance { set; get; }

    public Text nameText;
    public Text dialogueText;

    //moe
    private bool dialogueIsStarted = false;

    private Queue <string> sentences;
    private Client client;

	void Start () {
        Instance = this;
        sentences = new Queue<string>();
        client = FindObjectOfType<Client>();

	}

    public void StartDialogue(Dialogue dialogue)
    {
        if (dialogueIsStarted == false)
        {

            dialogueIsStarted = true;

            Debug.Log("Send Start Dialogue");
            string msg = "CKLI|";
            msg += "Start";
            client.Send(msg);

            nameText.text = dialogue.name;

            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
        


    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if(sentences.Count != 3)
        {
            Debug.Log("Send DisplayNextSentence to clients on Continue button click");
            string msg = "CKLI|";
            msg += "Continue";
            client.Send(msg);

        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
	
    void EndDialogue()
    {
        Debug.Log("End of conversation. ");
        dialogueIsStarted = false;
    }

}
