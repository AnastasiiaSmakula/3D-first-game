using UnityEngine;
using UnityEngine.UI;

public class keyManager : MonoBehaviour
{
    [SerializeField]
    private Image[] keys;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Image key in keys)
        {
            key.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ShowKey(int number)
    {
        if (number > 0 && number <= keys.Length)
        {
            keys[number - 1].enabled = true;
        }
        else
        {
            Debug.LogWarning("Key number out of range: " + number);
        }

    }
}

// 1. Vyplnit tuto ShowKey funkciu aby ukazal spravny kluc (ked number je 1, tak prvy kluc, etc.)
// 2. a) V Player, reference na keyManager
// 2. b) V Player, na koliziu, zavolat ShowKey
// 3. Pridat kluce do sceny
// 4. Zmenit dvere, aby vsetky kluce s scene boli vyzadane na postup dalej