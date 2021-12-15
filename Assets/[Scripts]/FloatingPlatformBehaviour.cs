using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatformBehaviour : MonoBehaviour
{
    [Header("Float Movement And Behaviour")]
    public float BobbingFrequency = 0.5f;
    public float ShrinkingScaleFactor;
    public GameObject SolidGround;

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
    }

    void bobbingEffect()
    {
        transform.position = new Vector3(transform.position.x,
                PlatformOrigin.y + Mathf.PingPong(Time.time * BobbingFrequency, 0.5f), 0.0f);
    }

    void ShrinkPlatform(bool isPlayerOnTop)
    {
        Vector3 currentScale = SolidGround.transform.localScale;
        if (isPlayerOnTop)
        {
            if (currentScale.x > 0.0f)
            {
                currentScale.x -= Time.deltaTime * ShrinkingScaleFactor;
                //shrink more
            }
            else
            {
                currentScale.x = 0.0f;
            }
        }
        else
        {
            if (currentScale.x < 1.0f)
            {
                currentScale.x += Time.deltaTime * ShrinkingScaleFactor;
                //expand more
            }
            else
            {
                currentScale.x = 1.0f;
            }
        }

        SolidGround.transform.localScale = currentScale;
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
