using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public interface Strategy
{
    public void Move();

    public void Shoot();

    public void SetCooldown(int time);

    public void SetBullet(BulletAbstractFactory f);

    public void SetBulletDetails(float spd, int dmg);
}
