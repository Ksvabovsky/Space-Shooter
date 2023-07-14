using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGreen : MonoBehaviour, IBullet
{
    [SerializeField]
    private int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.TryGetComponent<ICreature>(out ICreature health))
            {
                health.GetDamage(damage);
            }
        }
        if (collision.gameObject.tag != "Alien")
        {
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = speed * Vector2.down;
    }

    public void SetDamage(int dmg)
    {
        damage = dmg;
    }
}
