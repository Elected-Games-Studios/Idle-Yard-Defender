using UnityEngine;
public abstract class Turret : MonoBehaviour//, IHaveStats
{
    //[SerializeField]
    //protected GameObject bulletPrefab; hardcoded prefab prePooling
    [SerializeField]
    protected Transform rotateBody;
    [SerializeField]
    protected Transform shootPoint;
    public long STR { get; set; }
    public long LVL { get; set; }    
    public long ROF { get; set; }
    public long CTU { get; set; }
    //public int STR { get; set; } //strength or dmg amount
    //public int ROF { get; set; } //rate of fire
    //public int LVL { get; set; } //level 
    //public int CTU { get => _ctu; set => _ctu = value; } //cost to upgrade
    protected virtual void Awake()
    {

    }
    public enum TurretType
    {
        //handle turret level prefab variants
        //you'll have to actually make an enum class for this
    }
}