using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float boundary = 8.5f;
    private Vector3 playerPosition;
    public float playerSpeed = 0.5f;    //Скорость платформы
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition.x += Input.GetAxis("Horizontal") * playerSpeed;

        // выход из игры
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // обновим позицию платформы!
        
        if (playerPosition.x > -boundary)
        {
            transform.position = playerPosition;
        }
        if (playerPosition.x < boundary)
        {
            transform.position = playerPosition;
        }
        
    }
}
