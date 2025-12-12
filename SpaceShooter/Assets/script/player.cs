using NUnit.Framework;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Damageble 
{   
   [SerializeField] float speed = 1;
   [SerializeField] private GameObject bullet;
   [SerializeField] float pewpewRate = 1;
   

   Vector3 position;
    void Start()
    {
       InvokeRepeating("PewPew",0 , pewpewRate); 
    }    
    void Update()
    {
        Movement();
    }
    void FixedUpdate()
    {
        Vector3 positionInBetween = Vector3.Lerp(transform.position,position,speed*Time.fixedDeltaTime);
        transform.position = positionInBetween;
        
    }
    void PewPew()
    {
        Instantiate(bullet, transform.position , Quaternion.identity);

    }
    void Movement()
    {
           Camera cam = Camera.main;

       
        if (Input.touchSupported && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(
                touch.position.x,
                touch.position.y,
                cam.nearClipPlane  
            ));

            worldPos.z = transform.position.z;

            position = worldPos;
        }

       
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                cam.nearClipPlane
            ));

            mousePos.z = transform.position.z;

            position = mousePos;
        }
        else
        {
            position = transform.position;
        }
    }
   


}
