using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    // animation of combo canvas
    void Start()
    {
        transform.localScale = Vector2.zero;
        
    }

    public void Open()
    {
        transform.LeanScale(Vector2.one * 2, 0.3f).setEaseInBack().setOnComplete(Close);


    }
    public void Close()
    {
        transform.LeanScale(Vector2.zero, 1.3f).setEaseInBack();
    }
}