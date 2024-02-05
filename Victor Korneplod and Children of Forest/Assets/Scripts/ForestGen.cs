using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ForestGen : MonoBehaviour
{

    public TextAsset LevelLog;
    public Vector2 Dimesions;
    public GameObject[] TreePrefabs;
    public int[] TreePriority;
    public GameObject[] AnimalPrefab;
    public List<Vector2> exeptions;

    private Dictionary<string, int> AnimalID = new Dictionary<string, int>
    {
        {"bear", 0},
        {"wolf", 1},
        {"chicken", 2},
        {"kiken", 3},
        {"syka", 4},
        {"explosion", 5}


    };

    void Start()
    {
        GenerateAnimals();
        for(int x = 0; x < Dimesions.x; x++)
        {
            for(int y = 0; y < Dimesions.y; y++)
            {
                GenerateTile(x, y);
            }
        }
    }
    void GenerateAnimals()
    {
        string[] log = LevelLog.text.Split('\n');
        for(int animal = 1; animal < log.Length; animal++)
        {
            string[] SplitLog = { "", "", "", ""};
            int cc = 0;
            foreach (char ch in log[animal])
            {
                if (ch == ' ')
                {
                    cc = 1;
                }
                else if (ch == ':')
                {
                    cc = 2;
                }
                else if (ch == ',')
                {
                    cc = 3;
                }
                else
                {
                    SplitLog[cc] = SplitLog[cc] + ch;
                }
            }

            Debug.Log(SplitLog[0] + "|" + SplitLog[2] + "|" + SplitLog[3] + "|");

            var b = Instantiate(AnimalPrefab[AnimalID[SplitLog[0]]]);
            if (SplitLog[1] == "N")
            {
                b.transform.eulerAngles = Vector3.up * -90;
                exeptions.Add(new Vector2(int.Parse(SplitLog[2]) + 1, int.Parse(SplitLog[3])));
            }
            if (SplitLog[1] == "E")
            {
                b.transform.eulerAngles = Vector3.zero;
                exeptions.Add(new Vector2(int.Parse(SplitLog[2]), int.Parse(SplitLog[3]) - 1));
            }
            if (SplitLog[1] == "S")
            {
                b.transform.eulerAngles = Vector3.up * 90;
                exeptions.Add(new Vector2(int.Parse(SplitLog[2]) - 1, int.Parse(SplitLog[3])));
            }
            if (SplitLog[1] == "W")
            {
                b.transform.eulerAngles = Vector3.up * 180;
                exeptions.Add(new Vector2(int.Parse(SplitLog[2]) , int.Parse(SplitLog[3]) + 1));
            }
            exeptions.Add(new Vector2(int.Parse(SplitLog[2]), int.Parse(SplitLog[3])));
            b.transform.position = Vector3.right * int.Parse(SplitLog[2]) * 2 + Vector3.forward * int.Parse(SplitLog[3]) * 2 - new Vector3(Dimesions.x - 1, 0, Dimesions.y - 1);
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
        
        GameObject b = Instantiate(TreePrefabs[Random.Range(0, TreePrefabs.Length)]);
        b.transform.position = Vector3.right * x * 2 + Vector3.forward * y * 2 - new Vector3(Dimesions.x - 1, 0, Dimesions.y - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
