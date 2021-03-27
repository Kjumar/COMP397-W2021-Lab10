using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelController : MonoBehaviour
{
    [Header("World Size")]
    public float width;
    public float length;
    public List<GameObject> tilePrefabs;
    public List<GameObject> activeTiles;

    [Header("Tile Properties")]
    public int tileWidth;
    public int tileLength;

    [Header("Navigation")]
    private NavMeshSurface surface;

    private void Awake()
    {
        surface = GetComponent<NavMeshSurface>();
        BuildWorld();
    }

    // Start is called before the first frame update
    void Start()
    {
        surface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildWorld()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < length; z++)
            {
                if (x != 0 || z != 0)
                {
                    int tileIndex = Random.Range(0, tilePrefabs.Count);
                    Vector3 tilePosition = new Vector3(tileWidth * x, 0f, tileLength * z);
                    Quaternion tileRotation = Quaternion.Euler(0f, Random.Range(0, 4) * 90f, 0f);
                    GameObject newTile = Instantiate(tilePrefabs[tileIndex], tilePosition, tileRotation);
                    newTile.transform.parent = transform;
                    activeTiles.Add(newTile);
                }
            }
        }
    }
}
