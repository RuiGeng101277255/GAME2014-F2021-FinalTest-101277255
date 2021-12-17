/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: FloatingPlatformBehaviour.cs
 Last Modified: December 17th, 2021
 Description: A floating platform that will shrink in size when the player lands on it, and expand when the player leave it.
 Version History: v1.05 Fixed minor glitches and included the internal document
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatformBehaviour : MonoBehaviour
{
    [Header("Float Movement And Behaviour")]
    public float BobbingFrequency = 0.5f;
    public float ShrinkingScaleFactor;
    public GameObject SolidGround;

    [Header("SFX")]
    public AudioSource ShrinkSFX;
    public AudioSource ExpandSFX;
    bool isSFXPlaying;
    FloatingPlatformState currentState;

    //Checking for whether the platform should be shrinking or expanding (if not at their correct limits)
    bool hasPlayerLanded;
    Vector3 PlatformOrigin;

    // Start is called before the first frame update
    void Start()
    {
        PlatformOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ShrinkPlatform(hasPlayerLanded);
        bobbingEffect();
        PlaySoundEffect();
    }

    //Bobs the platform up and down over time
    void bobbingEffect()
    {
        transform.position = new Vector3(transform.position.x, PlatformOrigin.y + Mathf.PingPong(Time.time * BobbingFrequency, 0.5f), 0.0f);
    }

    //Defines and updates the floating platform state it is currently in.
    //Checks for the limit of the action that is currently being performed
    //Changes the size of the platform accordingly
    void ShrinkPlatform(bool isPlayerOnTop)
    {
        Vector3 currentScale = SolidGround.transform.localScale;
        if (isPlayerOnTop)
        {
            if (currentScale.x > 0.0f)
            {
                currentScale.x -= Time.deltaTime * ShrinkingScaleFactor;
                currentState = FloatingPlatformState.SHRINKING;
            }
            else
            {
                currentScale.x = 0.0f;
                currentState = FloatingPlatformState.NOTHING;
            }
        }
        else
        {
            if (currentScale.x < 1.0f)
            {
                currentScale.x += Time.deltaTime * ShrinkingScaleFactor;
                currentState = FloatingPlatformState.EXPANDING;
                //expand more
            }
            else
            {
                currentScale.x = 1.0f;
                currentState = FloatingPlatformState.NOTHING;
            }
        }

        SolidGround.transform.localScale = currentScale;
    }

    //Plays the correct sound effect based on the platform's current state
    void PlaySoundEffect()
    {
        if (currentState != FloatingPlatformState.NOTHING)
        {
            //Plays the corresponding sfx based on the current state if it's not already playing
            if ((currentState == FloatingPlatformState.SHRINKING) && (!ShrinkSFX.isPlaying))
            {
                ExpandSFX.Stop();
                ShrinkSFX.Play();
            }
            else if ((currentState == FloatingPlatformState.EXPANDING) && (!ExpandSFX.isPlaying))
            {
                ShrinkSFX.Stop();
                ExpandSFX.Play();
            }
            isSFXPlaying = true;
        }
        else
        {
            //Stops all sound effects when the state is nothing, aka not expanding nor shrinking
            ShrinkSFX.Stop();
            ExpandSFX.Stop();
            isSFXPlaying = false;
        }
    }

    //Player has landed on the platform
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>() != null)
        {
            hasPlayerLanded = true;
        }
    }

    //Player has left the platform
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>() != null)
        {
            hasPlayerLanded = false;
        }
    }
}

//Types of possible states the platform can be in
public enum FloatingPlatformState
{
    NOTHING,
    SHRINKING,
    EXPANDING
}