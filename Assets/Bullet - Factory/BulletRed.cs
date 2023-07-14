using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRed : MonoBehaviour, IBullet
{
    [SerializeField]
    private int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            if (collision.gameObject.TryGetComponent<ICreature>(out ICreature health))
            {
                health.GetDamage(damage);
            }
        }
        Destroy(gameObject);
    }

    public void SetSpeed(float speed)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = speed * Vector2.up;
    }

    public void SetDamage(int dmg)
    {
        damage = dmg;
    }
}
