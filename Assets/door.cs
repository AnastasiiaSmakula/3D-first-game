using UnityEngine;

public class door : MonoBehaviour
{
    public Vector3 openOffset = new Vector3(3, 0, 0);
    private Vector3 closedPosition;
    private bool opened = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closedPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        player p = other.gameObject.GetComponent<player>();

        if (p == null) return;
        else if (p.hasKey == false) return;
        else if (opened == true) return;

        transform.position = closedPosition + openOffset;
        opened = true;
    }
}
