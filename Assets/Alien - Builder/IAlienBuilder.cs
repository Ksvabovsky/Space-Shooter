using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAlienBuilder
{

    public void BuildAlien(Vector2 position);

    public void SetAlienSprite();
    
    public void SetAlienBullet();

    public void AddAlienStrategy();

    public void SetAlienHealth();
}
