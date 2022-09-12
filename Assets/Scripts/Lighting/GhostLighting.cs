using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLighting : MonoBehaviour
{
    public bool alwaysLit = false;

    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    // Update is called once per frame
    void Update()
    {
        if (alwaysLit)
        {
            _spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        }
    }
}
