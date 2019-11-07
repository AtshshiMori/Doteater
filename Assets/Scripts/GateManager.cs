using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> gates = null;
    float time = 0;

    void Update()
    {
        time += Time.deltaTime;

        // 3sに1回チェック
        if (time > 3)
        {
            CheckEnemyCount();
            time = 0;
        }
    }

    public void CheckEnemyCount()
    {
        if (gates.Count <= 0) return;

        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        // 敵が全滅したら最初のゲートをオープンする
        if (enemys.Length == 0)
        {

            Destroy(gates[0]);
            gates.RemoveAt(0);
        }
    }
}
