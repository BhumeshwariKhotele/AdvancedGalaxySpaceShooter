using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleShot : MonoBehaviour
{
    [SerializeField]
    private float trippleShotPowerUp = 3.0f;
    
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
                player.TrippleShotPowerUp();
            }

            Destroy(this.gameObject);
        }


    }
}
