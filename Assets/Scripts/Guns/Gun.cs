using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float BulletSpeed = 20f;
    public float ShotPeriod = 0.2f;

    public GameObject BulletPrefab;
    public GameObject Flash;

    public Transform SpawnPosition;

    public AudioSource ShotSound;

    public ParticleSystem SmokeEffect;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_timer > ShotPeriod)
            {
                _timer = 0;
                Shot();
                      
            }
        }
    }

    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, SpawnPosition.position, SpawnPosition.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;
        ShotSound.Play();
        Flash.SetActive(true);
        Invoke("HideFlash", 0.12f);
        SmokeEffect.Play();
    }
    private void HideFlash()
    {
        Flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public virtual void AddBullets(int BulletsCount){
    }
}
