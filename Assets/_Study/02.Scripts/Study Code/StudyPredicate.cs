using System;
using UnityEngine;

public class StudyPredicate : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Predicate<float> myPredicate;

    public void Start()
    {
        myPredicate = SetFlip;
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");

        spriteRenderer.flipX = myPredicate(h);

        

        if (h < 0)
            spriteRenderer.flipX = true;
        else if (h > 0)
            spriteRenderer.flipX = false;
    }

    bool SetFlip(float h)
    {
        if (h < 0)
            return true;
        else if (h > 0)
            return false;
        else
            return false;
    }


}
