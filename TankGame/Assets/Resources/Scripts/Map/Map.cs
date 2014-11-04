using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Map : MonoBehaviour {

    public TextAsset MapFile;
    public GameObject[][] MapObjects;

	// Use this for initialization
	void Start () {
        if (MapFile)
        {
            JSONArray file = JSON.Parse(MapFile.text).AsArray;
            MapObjects = new GameObject[file.Count][];

            for (int row = 0; row < file.Count; row++)
            {
                JSONArray jrow = file[row].AsArray;
                MapObjects[row] = new GameObject[jrow.Count];
                for (int cell = 0; cell < jrow.Count; cell++)
                {
                    MapObjects[row][cell] = new GameObject(jrow[cell].Value);

                    SpriteRenderer renderer = MapObjects[row][cell].AddComponent<SpriteRenderer>();
                    renderer.sprite = AssetLoader.Instance.Load(jrow[cell].Value);

                    MapObjects[row][cell].transform.Translate(new Vector3(cell * MapObjects[row][cell].renderer.bounds.size.x, -row * MapObjects[row][cell].renderer.bounds.size.y, 1));
                    MapObjects[row][cell].transform.parent = transform;
                }
            }

            
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}