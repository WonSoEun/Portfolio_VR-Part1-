using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Image hp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zombie"))
        {
            hp.fillAmount -= 1.0f / 5.0f;
        }
    }
}
