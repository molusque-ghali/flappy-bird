using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Birdscript : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed = 40f;
    [SerializeField]
    private float flapForce = 300f;
    bool IsDead = false;
    public GameObject ReplayButton;
    public GameObject coin;
    public TextMeshProUGUI scoreText;
    public GameObject startPanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "obstacles")
        {
            IsDead = true;
            rb2d.velocity = Vector2.zero;
            startPanel.SetActive(true);
            ReplayButton.SetActive(true);
            GetComponent<Animator>().SetBool("IsDead", true);
        }  
    }
    int score = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Score" && !IsDead) 
        {   
          
            score++;
            coin.GetComponent<Animator>().Play("destroyCoin");
            scoreText.text = score.ToString();
        }
    }
    public void UnFreeze()
    {
        Time.timeScale = 1;
    }



    public void Replay()
    {
        SceneManager.LoadScene("Game",LoadSceneMode.Single);
    }



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        ReplayButton.SetActive(false);
        rb2d = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& IsDead==false)
        {
            rb2d.velocity = Vector2.right * speed ;
            rb2d.AddForce(Vector2.up * flapForce);

        }
     
    }

}
