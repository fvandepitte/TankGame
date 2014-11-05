using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.Collections.Generic;

public class Map : MonoBehaviour {

    public TextAsset MapFile;
    public GameObject[][] MapObjects;
    public GameObject[] Obstacles;


	// Use this for initialization
	void Start () {
        if (MapFile)
        {
            int rows = 0, columns = 0;
            JSONArray file = JSON.Parse(MapFile.text).AsArray;
            MapObjects = new GameObject[file.Count + 2][];
            rows = MapObjects.Length;
            for (int row = 0; row < file.Count; row++)
            {
                JSONArray jrow = file[row].AsArray;
                MapObjects[row + 1] = new GameObject[jrow.Count + 2];
                
                columns = MapObjects[row + 1].Length;
                
                for (int cell = 0; cell < jrow.Count; cell++)
                {
                    MapObjects[row + 1][cell + 1] = new GameObject(jrow[cell].Value);

                    SpriteRenderer renderer = MapObjects[row + 1][cell + 1].AddComponent<SpriteRenderer>();
                    renderer.sprite = AssetLoader.Instance.Load(jrow[cell].Value);

                    MapObjects[row + 1][cell + 1].transform.Translate(new Vector3((cell + 1) * MapObjects[row + 1][cell + 1].renderer.bounds.size.x, -(row + 1) * MapObjects[row + 1][cell + 1].renderer.bounds.size.y, 1));
                    MapObjects[row + 1][cell + 1].transform.parent = transform;
                }
            }

            float width = MapObjects[1][1].renderer.bounds.size.x;
            float height = MapObjects[1][1].renderer.bounds.size.y;

            MapObjects[0] = new GameObject[MapObjects[1].Length];
            MapObjects[MapObjects.Length - 1] = new GameObject[MapObjects[2].Length];

            for (int row = 0; row < MapObjects.Length; row++)
            {
                for (int cell = 0; cell < MapObjects[row].Length; cell++)
                {
                    if (!MapObjects[row][cell])
                    {
                        MapObjects[row][cell] = new GameObject("Wall");
                        MapObjects[row][cell].transform.Translate(new Vector3(cell * width, -row * height));
                        MapObjects[row][cell].transform.parent = transform;

                        BoxCollider collider = MapObjects[row][cell].AddComponent<BoxCollider>();
                        collider.size = new Vector3(width, height);

                    }
                }
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}