using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainPointer : MonoBehaviour
{
    public Image loadingImg;
    public TextMeshProUGUI bulletText;

    public AudioClip[] gunSound;
    private AudioSource _audioSource;

    public int maxBullet;
    private int nowBullet;

    private void Start()
    {
        maxBullet = 2;
        nowBullet = maxBullet;    
        _audioSource = GetComponent<AudioSource>();
        bulletText.text = nowBullet + " / " + maxBullet;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 500f))
        {
            if (hit.collider.CompareTag("Zombie") && nowBullet > 0)
            {
                loadingImg.fillAmount += 1.0f / 2 * Time.deltaTime;
                if (loadingImg.fillAmount == 1)
                {
                    nowBullet--;
                    bulletText.text = nowBullet + " / " + maxBullet;
                    _audioSource.PlayOneShot(gunSound[0]);

                    hit.collider.GetComponent<Animator>().SetTrigger("Die");
                    hit.collider.GetComponent<ZombieMove>().zombieSpeed = 0;
                    hit.collider.GetComponent<CapsuleCollider>().radius = 0;
                    Destroy(hit.collider.gameObject, 2.0f);
                    loadingImg.fillAmount = 0;

                    if (nowBullet == 0) StartCoroutine(ReloadGun());
                }
            }
            else
            {
                loadingImg.fillAmount = 0;
            }
        }
        else
        {
            loadingImg.fillAmount = 0;
        }
    }

    IEnumerator ReloadGun()
    {
        bulletText.text = "Reloading.....";
        yield return new WaitForSeconds(1.8f);
        _audioSource.PlayOneShot(gunSound[1]);
        nowBullet = maxBullet;
        bulletText.text = nowBullet + " / " + maxBullet;
    }
}

