using UnityEngine;

public class Ammo : MonoBehaviour
{
    public enum pickupSelection
    {
        life,
        ammo,
        time
    }
    public pickupSelection currentSelection;

    [SerializeField]
    private int amountAmmo = 5;
    private int amountLife = 5;
    private int amountTime = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int value= Random.Range(0, 20);
        if (value > 12f)
            currentSelection = pickupSelection.time;
        else if (value > 8)
            currentSelection = pickupSelection.life;
        else
            currentSelection = pickupSelection.ammo;
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
            //switch lleva break al final para que no corra todo
            switch(currentSelection)
            {
                case pickupSelection.life:
                    other.GetComponent<playerHealth>().TakeDamage(-amountLife);
                    break;
                case pickupSelection.ammo:
                    other.transform.GetChild(0).GetComponent<playerShoot>().AddBullets(amountAmmo);
                    break;
                case pickupSelection.time:
                    gameManager.instance.AddTime(amountTime);
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
