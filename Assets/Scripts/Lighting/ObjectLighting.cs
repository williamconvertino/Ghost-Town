using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLighting : MonoBehaviour
{
    private SpriteRenderer _lightSpriteRenderer;
    private SpriteRenderer _darkSpriteRenderer;

    public bool alwaysLit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _lightSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _darkSpriteRenderer = Instantiate(_lightSpriteRenderer, transform);
        _darkSpriteRenderer.transform.localPosition = Vector3.zero;
        Color darkSpriteColor = _darkSpriteRenderer.color;
        _darkSpriteRenderer.color = new Color(darkSpriteColor.r / 2, darkSpriteColor.g / 2, darkSpriteColor.b / 2);
        _darkSpriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        _lightSpriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    // Update is called once per frame
    void Update()
    {
        if (alwaysLit)
        {
            _lightSpriteRenderer.maskInteraction = SpriteMaskInteraction.None;
            _darkSpriteRenderer.enabled = false;
        }
    }
}
