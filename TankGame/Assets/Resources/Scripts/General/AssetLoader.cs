using System;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class AssetLoader
{
    private const string SPRITELOCATION = "Sprites/Terrain/";
    
    private JSONNode _root;
    private Dictionary<string, Sprite> _spritesMapping;

    public AssetLoader() {
        _root = JSON.Parse(Resources.Load<TextAsset>(string.Format("{0}{1}", SPRITELOCATION, "TileMapping")).text);
        _spritesMapping = new Dictionary<string, Sprite>();
    }

    public Sprite Load(string name) {
        return _spritesMapping[name];
    }
}
