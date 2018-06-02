using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionButton : MonoBehaviour {

    public Text decisionText;

    private ChoicesData choicesData;

	// Use this for initialization
	void Start () {
		
	}
	
    public void Setup(ChoicesData data)
    {
        choicesData = data;

        decisionText.text = choicesData.optionText;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
