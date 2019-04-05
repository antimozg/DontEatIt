using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallScript : MonoBehaviour
{

    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    private float dX = 0;
    private float dY = 0;
    private float lastX = 0;
    private float lastY = 0;
    private Rigidbody2D rb;
    public float bottom = -10.0f;
    public float speedMultipier = 10.0f;
    // GameObject
    public GameObject playerObject;

    // используйте этот метод для инициализации
    void Start()
    {

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
                // применим силу
                dY = 1.0f;
                if (dX == 0)
                {
                    dX = 0.01f; 
                }
                rb.AddForce(new Vector2(dX*10, dY*10), ForceMode2D.Impulse);
                // зададим активное состояние
                ballIsActive = !ballIsActive;
            }

            if (!ballIsActive && playerObject != null)
            {
                /*
                // задаем новую позицию шарика
                ballPosition.x = playerObject.transform.position.x;

                // устанавливаем позицию шара
                transform.position = ballPosition;
                */
            }


        }

        // проверка падения шара
        if (ballIsActive && transform.position.y < bottom)
        {
            Scores.deaths++;
            SceneManager.LoadScene(this.gameObject.scene.name);
        }
        if (lastX == 0 && lastY == 0)
        {
            lastX = this.gameObject.transform.position.x;
            lastY = this.gameObject.transform.position.y;

        } else
        {
            dX = lastX - this.gameObject.transform.position.x;
            dY = lastY - this.gameObject.transform.position.y;
            lastX = this.gameObject.transform.position.x;
            lastY = this.gameObject.transform.position.y;
        }

        float speed = Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y); //Вычисляем скорость мяча
        if (speed < speedMultipier) //Если скорость меньше заданной, то увеличиваем
        {
            rb.AddForce(new Vector2(-dX, -dY), ForceMode2D.Impulse);
        }
    }
}
