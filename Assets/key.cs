using Unity.VisualScripting;
using UnityEngine;

public class key : MonoBehaviour
{

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
            other.GetComponent<player>().hasKey = true;

            transform.parent = other.transform;
        }
    }
}
// pridaj nieco co otvori dvere 
// maju sa otocit // iba ked mam kluc 

