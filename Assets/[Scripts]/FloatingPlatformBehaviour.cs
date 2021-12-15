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

    void bobbingEffect()
    {
        transform.position = new Vector3(transform.position.x, PlatformOrigin.y + Mathf.PingPong(Time.time * BobbingFrequency, 0.5f), 0.0f);
    }

    void ShrinkPlatform(bool isPlayerOnTop)
    {
        Vector3 currentScale = SolidGround.transform.localScale;
        if (isPlayerOnTop)
        {
            if (currentScale.x > 0.0f)
            {
                currentScale.x -= Time.deltaTime * ShrinkingScaleFactor;
                currentState = FloatingPlatformState.SHRINKING;
                //shrink more
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

    void PlaySoundEffect()
    {
        if (currentState != FloatingPlatformState.NOTHING)
        {
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


            //if (!isSFXPlaying)
            //{
            //    if (currentState == FloatingPlatformState.SHRINKING)
            //    {
            //        ShrinkSFX.Play();
            //    }
            //    else if (currentState == FloatingPlatformState.EXPANDING)
            //    {
            //        ExpandSFX.Play();
            //    }
            //}
        }
        else
        {
            ShrinkSFX.Stop();
            ExpandSFX.Stop();
            //ShrinkAndExpandSFX.Stop();
            isSFXPlaying = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>() != null)
        {
            hasPlayerLanded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>() != null)
        {
            hasPlayerLanded = false;
        }
    }
}

public enum FloatingPlatformState
{
    NOTHING,
    SHRINKING,
    EXPANDING
}