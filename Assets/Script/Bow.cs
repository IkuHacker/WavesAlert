using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float lauchForce;
    public float destroyDelay;
    public int currentDamage;
    public float shootDelay = 1f; 
    private bool canShoot = true; 

    public Transform shotPoint;

    public int currentLevel;
    public Text lvlText;

    void Update()
    {
        lvlText.text = "LV :" + currentLevel.ToString();

        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;

        if (Input.GetMouseButtonUp(1) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        canShoot = false; // Disable shooting
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
