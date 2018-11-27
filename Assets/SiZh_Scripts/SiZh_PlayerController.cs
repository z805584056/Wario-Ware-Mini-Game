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
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        count = 0;
        setCountText();
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
    }

    void setCountText()
    {
        countText.text = "Points: " + count.ToString();
    }

}
