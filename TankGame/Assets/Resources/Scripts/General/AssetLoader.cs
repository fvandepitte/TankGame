using System;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class AssetLoader
{
    private static AssetLoader _instance = new AssetLoader();

    public static AssetLoader Instance {
        get { return AssetLoader._instance; }
    }

    private const string KEYFILE = "MapFiles/key";

    private const string SPRITELOCATION = "Sprites/Environment/";
    
    private JSONNode _root;
    private Dictionary<string, Sprite> _spritesMapping;

    private AssetLoader() {
        _root = JSON.Parse(Resources.Load<TextAsset>(KEYFILE).text);
        _spritesMapping = new Dictionary<string, Sprite>();
    }

    public Sprite Load(string name) {
        if (!_spritesMapping.ContainsKey(name))
        {
            _spritesMapping[name] = Resources.Load<Sprite>(string.Format("{0}{1}", SPRITELOCATION, _root[name]["name"].Value));
        }
        return _spritesMapping[name];
    }
}
