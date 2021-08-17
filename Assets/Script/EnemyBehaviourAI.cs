using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourAI: MonoBehaviour
{
    //a variable to enemy speed
    [SerializeField]
    private float enemySpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down
        transform.Translate(Vector3.down * Time.deltaTime);
    
        //when enemy off the screen on the bottom he needs to respawn with new random X position
        if(transform.position.y < -6.0f)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f),6.0f,0);
        }
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Laser")
        {
            if (collision.transform.parent != null)
            {
                Destroy(collision.transform.parent);
            }    
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag=="Player")
        {
            Player player = collision.GetComponent<Player>();
            if(player!=null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
    }
}
