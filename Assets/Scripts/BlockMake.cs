using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BlockMake : MonoBehaviour
{

    public GameObject block;
    public GameObject dot;
    public bool generate = false;
    public bool delete = false;
    // Use this for initialization
    private List<List<int>> blockArray = new List<List<int>>{
        new List<int>{1,1,1,1,1,1,1,1,1,1,1,1,1},
        new List<int>{1,0,0,0,0,0,0,0,0,0,0,0,1},
        new List<int>{1,0,0,0,0,0,0,0,0,0,0,0,1},
        new List<int>{1,0,0,0,0,0,0,0,0,0,0,0,1},
        new List<int>{1,0,0,0,0,0,0,0,0,0,0,0,1},
        new List<int>{1,0,0,0,0,0,0,0,0,0,0,0,1},
        new List<int>{1,0,0,0,0,0,0,0,0,0,0,0,1},
        new List<int>{1,1,1,1,1,1,1,1,1,1,1,1,1}
    };
    void Start()
    {
        if (generate)
        {
            generateBlock();
        }
        if (delete)
        {
            deleteBlock();
        }

    }

    void generateBlock()
    {
        GameObject blocks = new GameObject("blocks");
        GameObject dots = new GameObject("dots");
        for (int i = 0; i < blockArray.Count; i++)
        {
            for (int j = 0; j < blockArray[i].Count; j++)
            {
                if (blockArray[i][j] == 1)
                {
                    GameObject obj = GameObject.Instantiate(block, new Vector3(1.5f * j, 0.5f, -1.5f * i), Quaternion.identity);
                    obj.transform.parent = blocks.transform;
                }
                else if (blockArray[i][j] == 2)
                {
                    GameObject obj = GameObject.Instantiate(dot, new Vector3(1.5f * j, 0.5f, -1.5f * i), Quaternion.identity);
                    obj.transform.parent = dots.transform;
                }
            }
        }
    }

    void deleteBlock()
    {
        DestroyImmediate(GameObject.Find("blocks"));
        DestroyImmediate(GameObject.Find("dots"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
