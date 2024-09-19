using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Enemy : IComponentData
{
    public List<EnemyData> Enemies;
}

public struct EnemyData
{
    public Entity Prefab;
    public int Speed;
}
