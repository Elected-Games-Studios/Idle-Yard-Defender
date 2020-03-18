using UnityEngine;
public class MiniGun : Turret
{
    TargetingComputer targetingComputer;
    [SerializeField]
    MinigunShotPool minigunShotPool;
    protected float timeToShoot;
    public int STR { get; set; }

    protected override void Awake()
    {
        base.Awake();
        STR = 5;
        targetingComputer = GetComponent<TargetingComputer>();
        //List<Int64> tempArr = DataBaseTurrets.TurretStats(1, 2);
        //LVL = Convert.ToInt32(tempArr[0]);//LVL
        //ROF = Convert.ToInt32(tempArr[1]);//ROF
        //STR = Convert.ToInt32(tempArr[2]);//STR
        //CTU = Convert.ToInt32(tempArr[3]);//CTU
        //levelHandler is run to get lvl, str, rof, ctu
        //GetComponent<IHaveStats>();
        //get ROF based on level
        //get STR based onlevel
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