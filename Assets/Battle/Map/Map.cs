using System.Collections.Generic;
using UnityEngine;

class Map : MonoBehaviour {
    // Singleton
    public Map Instance { get; private set; }

    private List<Enemy> enemyList = new List<Enemy>();

    private Map()
    {

    }

    private void Start()
    {
        Instance = this;
    }

    public void AddEnemy(Enemy enemy)
    {
        enemyList.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
    }
}