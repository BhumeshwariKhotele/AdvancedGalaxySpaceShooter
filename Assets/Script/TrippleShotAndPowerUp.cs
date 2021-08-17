using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleShotAndPowerUp : MonoBehaviour
{
    [SerializeField]
    private float trippleShotPowerUp = 3.0f;
    [SerializeField]
    private int powerUpID;//0=trippleshot

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * trippleShotPowerUp);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collide"+collision.name);
        //access the player and make trippleshoot to true
        if(collision.tag=="Player")
        {
            Player player = collision.GetComponent<Player>();
            if(player!=null)
            {
                if(powerUpID==0)
                {
                    player.TrippleShotPowerUp();
                }
                else if (powerUpID == 1)
                {
                    player.TrippleShotPowerUp();
                }
                else if (powerUpID == 2)
                {
                     //enable for shield
                }

            }

            Destroy(this.gameObject);
        }


    }
}
