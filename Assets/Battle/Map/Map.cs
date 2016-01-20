using System.Collections.Generic;
using UnityEngine;

class Map : MonoBehaviour {
    // Singleton
    static public Map Instance { get; private set; }

    private List<Enemy> enemyList = new List<Enemy>();
    private PC pc;
    private Enemy closest;

    private Map()
    {

    }

    private void Awake()
    {
        Instance = this;
        pc = GameObject.Find("Carp").GetComponent<PC>();
    }

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;

        var closest = FindClosest(pc.transform.localPosition, 2);
        if (closest != null) {

        }
    }

    public void AddEnemy(Enemy enemy)
    {
        enemyList.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
    }

    public Enemy FindClosest(Vector3 pos)
    {
        Enemy ret = null;
        float distance = 0;

        foreach (var enemy in enemyList) {
            float tempDist = Vector3.Distance(enemy.transform.localPosition, pos);

            if (ret == null || tempDist < distance) {
                ret = enemy;
                distance = tempDist;
            }
        }

        return ret;
    }

    public Enemy FindClosest(Vector3 pos, float maxDistance)
    {
        Enemy ret = null;
        float distance = 0;

        foreach (var enemy in enemyList) {
            float tempDist = Vector3.Distance(enemy.transform.localPosition, pos);

            if ((tempDist <= maxDistance) && (ret == null || tempDist < distance)) {
                ret = enemy;
                distance = tempDist;
            }
        }

        return ret;
    }
}