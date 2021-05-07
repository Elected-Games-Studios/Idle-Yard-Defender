using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class MiniGun : Turret
{
    TargetingComputer targetingComputer;
    [SerializeField] protected float timeToShoot = .2f;
    public string Location { get; set; }
    public string Yard { get; set; }
    public List<Int64> tempArr = new List<long>();

    public void Awake()
    {
        targetingComputer = GetComponent<TargetingComputer>();
        Location = gameObject.name;
        Yard = SceneManager.GetActiveScene().name;
    }

    public void Start() //for now we are handling a new turret based on gameobject.setactive but it will be when you pay for it with currency later. 
    {
        int intYard = Convert.ToInt32(Yard);
        int intLocation = Convert.ToInt32(Location);
        DataBaseManager.HandLeNewTurret(intYard, intLocation);
        tempArr = DataBaseManager.TurretStats(intYard, intLocation);
        if (tempArr[0] == 0)
        {
            tempArr = DataBaseManager.HandLeNewTurret(intYard, intLocation);
            LVL = (tempArr[0]);
            ROF = (tempArr[1]);
            STR = (tempArr[2]);
            CTU = (tempArr[3]);
        }
        else
        {
            //turretstats is run if there is already a turret there then assign the stats
            LVL = (tempArr[0]);
            ROF = (tempArr[1]);
            STR = (tempArr[2]);
            CTU = (tempArr[3]);
        }
    }

    public void Update() // SHOOT Weapon check based on a descending timer attached to update loop
    {
        timeToShoot -= Time.deltaTime;
        if (targetingComputer.targetAquired && timeToShoot <= 0)
            ShootWeapon();
    }

    void FixedUpdate() //Rotate body at target
    {
        if (targetingComputer.targetAquired && targetingComputer.Target != null)
        {
            rotateBody.LookAt(targetingComputer.Target.transform);
        }
    }

    protected void ShootWeapon()
    {
        //reset shoot timer, grab bullet frm pool, set pos&rot to shootpoint pos&rot, set particle lifetime, enable bullet, instnt mzlfx, passtarget, passdmg
        timeToShoot = .2f;
        var bullet = MinigunShotPool.Instance.Get();
        //cache particle control so you only get it once.
        bullet.transform.position = shootPoint.transform.position;
        bullet.transform.rotation = shootPoint.transform.rotation;
        bullet.GetComponent<ParticleControl>().lifetime = 4f;
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<ParticleControl>().SpawnMuzzlePrefab();
        bullet.GetComponent<ParticleControl>().PassTarget(targetingComputer.Target);
        bullet.GetComponent<ParticleControl>().passdamage(STR);
    }
}