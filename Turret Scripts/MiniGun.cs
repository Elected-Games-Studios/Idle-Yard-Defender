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
    public string Location { get; set; }
    public string Yard { get; set; }
    public void Awake()
    {
        Location = gameObject.name;
        Yard = SceneManager.GetActiveScene().name;
        int intYard = Convert.ToInt32(Yard);
        int intLocation = Convert.ToInt32(Location);
        targetingComputer = GetComponent<TargetingComputer>();
        List<Int64> tempArr = DataBaseManager.TurretStats(intYard, intLocation);

        LVL = (tempArr[0]);
        ROF = (tempArr[1]);
        STR = (tempArr[2]);
        CTU = (tempArr[3]);

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
