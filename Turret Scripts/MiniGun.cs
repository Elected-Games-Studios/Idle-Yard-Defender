using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
public class MiniGun : Turret
{
    TargetingComputer targetingComputer;
    [SerializeField]
    MinigunShotPool minigunShotPool;
    protected float timeToShoot;
    private string Location
    {
        get => Location;
        set
        {
            Location = gameObject.name;
        }
    }
    private string Yard
    {
        get => Yard;
        set
        {
            Yard = SceneManager.GetActiveScene().name;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        targetingComputer = GetComponent<TargetingComputer>();
        List<Int64> tempArr = DataBaseTurrets.TurretStats(Yard, Location);
        LVL = Convert.ToInt64(tempArr[0]);
        ROF = Convert.ToInt64(tempArr[1]);
        STR = Convert.ToInt64(tempArr[2]);
        CTU = Convert.ToInt64(tempArr[3]);
    }
    public void Update() // SHOOT Weapon check based on a descending timer attached to update loop
    {
        timeToShoot -= Time.deltaTime;
        if (targetingComputer.targetAquired == true && timeToShoot <= 0)
            ShootWeapon();
    }
    void FixedUpdate() //Rotate body at target
    {
        if (targetingComputer.targetAquired == true && targetingComputer.Target != null)
        {
            rotateBody.LookAt(targetingComputer.Target.transform);
        }
    }
    protected void ShootWeapon() // really should be an event with delegates? not sure.. there are really no dependancies here.. idk
    {
        //reset shoot timer, grab bullet frm pool, set pos&rot to shootpoint pos&rot, set particle lifetime, enable bullet, instnt mzlfx, passtarget, passdmg
        timeToShoot = 1;
        var bullet = minigunShotPool.Get();
        bullet.transform.position = shootPoint.transform.position;
        bullet.transform.rotation = shootPoint.transform.rotation;
        bullet.GetComponent<ParticleControll>().lifetime = 4f;
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<ParticleControll>().SpawnMuzzlePrefab();
        bullet.GetComponent<ParticleControll>().PassTarget(targetingComputer.Target);
        bullet.GetComponent<ParticleControll>().passdamage(STR);
    }
}
