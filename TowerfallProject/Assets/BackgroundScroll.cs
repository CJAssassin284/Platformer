using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
    public float speed = 0.5f;
    public float start = 0;

    Vector2 offset = new Vector2(0, 0);
    public SpriteRenderer rend;
    void Update()
    {
        offset.x = start + Time.time * speed;

    }
}
