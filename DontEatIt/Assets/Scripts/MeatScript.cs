using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeatScript : MonoBehaviour
{

    public GameObject player;
    public int bottom = -12;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < bottom)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Scores.deaths++;
            SceneManager.LoadScene(this.gameObject.scene.name);
        }
    }
}
