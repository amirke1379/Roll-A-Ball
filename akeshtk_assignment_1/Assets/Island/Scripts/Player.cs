using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
  
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private Rigidbody rb;
    private int score;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        setCountText();
        winTextObject.SetActive(false);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    void setCountText()
    {
        countText.text = "Score: " + score.ToString();
        if (score >= 17)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("OnePointObject"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            setCountText();  
        }
        else if (other.gameObject.CompareTag("TwoPointObject"))
        {
            other.gameObject.SetActive(false);
            score += 2;
            setCountText();
        }
        else if (other.gameObject.CompareTag("Chest"))
        {
            other.gameObject.SetActive(false);
            score += 5;
            setCountText();
        }
        if (score == 17)
        {
            StartCoroutine(Wait());
        }

    }
   
    IEnumerator Wait()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
}
