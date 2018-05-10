using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

    public StoryData[] allStoriesData;

    // Use this for initialization
    void Start() {

        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Menu");

    }

    public StoryData GetCurrentStoryData()
        {
            return allStoriesData[0];
        }
	
	// Update is called once per frame
	void Update () {
		
	}
}
