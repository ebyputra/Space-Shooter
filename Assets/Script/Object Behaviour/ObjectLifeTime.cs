using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectLifeTime : MonoBehaviour
{

    public float lifeTime;
    public float blinkingDelay;
    public UnityEvent OnTimerReachedZero;
    private float timer;

    void Start()
    {
        timer = lifeTime;

        StartCoroutine(ObjectTimer());
    }

  

    void Update()
    {
        if (timer <= 0)
        {
            OnTimerReachedZero?.Invoke();
        }

        timer -= Time.deltaTime;
    }

    private IEnumerator ObjectTimer ()
    {
        Color defaultColor = GetComponent<SpriteRenderer>().color;
        Color blinkcolor = defaultColor;
        blinkcolor.a = 0.5f;

        yield return new WaitForSeconds(lifeTime * 0.7f);

        while (timer > 0)
        {
            GetComponent<SpriteRenderer>().color = blinkcolor ;
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = defaultColor;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
