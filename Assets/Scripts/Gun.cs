using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;
    public Transform launchPosition;
    private AudioSource audioSource;
    public bool isUpgraded;
    public float upgradeTime = 10.0f;
    private float currentTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //void fireBullet()
    //{
    //    // 1
    //    GameObject bullet = Instantiate(bulletPrefab) as GameObject;
    //    // 2
    //    bullet.transform.position = launchPosition.position;
    //    // 3
    //    bullet.GetComponent<Rigidbody>().velocity =
    //        transform.parent.forward * 100;

    //    audioSource.PlayOneShot(SoundManager.Instance.gunFire);
    //}
    void fireBullet()
    {
        Rigidbody bullet = createBullet();
        bullet.velocity =
            transform.parent.forward * 100;
        
        if (isUpgraded)
        {
            Rigidbody bullet2 = createBullet();
            bullet2.velocity =
                (transform.right + transform.forward / 0.5f) * 100;
            Rigidbody bullet3 = createBullet();
            bullet3.velocity =
                ((transform.right * -1) + transform.forward / 0.5f) * 100;
            
            audioSource.PlayOneShot(SoundManager.Instance.upgradedGunFire);
        }
        else
        {
            audioSource.PlayOneShot(SoundManager.Instance.gunFire);
        }
    }
    private Rigidbody createBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = launchPosition.position;
        return bullet.GetComponent<Rigidbody>();
    }
    public void UpgradeGun()
    {
        isUpgraded = true;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsInvoking("fireBullet"))
            {
                InvokeRepeating("fireBullet", 0f, 0.1f);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("fireBullet");
        }
        
        currentTime += Time.deltaTime;
        if (currentTime > upgradeTime && isUpgraded == true)
        {
            isUpgraded = false;
        }
    }
}
