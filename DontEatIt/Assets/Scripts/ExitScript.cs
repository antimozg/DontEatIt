using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onExitClick() {
        Application.Quit();
    }
}
