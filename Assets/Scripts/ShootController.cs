﻿using System;
using Assets.Scripts.Helpers;
using UnityEngine;


public class ShootController : MonoBehaviour {
        
    public GameObject shoot;
    public Transform shootSpawn;
    public float fireRate;

    private float nextFire = 0.0f;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shoot, shootSpawn.position, shootSpawn.rotation);
        }
    }    
}
