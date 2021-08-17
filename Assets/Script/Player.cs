using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variable to know power speed up if you collected the speed power up
    public bool isSpeedPowerUpActive = false;
    public bool CanTrippleShoot = false;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float canfire = 0f;
    [SerializeField] float fireRate = 0.25f;
    Vector3 directionKey;
    public GameObject TrippleLaserPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    
    // Update is called once per frame
    void Update()
    {
        //Player input movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //if speed power up enabled then move 2x faster
        if (isSpeedPowerUpActive == true)
        {

        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                Key(Vector3.right, horizontal);
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                Key(Vector3.up, vertical);
            }
        }
        //Player  Boundarys
        XYDirection(transform.position.x, transform.position.y);
    
        //Instantiating laser
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();

        }

    }

    
    private void Shoot()
    {
        if (Time.time > canfire)
        {
            //if tripple shot is true shoot three lasers if not one laser
            if(CanTrippleShoot==true)
            {
                Instantiate(TrippleLaserPrefab, transform.position, Quaternion.identity);

            }
            else
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            }

            canfire = Time.time + fireRate;
        }
    }

    
    private void XYDirection(float Xval, float Yval)
    {
        if (Yval > 0)
        {
            transform.position = new Vector3(Xval, 0, 0);
        }
        else if (Yval < -4.1f)
        {
            transform.position = new Vector3(Xval, -4.1f, 0);
        }
        if (Xval >= 10f)
        {
            transform.position = new Vector3(-10f, Yval, 0);
        }
        else if (Xval <= -10f)
        {
            transform.position = new Vector3(10f, Yval, 0);
        }
    }
    
    
    public void Key(Vector3 vector, float axis)
    {

        transform.Translate(vector * Time.deltaTime * moveSpeed * axis);
    }

    public void TrippleShotPowerUp()
    {
        CanTrippleShoot = true;
        StartCoroutine("TripleShotPowerDown");

    }
    
    public void SpeedPowerUpOn()
    {
        isSpeedPowerUpActive = true;
        StartCoroutine("SpeedPowerDown");

    }

    public IEnumerator TrippleShotPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        CanTrippleShoot = false;
    }

    public IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        CanTrippleShoot = false;
    }

}



