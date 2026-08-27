using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private int ammountAmmo = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate (x, y ,z) y Time.deltaTime iguala el movimiento para todos los dispositivos.
        transform.Rotate(0, Time.deltaTime * 45, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.GetChild(0).GetComponent<playerShoot>().AddBullets(ammountAmmo);
            Destroy(this.gameObject);
        }
    }
}
