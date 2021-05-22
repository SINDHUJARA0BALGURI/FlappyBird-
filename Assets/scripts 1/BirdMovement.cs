using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour
{
     private Rigidbody2D rb;
    public float speed;
    public GameObject replayButton;
    public GameObject backButton;
    public AudioClip jumpsound;
    private AudioSource playerAudio;
    public AudioClip crashsound;


    public Score scoreText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * speed;
          
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe1"))
        {
            playerAudio.PlayOneShot(crashsound, 1.0f);
            Time.timeScale = 0;
            replayButton.SetActive(true);
            backButton.SetActive(true);
        }
    }
    public void Replaygame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
           // print("Score Up!");
            scoreText.ScoreUp();
            playerAudio.PlayOneShot(jumpsound, 1.0f);
        }
    }
    
   

}
