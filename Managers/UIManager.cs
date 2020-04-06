using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //just pull updated data to be shown from elswhere 
    public static UIManager instance;
    public EpitomeSS saveState;
    [SerializeField]
    private Canvas uiCanavs;
    public Text text;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DataBaseManager.Starter();
        text = uiCanavs.GetComponent<Text>();
    }
    public void Update()
    {
        text.text = saveState.Cash.ToString();
    }
}
