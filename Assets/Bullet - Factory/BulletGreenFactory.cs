using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGreenFactory : MonoBehaviour, BulletAbstractFactory
{

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform firepoint;

    [SerializeField]
    private GameObject Parent;

    // Start is called before the first frame update
    void Start()
    {
        Parent = GameObject.FindGameObjectWithTag("BulletParent");
    }
    public void SetBullet(GameObject bullet)
    {
        this.bullet = bullet;
    }

    public IBullet MakeBullet()
    {
        GameObject spawned_bullet = Instantiate(bullet, firepoint.position, firepoint.rotation, Parent.transform);
        IBullet ibullet = spawned_bullet.GetComponent<IBullet>();
        return ibullet;
    }

    public void SetFirepoint(Transform transform)
    {
        firepoint = transform;
    }
}
