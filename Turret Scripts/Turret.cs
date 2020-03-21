using UnityEngine;
public abstract class Turret : MonoBehaviour//, IHaveStats
{
    [SerializeField]
    protected Transform rotateBody;
    [SerializeField]
    protected Transform shootPoint;
    public long STR { get; set; }
    public long LVL { get; set; }    
    public long ROF { get; set; }
    public long CTU { get; set; }
    public enum TurretType
    {
        //handle turret level prefab variants
        //you'll have to actually make an enum class for this
    }
}