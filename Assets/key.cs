using Unity.VisualScripting;
using UnityEngine;

public class key : MonoBehaviour
{
    [SerializeField]
    private int id;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            //other.GetComponent<player>().hasKey = true;
            player p = other.GetComponent<player>();
            if (p != null)
            {
                p.PickUpKey(id);
            }

            transform.parent = other.transform;
        }
    }
}
// pridaj nieco co otvori dvere 
// maju sa otocit // iba ked mam kluc 

