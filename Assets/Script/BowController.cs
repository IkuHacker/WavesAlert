using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BowController : MonoBehaviour
{
    public GameObject arrow;
    public float lauchForce;
    public float destroyDelay;
    public Transform shotPoint;
    public float sesibility;
    public int currentDamage;
    private Vector3 direction;
    public float shootDelay = 1f; // Delay before the next arrow can be shot
    private bool canShoot = true;

    public int currentLevel;
    public Text lvlText;

    void Update()
    { 
        lvlText.text = "LV :" + currentLevel.ToString();
        float horizontal = Input.GetAxis("HorizontalController");
        direction.x += horizontal * sesibility;

        transform.localRotation = Quaternion.Euler(0f, 0f, -direction.x);

        if (Input.GetButtonUp("Fire1") && canShoot) 
        {
            canShoot = false;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * lauchForce;
        Destroy(newArrow, destroyDelay);
        StartCoroutine(ResetShoot());
    }

    IEnumerator ResetShoot()
    {
        yield return new WaitForSeconds(shootDelay); // Wait for the specified delay
        canShoot = true; // Enable shooting
    }

    public void AddBonus(int lvl)
    {
        switch (lvl)
        {
            case 1:
                currentDamage = 1;
                break;
            case 2:
                currentDamage = 2;
                break;
            case 3:
                currentDamage = 3;
                break;
            default:
                currentDamage = 1;
                break;
        }

        currentLevel = lvl;
    }
}
