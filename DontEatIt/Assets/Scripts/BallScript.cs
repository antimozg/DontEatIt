using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallScript : MonoBehaviour
{

    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    private Rigidbody2D rb;
    // GameObject
    public GameObject playerObject;

    // используйте этот метод для инициализации
    void Start()
    {
        // создаем силу
        ballInitialForce = new Vector2(100.0f, 300.0f);

        // переводим в неактивное состояние
        ballIsActive = false;
        rb = GetComponent<Rigidbody2D>();
        // запоминаем положение
        ballPosition = transform.position;
    }

    void Update()
    {
        if (!ballIsActive)
        {
            ballPosition.x = playerObject.transform.position.x;
            transform.position = ballPosition;
        }
        // проверка нажатия на пробел
        if (Input.GetButtonDown("Jump") == true)
        {
            // проверка состояния
            if (!ballIsActive)
            {
                // сброс всех сил
                rb.isKinematic = false;
                // применим силу
                rb.AddForce(ballInitialForce);
                // зададим активное состояние
                ballIsActive = !ballIsActive;
            }

            if (!ballIsActive && playerObject != null)
            {
                // задаем новую позицию шарика
                ballPosition.x = playerObject.transform.position.x;

                // устанавливаем позицию шара
                transform.position = ballPosition;
            }


        }

        // проверка падения шара
        if (ballIsActive && transform.position.y < -6)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
