using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour, ICreature
{
    [SerializeField]
    private static Player_Script instance;

    public SpriteRenderer spriteRenderer;

    [SerializeField]
    private bool playing;

    [SerializeField]
    private State state;

    [SerializeField]
    private Transform firepoint;

    private BulletAbstractFactory factory;

    [SerializeField]
    private float cooldown;

    [SerializeField]
    private float reload;

    [SerializeField]
    private int damage;
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private int health;

    [SerializeField]
    private int currentHealth;

    public Slider hpBar;

    public Slider reloadBar;

    private void Awake()
    {
        instance = this;

        state = gameObject.AddComponent<NormalState>();

        factory = gameObject.AddComponent<BulletBlueFactory>();
        factory.SetBullet(bulletPrefab);
        factory.SetFirepoint(firepoint);

        currentHealth = health;

        hpBar.value = currentHealth/health *1f;

        playing = false;
    }

    public static Player_Script getInstance()
    {
        return instance;
    }

    private void FixedUpdate()
    {
        if (playing)
        {
            state.move();

            if (cooldown < 0f)
            {
                cooldown = 0f;
            }
            reloadBar.value = (reload - cooldown) / reload;

            if (cooldown >= 0f)
            {
                cooldown = cooldown - Time.deltaTime;
            }
        }
    }

    

    public void Shoot()
    {
        if(cooldown <= 0f && playing)
        {
            IBullet bullet = factory.MakeBullet();
            bullet.SetSpeed(speed);
            bullet.SetDamage(damage);
            cooldown = reload;
        }
    }

    public void GetDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        hpBar.value = (currentHealth *1f) / (health *1f);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeState(State s)
    {
        Destroy(state);
        state = s;
    }

    public void ChangeSprite(Sprite s)
    {
        spriteRenderer.sprite = s;
    }

    public void StartPlaying()
    {
        playing = true;
    }
}
