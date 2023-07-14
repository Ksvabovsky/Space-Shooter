using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour, ICreature
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Strategy strategy;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private int health;

    [SerializeField]
    private LevelMenager levelMenager;

    [SerializeField]
    private bool playing;

    private void Start()
    {
        levelMenager = LevelMenager.GetInstance();

        levelMenager.SignAlien(this);
    }

    private void Update()
    {
        if (playing)
        {
            strategy.Move();
            strategy.Shoot();
        }
    }

    public void GetDamage(int damage)
    {
        health = health - damage;

        if (health <= 0)
        {
            levelMenager.UnsignAlien(this);
            Destroy(gameObject);
        }   
    }

    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    public void SetHealth(int hp)
    {
        health = hp;
    }

    public void SetStrategy(Strategy s)
    {
        strategy = s;
    }

    public Transform GetFirepoint()
    {
        return firePoint;
    }

    public void StartPlaying()
    {
        playing = true;
    }
}
