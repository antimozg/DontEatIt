using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreOutput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text scoring = GetComponent<Text>();
        scoring.transform.position = new Vector3(Screen.currentResolution.width - 400.0f, Screen.currentResolution.height - 50.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Text scoring = GetComponent<Text>();
        Debug.Log(Scores.score);
        scoring.text = "Score: "+ Scores.score;
    }
}
