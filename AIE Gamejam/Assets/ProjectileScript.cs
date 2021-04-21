using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile;
    public Transform FirePoint;
    public float projectileSpeed = 30;


    private Vector3 destination;
    private float timeToFire;

    private float fireRate = 1.7f;
    private float nextFire = 0f;
 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        nextFire = Time.time + fireRate;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);

        InstantiateProjectile(FirePoint);
    }

    void InstantiateProjectile(Transform firePoint)
       
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed; ;
    }
}
