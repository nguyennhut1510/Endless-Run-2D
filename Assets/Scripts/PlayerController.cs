using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float runSpeed;
    private int JumpCount = 0;
    private bool canJump = true;
    Animator anim;
    public bool isGameOver = false;
    public GameObject GameOverPanel,scoreText;
    public TextMeshProUGUI FinalScoreText, HighScoreText;
    private AudioSource audioSource;
    public AudioSource gameOverAudioSource;
    public AudioClip gameOverSound;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("IncreaseGameSpeed");


         
    }

    // Update is called once per frame
    void Update()
    {

        if (!isGameOver)
        {
            transform.position = Vector3.right * runSpeed * Time.deltaTime +transform.position;

        }    

        if(JumpCount == 2)
        {
            canJump = false;
        }    

        if (Input.GetKeyDown("space") && canJump && !isGameOver)
        {
            rb2d.velocity = Vector3.up * 7.5f;
            anim.SetTrigger("jump");
            JumpCount += 1;
            audioSource.Play();
        }  

    }

    public void GameOver()
    {

        isGameOver = true;
        anim.SetTrigger("death");
        StopCoroutine("IncreaseGameSpeed");

        StartCoroutine("ShowGameOverPanel");

       

        gameOverAudioSource.PlayOneShot(gameOverSound);
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            JumpCount = 0;
            canJump = true;
        }    
        if (collision.gameObject.CompareTag("Obstacle"))
        {

            GameOver();
        }
        if (collision.gameObject.CompareTag("BottomDetector"))
        {

            GameOver();
        }
    }

    IEnumerator IncreaseGameSpeed()
    {
        while (true) 
        {
            yield return new WaitForSeconds(10);
            if(runSpeed < 8)
            {
                runSpeed += 0.2f;
            }    

            if(GameObject.Find("GroundSpawer").GetComponent<ObstacleSpawner>().obstacleSpawnInterval > 1)
            {
                GameObject.Find("GroundSpawer").GetComponent<ObstacleSpawner>().obstacleSpawnInterval -= 0.1f;
            }    
            
        }

    }    
    
    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);

        FinalScoreText.text = "Score : " + GameObject.Find("ScoreDetector").GetComponent<ScoreSystem>().score;
        HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
    }    

    public void JumpButton()
    {
        if (canJump && !isGameOver)
        {
            rb2d.velocity = Vector3.up * 7.5f;
            anim.SetTrigger("jump");
            JumpCount += 1;
        }

    }    

}
