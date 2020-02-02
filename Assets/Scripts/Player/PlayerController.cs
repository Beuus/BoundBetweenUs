using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public string controllerInput;
    public string keysInput;
    public bool controller;

    public Sprite boySprite;
    public Sprite girlSprite;
    public RuntimeAnimatorController boyAnim;
    public RuntimeAnimatorController girlAnim;
    public AudioClip step; 

    private Rigidbody2D player;
    private Animator anim;
    private AudioSource soundSource;
    private bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        soundSource = GetComponent<AudioSource>();
        soundSource.clip = step;

        GameManager g = FindObjectOfType<GameManager>();

        if (g.player1 == PlayerGenre.BOY)
        {
            GetComponent<SpriteRenderer>().sprite = boySprite;
            GetComponent<Animator>().runtimeAnimatorController = boyAnim;
        }
        else{
            GetComponent<SpriteRenderer>().sprite = girlSprite;
            GetComponent<Animator>().runtimeAnimatorController = girlAnim;

        }
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalAxis;
        if (controller) 
            horizontalAxis = Input.GetAxis(controllerInput);
      
        else
            horizontalAxis = Input.GetAxis(keysInput);

        if (Input.GetAxis(controllerInput) != 0 || Input.GetAxis(keysInput) != 0)
        {
            anim.SetBool("walking", true);
            if (Input.GetAxis(controllerInput) < 0 || Input.GetAxis(keysInput) < 0)
            {
                transform.localScale = new Vector3 (-1, 1, 1);
                isWalking = true;
                tryPlayingSound();
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                isWalking = true;
                tryPlayingSound();
            }
        }
        else {
            anim.SetBool("walking", false);
            isWalking = false;
            
        }

        Vector3 movement = new Vector3(horizontalAxis, 0, 0) * speed * Time.deltaTime;
  
        player.transform.localPosition = transform.localPosition + movement;
    }

    void tryPlayingSound() {
        if (!soundSource.isPlaying) {
            soundSource.Play();
        }
    }
}
