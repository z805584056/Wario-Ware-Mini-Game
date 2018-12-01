using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SiZh_PlayerController : MonoBehaviour {
    public Vector2 velocity;
    private bool walk, walk_left, walk_right;
    private AudioSource audioSource;
    public AudioClip eatClip;
    private int count;
    public Text countText;
    public Text winText;
    public Text loseText;
    public Text timerText;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        count = 0;
        setCountText();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update () {
        CheckPlayerInput();
        UpdatePlayerPosition();
	}

    void UpdatePlayerPosition()
    {
        Vector3 pos = transform.localPosition;
        Vector3 scale = transform.localScale;
        if (walk)
        {
            if (walk_left)
            {
                pos.x -= velocity.x * Time.deltaTime;
                scale.x = -1;
            }
            if (walk_right)
            {
                pos.x += velocity.x * Time.deltaTime;
                scale.x = 1;
            }
        }
        transform.localPosition = pos;
        transform.localScale = scale;
    }
    void CheckPlayerInput()
    {
        bool input_left = Input.GetKey(KeyCode.LeftArrow);
        bool input_right = Input.GetKey(KeyCode.RightArrow);

        walk = input_left || input_right;
        walk_left = input_left && !input_right;
        walk_right = input_right && !input_left;
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(eatClip, 4f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Donut"))
        {

            Destroy(other.gameObject);

            PlaySound();

            count = count + 5;

            setCountText();
        }
        else if (other.gameObject.CompareTag("Rock"))
        {
            loseText.text = "You die!";
            //  StartCoroutine(ByeAfterDelay(2));
        }
    }

    void setCountText()
    {
        countText.text = "Points: " + count.ToString();
        if (count >= 10)
        {
            winText.text = "You win!";
            //GameLoader.AddScore(count);
            //  StartCoroutine(ByeAfterDelay(2));
        }

    }

    IEnumerator Timer()
    {
        timerText.text = "Dodge and catch donuts, you have 10 seconds";
        yield return new WaitForSeconds(1);
        timerText.text = "Dodge and catch donuts, you have 9 seconds";
        yield return new WaitForSeconds(1);
        timerText.text = "Dodge and catch donuts, you have 8 seconds";
        yield return new WaitForSeconds(1);
        timerText.text = "Dodge and catch donuts, you have 7 seconds";
        yield return new WaitForSeconds(1);
        timerText.text = "Dodge and catch donuts, you have 6 seconds";
        yield return new WaitForSeconds(1);
        timerText.text = "Dodge and catch donuts, you have 5 seconds";
        yield return new WaitForSeconds(1);
        timerText.text = "Dodge and catch donuts, you have 4 seconds";
        yield return new WaitForSeconds(1);
        timerText.text = "Dodge and catch donuts, you have 3 seconds";
        yield return new WaitForSeconds(1);
        timerText.text = "Dodge and catch donuts, you have 2 seconds";
        yield return new WaitForSeconds(1);
        timerText.text = "Dodge and catch donuts, you have 1 seconds";
        yield return new WaitForSeconds(1);
        timerText.text = "Time is over";
        //GameLoader.AddScore(count);
        //  StartCoroutine(ByeAfterDelay(2));
        if (count < 10)
        {
            loseText.text = "You lose!";
        }
    }

  /*  IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        GameLoader.gameOn = false;
    }
*/
}
