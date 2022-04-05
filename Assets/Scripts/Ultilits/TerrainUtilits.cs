using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainUtilits : MonoBehaviour
{
    [SerializeField] Terrain terrain;
    static Terrain terrainStatic;

    private void Awake()
    {
        terrainStatic = terrain;
    }

    public static Vector3 GetRandomPointOnTerrain()
    {
        Vector3 pos = new Vector3(Random.Range(0, terrainStatic.terrainData.size.x + terrainStatic.transform.position.x), 0, Random.Range(0, terrainStatic.terrainData.size.z + terrainStatic.transform.position.z));
        pos.y = terrainStatic.SampleHeight(pos);
        return pos;
    }
}
