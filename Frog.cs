using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{
    AudioSource _audioSource;
    Rigidbody2D _rigidbody2D;
    Animator _animator;
    int counts = 0;
    float jumpForce = 6.5f;
    public string scene;
    public Text _pointCounter;
    public AudioSource pointplusaudio;
    public AudioSource crash_sound;
    public AudioSource music;
    public GameObject spawner;
    bool stopPlus = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _pointCounter.text = $"{counts}";

        if (Input.GetMouseButtonDown(0))
        {
            Up();
        }
    }

    private void Up()
    {
        _rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        _audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "point_plus" && stopPlus == false)
        {
            counts += 1;
            pointplusaudio.Play();
            StartCoroutine(NoDouble());
        }

        if (trigger.gameObject.tag == "column")
        {
            spawner.SetActive(false);
            crash_sound.Play();
            jumpForce = 0;
            scene = "dead";
            music.Stop();
            stopPlus = true;
            _animator.SetBool("isDead", true);
            PlayerPrefs.SetInt("counts", counts);
            PlayerPrefs.Save();
            StartCoroutine(TransitionLose());
        }
    }

    private void OnCollisionEnter2D(Collision2D trigger)
    {
        if(trigger.gameObject.tag == "column")
        {
            spawner.SetActive(false);
            crash_sound.Play();
            jumpForce = 0;
            scene = "dead";
            music.Stop();
            stopPlus = true;
            _animator.SetBool("isDead", true);
            PlayerPrefs.SetInt("counts", counts);
            PlayerPrefs.Save();
            StartCoroutine(TransitionLose());
        }
    }

    IEnumerator NoDouble()
    {
        yield return new WaitForSeconds(0.00001f);
        stopPlus = true;
        yield return new WaitForSeconds(0.5f);
        stopPlus = false;
    }

    IEnumerator TransitionLose()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("ClassicGreen_Lose");
    }
}
