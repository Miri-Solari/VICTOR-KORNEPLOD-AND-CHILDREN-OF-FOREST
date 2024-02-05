using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ForestGen : MonoBehaviour
{

    public Vector2 Dimesions;
    public GameObject[] TreePrefabs;
    public int[] TreePriority;

    void Start()
    {
        for(int x = 0; x > Dimesions.x; x++)
        {
            for(int y = 0; y > Dimesions.y; y++)
            {
                Debug.Log(x + " " + y);
                Vector2 RandomCheck = Vector2.up * Random.Range(0, TreePriority.Sum());
                for(int i = 0;  i < TreePriority.Length; i++)
                {
                    if (RandomCheck.x < RandomCheck.y)
                    {
                        GameObject b = Instantiate(TreePrefabs[i]);
                        b.transform.position = Vector3.right * x*2 + Vector3.forward * y*2 - new Vector3(Dimesions.x, 0, Dimesions.y);
                        break;
                    }
                    else
                    {
                        RandomCheck.x += TreePriority[i];
                    }
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
