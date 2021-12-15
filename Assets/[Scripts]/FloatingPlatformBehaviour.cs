using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatformBehaviour : MonoBehaviour
{
    public float BobbingFrequency = 0.5f;

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
        if (isPlayerOnTop)
        {

        }
        else
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>() != null)
        {
            hasPlayerLanded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>() != null)
        {
            hasPlayerLanded = false;
        }
    }
}
