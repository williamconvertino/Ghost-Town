using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiObjectLighting : MonoBehaviour
{
    private List<SpriteRenderer> _lightSpriteRenderers;
    private List<SpriteRenderer> _darkSpriteRenderers;
    
    public bool alwaysLit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _lightSpriteRenderers = new List<SpriteRenderer>();
        _darkSpriteRenderers = new List<SpriteRenderer>();
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child != null && child.gameObject != null)
            {
                children.Add(child.gameObject);
            }
        }

        foreach (GameObject child in children)
        {
            SetupObject(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (alwaysLit)
        {
            LightUpObjects();
        }
    }

    void SetupObject(GameObject obj)
    {
        SpriteRenderer lightSpriteRenderer = obj.GetComponent<SpriteRenderer>();
        SpriteRenderer darkSpriteRenderer = Instantiate(lightSpriteRenderer, obj.transform);

        _lightSpriteRenderers.Add(lightSpriteRenderer);
        _darkSpriteRenderers.Add(darkSpriteRenderer);
        
        darkSpriteRenderer.transform.localPosition = Vector3.zero;
        darkSpriteRenderer.transform.localScale = Vector3.one;
        Color darkSpriteColor = darkSpriteRenderer.color;
        darkSpriteRenderer.color = new Color(darkSpriteColor.r / 2, darkSpriteColor.g / 2, darkSpriteColor.b / 2);
        darkSpriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        lightSpriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    void LightUpObjects()
    {
        foreach (SpriteRenderer sr in _lightSpriteRenderers)
        {
            sr.maskInteraction = SpriteMaskInteraction.None;
        }

        foreach (SpriteRenderer sr in _darkSpriteRenderers)
        {
            sr.enabled = false;
        }
    }
}
