using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullets")]
public class BulletScriptObj : ScriptableObject
{
    public float speed;
    public int damage;
    public string element;

    public Sprite artwork;

}
