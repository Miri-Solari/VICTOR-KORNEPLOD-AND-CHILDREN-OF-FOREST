using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ForestGen : MonoBehaviour
{

    public Vector2 Dimesions;
    public GameObject[] TreePrefabs;
    public int[] TreePriority;
    public Vector2[] exeptions;

    void Start()
    {
        for(int x = 0; x < Dimesions.x; x++)
        {
            for(int y = 0; y < Dimesions.y; y++)
            {
                GenerateTile(x, y);
            }
        }
    }
    void GenerateTile(int x, int y)
    {
        foreach (Vector2 exeption in exeptions)
        {
            if (exeption == new Vector2(x, y))
            {
                return;
            }
        }
        
        GameObject b = Instantiate(TreePrefabs[Random.Range(0, TreePrefabs.Length-1)]);
        b.transform.position = Vector3.right * x * 2 + Vector3.forward * y * 2 - new Vector3(Dimesions.x - 1, 0, Dimesions.y - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
