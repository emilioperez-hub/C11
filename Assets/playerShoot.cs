using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class playerShoot : MonoBehaviour
{
    Color hitColor;
    private int bullets;
    [SerializeField]
    private InputAction reloadKey;

    private int maxBullets;
    //Publico para unity
    [SerializeField]
    private TMP_Text bulletText;
    [SerializeField]
    private ParticleSystem shootParticles;
    private void OnEnable()
    {
        reloadKey.Enable();
    }
    private void OnDisable()
    {
        reloadKey.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullets = 10;
        maxBullets = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadKey.triggered)
        {
            if (maxBullets > 0)
            {
                if (maxBullets < 10)
                {
                    bullets += maxBullets;
                    maxBullets = 0;
                }
                else
                {
                    bullets += 10;
                    maxBullets -= 10;
                }
            }

        }
        if (Mouse.current.leftButton.wasPressedThisFrame && bullets > 0)
        {
            RaycastHit hit;
            bullets--;
            UpdateBulletText();

            shootParticles.Play();
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if(hit.transform.CompareTag("Enemy"))
                {
                    hit.transform.GetComponent<enemyScript>().TakeDamage(5);
                }
                Debug.DrawRay(transform.position, transform.forward * hit.distance, hitColor);
                //Debug.Break();
            }
        }
    }
    //El ToString convierte numero a texto (string=cadena de texto)
    void UpdateBulletText()
    {
        bulletText.text = bullets.ToString() + "/" + maxBullets.ToString();
    }
    //FixedUpdate() es para fisicas
    private void FixedUpdate()
    {
    }
    public void AddBullets(int value)
    {
        maxBullets += value;
        UpdateBulletText();
    }
}
