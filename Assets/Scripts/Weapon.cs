using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public string weaponName;
    public float roundPerMin, spreadRange, bulletSpeed, bulletTime;
    public int ammunition, bulletDamage;

    public Weapon(string weaponName, float roundPerMin, float spreadRange, int bulletDamage, float bulletSpeed, float bulletTime, int ammunition){
        this.weaponName = weaponName;
        this.roundPerMin = roundPerMin;
        this.spreadRange = spreadRange;
        this.bulletDamage = bulletDamage;
        this.bulletSpeed = bulletSpeed;
        this.bulletTime = bulletTime;
        this.ammunition = ammunition;
    }
}
