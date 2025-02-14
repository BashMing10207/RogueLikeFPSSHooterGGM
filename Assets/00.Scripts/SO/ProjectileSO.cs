using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SO/Projectile/SOSO")]
public class ProjectileSO : ScriptableObject
{
    public ProjectileType bulletType;
    public float speed,radius,damage;
}
