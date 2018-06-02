using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{


    public Text sceneDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;
    public SimpleObjectPool decisionButtonObjectPool;
    public Transform decisionButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;

    private DataController dataController;
    private StoryData currentStoryData;
    private SceneData[] scenePool;

    private bool isGameActive;
    // private float timeRemaining;
    private int sceneIndex;
   //private int playerScore;
    private List<GameObject> decisionButtonGameObjects = new List<GameObject>();

    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentStoryData = dataController.GetCurrentStoryData();
        scenePool = currentStoryData.scenes;
        //timeRemaining = currentRoundData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();

       // playerScore = 0;
        sceneIndex = 0;

        ShowScene();
        isGameActive = true;

    }

    private void ShowScene()
    {
        RemoveDecisionButtons();
        SceneData sceneData = scenePool[sceneIndex];
        sceneDisplayText.text = sceneData.sceneText;

        for (int i = 0; i < sceneData.choices.Length; i++) 
        {
            GameObject decisionButtonGameObject = decisionButtonObjectPool.GetObject();
            decisionButtonGameObjects.Add(decisionButtonGameObject);
            decisionButtonGameObject.transform.SetParent(decisionButtonParent);

            DecisionButton decisionButton = decisionButtonGameObject.GetComponent<DecisionButton>();
            decisionButton.Setup(sceneData.choices[i]);
        }
    }

    private void RemoveDecisionButtons()
    {
        while (decisionButtonGameObjects.Count > 0) 
        {
            decisionButtonObjectPool.ReturnObject(decisionButtonGameObjects[0]);
            decisionButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        /*
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
        }

        if (questionPool.Length & gt; questionIndex + 1) {
            questionIndex++;
            ShowScene();
        } else 
        {
            EndRound();
        }
        */
    }

    public void EndRound()
    {
        isGameActive = false;

        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    private void UpdateTimeRemainingDisplay()
    {
        //timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining & lt;= 0f)
            {
                EndRound();
            }

        }
        */
    }
}