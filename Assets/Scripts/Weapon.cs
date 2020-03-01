using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public float roundPerMin, spreadRange, bulletSpeed, bulletTime;
    public int ammunition, bulletDamage;

    public Weapon(float roundPerMin, float spreadRange, int bulletDamage, float bulletSpeed, float bulletTime, int ammunition){
        this.roundPerMin = roundPerMin;
        this.spreadRange = spreadRange;
        this.bulletDamage = bulletDamage;
        this.bulletSpeed = bulletSpeed;
        this.bulletTime = bulletTime;
        this.ammunition = ammunition;
    }
}
