using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : State
{
    [SerializeField]
    private float move_speed = 5f;
    [SerializeField]
    private float max_devieation = 2f;

    private Player_Script player;
    // Start is called before the first frame update
    void Start()
    {
        player = Player_Script.getInstance();
        if (Normal)
        {
            player.ChangeSprite(Normal);
        }
    }

    public override void move()
    {
        float hor = Input.GetAxis("Horizontal");
        if (transform.position.x >= -max_devieation && transform.position.x <= max_devieation)
        {
            this.gameObject.transform.Translate(new Vector3(hor, 0, 0) * move_speed * Time.deltaTime);
        }
        if (transform.position.x < -max_devieation)
        {
            transform.position = new Vector2(-max_devieation, transform.position.y);
        }
        if (transform.position.x > max_devieation)
        {
            transform.position = new Vector2(max_devieation, transform.position.y);
        }

    }
}
