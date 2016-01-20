﻿using System.Collections.Generic;
using UnityEngine;

class Map : MonoBehaviour {
    // Singleton
    static public Map Instance { get; private set; }

    private List<Enemy> enemyList = new List<Enemy>();
    private PC pc;
    private Enemy target;
    private int pcIndex = 0;

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

        // Change pc action to closest monster's setting
        var closest = FindClosest(pc.transform.localPosition, 2);
        if (closest != null) {
            if (target != closest) {
                if (target != null) {
                    target.UnsetPCAction(pc);
                }

                target = closest;
                closest.SetPCAction(pc);
            }
        }
        else {
            if (target != null) {
                target.UnsetPCAction(pc);
            }
        }

        target = closest;

        // Generate new monster
        var newPcIndex = (int)(pc.transform.localPosition.x / 5.0f);
        if (newPcIndex != pcIndex) {
            pcIndex = newPcIndex;

            GenerateNewMonster((pcIndex + 1) * 5);
        }
    }

    public void GenerateNewMonster(int xPos)
    {
        var monsterList = new string[] { "AttackingEnemy", "HurdleEnemy", "WallEnemy" };
        var index = Random.Range(0, monsterList.Length);

        var monsterName = monsterList[index];
        var newMonster = Instantiate(Resources.Load(monsterName)) as GameObject;
        newMonster.transform.localPosition = new Vector3(xPos, 0, 0);

        AddEnemy(newMonster.GetComponent<Enemy>());
    }

    public void AddEnemy(Enemy enemy)
    {
        enemyList.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
        if (enemy == target) {
            target.UnsetPCAction(pc);
            target = null;
        }
    }

    public Enemy FindClosest(Vector3 pos)
    {
        Enemy ret = null;
        float distance = 0;

        foreach (var enemy in enemyList) {
            float tempDist = Vector3.Distance(enemy.transform.localPosition, pos);

            if ((pos.x <= enemy.transform.localPosition.x) && (ret == null || tempDist < distance)) {
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

            if ((pos.x <= enemy.transform.localPosition.x) && (tempDist <= maxDistance) && (ret == null || tempDist < distance)) {
                ret = enemy;
                distance = tempDist;
            }
        }

        return ret;
    }
}