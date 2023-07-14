using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyMove : MonoBehaviour, Strategy
{
    private Vector2 MovePosition;

    [SerializeField]
    private float SideMove = 0.6f;

    [SerializeField]
    private float speedMove = 0.3f;

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

        MovePosition = new Vector2(0, 0);
    }

    public void Move()
    {
        Debug.Log("MOve");

        if (MovePosition.x > SideMove)
        {
            speedMove = -speedMove;
        }
            

        if (MovePosition.x < -SideMove)
        {
            speedMove = -speedMove;
        }

        transform.Translate(Vector2.right * speedMove * Time.deltaTime);
        MovePosition.x = MovePosition.x + speedMove * Time.deltaTime;
    }

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
