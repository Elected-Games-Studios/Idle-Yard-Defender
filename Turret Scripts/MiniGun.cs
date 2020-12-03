using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
public class MiniGun : Turret
{
    TargetingComputerV2 targetingComputer;
    [SerializeField]
    protected float timeToShoot = .2f;
    public string Location { get; set; }
    public string Yard { get; set; }
    public List<Int64> tempArr = new List<long>();
    public void Awake()
    {
        targetingComputer = GetComponent<TargetingComputerV2>();
        Location = gameObject.name;
        Yard = SceneManager.GetActiveScene().name;
    }
    public void Start()
    {
        int intYard = Convert.ToInt32(Yard);
        int intLocation = Convert.ToInt32(Location);

       tempArr = DataBaseManager.TurretStats(intYard, intLocation);

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
        bullet.transform.position = shootPoint.transform.position;
        bullet.transform.rotation = shootPoint.transform.rotation;
        bullet.GetComponent<ParticleControll>().lifetime = 4f;
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<ParticleControll>().SpawnMuzzlePrefab();
        bullet.GetComponent<ParticleControll>().PassTarget(targetingComputer.Target);
        bullet.GetComponent<ParticleControll>().passdamage(STR);
    }
}
