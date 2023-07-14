using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategySimple : MonoBehaviour, Strategy
{

    [SerializeField]
    private BulletAbstractFactory factory;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int damage;

    [SerializeField]
    private float cooldown;

    [SerializeField]
    private float timeOffset;

    [SerializeField]
    private float reloading;

    // Start is called before the first frame update
    void Start()
    {
        factory = GetComponent<BulletAbstractFactory>();
        timeOffset = Random.Range(0.2f, 5f);
        reloading = timeOffset;
    }

    public void Move()
    {

    }

    // Update is called once per frame
    public void Shoot()
    {
        reloading -= Time.deltaTime;
        if (reloading < 0)
        {
            Fire();
            reloading = cooldown;
        }
    }
    void Fire()
    {
        if (factory != null)
        {
            IBullet bullet = factory.MakeBullet();
            bullet.SetSpeed(speed);
            bullet.SetDamage(damage);
        }

    }

    public void SetCooldown(int time)
    {
        this.cooldown = time;
    }

    public void SetBullet(BulletAbstractFactory f)
    {
        this.factory = f;
    }

    public void SetBulletDetails(float spd, int dmg)
    {
        speed = spd;
        damage = dmg;
    }
}
