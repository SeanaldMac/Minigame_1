using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public Text count;
    public Text win;
    private Rigidbody rb;
    private int counter;

    public bool gameOver = false;
    public Text timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        counter = 0;
        count.text = "Count: " + counter.ToString();
       win.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        { //If you press R
            SceneManager.LoadScene("ObstacleMinigame"); //reload scene to restart game
        }

        if(!gameOver && transform.position.y <= -40)
            SceneManager.LoadScene("ObstacleMinigame"); //reload scene to restart game if out of bounds

        if (!gameOver)
            UpdateTimerUI();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            counter ++;
            SetCount();
        }
    }


    void SetCount()
    {
        count.text = "Count: " + counter.ToString();
        if (counter >= 5)
        {
            win.text = "GAME OVER";
            gameOver = true;
        }
    }


    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }


}
