using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBox : MonoBehaviour
{
    public PlayerContact player;
    public Sprite emptyBox;
    private SpriteRenderer m_Renderer;
    public GameObject particle;

    bool did;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContact>();
        m_Renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player.gameObject)
        {
            if (!did)
            {
                player.StarPower();
                particle.SetActive(true);
                m_Renderer.sprite = emptyBox;
                    }
        }
    }

}
