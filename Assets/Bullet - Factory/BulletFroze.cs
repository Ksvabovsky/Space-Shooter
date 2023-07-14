using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFroze : MonoBehaviour, IBullet
{
    public Sprite frozen;
    public Sprite Normal;

    [SerializeField]
    private int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            State state = collision.gameObject.AddComponent<FrozenState>();
            state.Normal = Normal;
            state.frozen = frozen;
            Player_Script player = collision.gameObject.GetComponent<Player_Script>();
            player.ChangeState(state);
            player.ChangeSprite(frozen);

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
        rb.velocity = speed * Vector2.down;
    }

    public void SetDamage(int dmg)
    {
        damage = dmg;
    }
}
