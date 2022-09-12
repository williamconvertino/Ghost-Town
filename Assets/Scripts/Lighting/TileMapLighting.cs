using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapLighting : MonoBehaviour
{
    private TilemapRenderer _lightTileMapRenderer;
    private Tilemap _lightTileMap;
    private TilemapRenderer _darkTileMapRenderer;
    private Tilemap _darkTileMap;
    
    public bool alwaysLit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _lightTileMapRenderer = GetComponentInChildren<TilemapRenderer>();
        _lightTileMap = GetComponentInChildren<Tilemap>();
        
        _darkTileMapRenderer = Instantiate(_lightTileMapRenderer, transform);
        _darkTileMapRenderer.transform.localPosition = Vector3.zero;
        _darkTileMap = _darkTileMapRenderer.GetComponent<Tilemap>();
        _darkTileMap.transform.localPosition = Vector3.zero;
        
        Color darkTileMapColor = _darkTileMap.color;
        _darkTileMap.color = new Color(darkTileMapColor.r / 2, darkTileMapColor.g / 2, darkTileMapColor.b / 2);
        
        _darkTileMapRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        
        _lightTileMapRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    // Update is called once per frame
    void Update()
    {
        if (alwaysLit)
        {
            _lightTileMapRenderer.maskInteraction = SpriteMaskInteraction.None;
            _darkTileMap.enabled = false;
        }
    }
}
