using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class shipControl : MonoBehaviour 
{

    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float RCSthurst = 100f;
    [SerializeField] float Mainthurst = 50f;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip leveUP;

    [SerializeField] ParticleSystem  ShipFlames;
	[SerializeField] ParticleSystem  ShipDestroy;
    [SerializeField] Vector3 MoveVec;
    [Range(0, 1)] [SerializeField] float MovRange;

    Vector3 StartPos;

    enum States {Alive, Dying, Transcending }
    States State = States.Alive;


	// Use this for initialization
	void Start () 
    {
        StartPos = transform.position;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()

    {

        Vector3 offset = MoveVec * MovRange;
        transform.position = StartPos + offset;
        if(State == States.Alive)
        {
            Thurstmode();
            movementmode();
        }
    

    }

    void Thurstmode()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * Mainthurst);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                ShipFlames.Play();
            }
        }

        else
        {
            audioSource.Stop();

        }
    }
     void movementmode()
    {
        float FrameperRotation = RCSthurst * Time.deltaTime;

        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.right * FrameperRotation);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.right * FrameperRotation);
        }


        rb.freezeRotation = false;

    }

     void OnCollisionEnter(Collision collision)

    {
        if(State!=States.Alive)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Finish":
                State = States.Transcending;
                Invoke("LoadNextLevel",1f);
                audioSource.PlayOneShot(leveUP);
                break;
            case "enemy":
                State = States.Dying;
                audioSource.Stop();
                ShipFlames.Stop();
                Invoke("LoadDeadLevel", 1f);
                ShipDestroy.Play();
                audioSource.PlayOneShot(death);
                break;
            default:
                print("nothing");
                break;
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    void LoadDeadLevel()
    {
        SceneManager.LoadScene(0);

    }
}


