using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BulletAbstractFactory
{

    public void SetBullet(GameObject bullet);
    public IBullet MakeBullet();
    public void SetFirepoint(Transform transform);
}
