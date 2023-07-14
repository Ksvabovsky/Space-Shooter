using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPinkBuilder : MonoBehaviour, IAlienBuilder
{

    [SerializeField]
    private GameObject alienPrefab;

    [SerializeField]
    private Sprite alienSprite;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private int health;

    [SerializeField]
    private int damage;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int cooldown;

    [SerializeField]
    private GameObject Parent;

    //product
    private GameObject alienObject;
    private Alien alienScript;
    public void Awake()
    {
        Parent = GameObject.FindGameObjectWithTag("AlienParent");
    }
    public void BuildAlien(Vector2 position)
    {
        alienObject = Instantiate(alienPrefab, position, new Quaternion(0, 0, 0, 0), Parent.transform);
        alienScript = alienObject.GetComponent<Alien>();
        alienObject.transform.localScale = new Vector2(2f,2f);
    }

    public void SetAlienSprite()
    {
        alienScript.SetSprite(alienSprite);
    }

    public void SetAlienBullet()
    {
        BulletAbstractFactory BulletFactory = alienObject.AddComponent<BulletGreenFactory>();
        BulletFactory.SetBullet(bulletPrefab);
        BulletFactory.SetFirepoint(alienScript.GetFirepoint());
    }

    public void AddAlienStrategy()
    {
        Strategy alienStrategy = alienObject.AddComponent<StrategyMoveAndRapid>();
        alienStrategy.SetCooldown(cooldown);
        alienStrategy.SetBulletDetails(speed, damage);

        alienScript.SetStrategy(alienStrategy);
    }
    public void SetAlienHealth()
    {
        alienScript.SetHealth(health);
    }
}
