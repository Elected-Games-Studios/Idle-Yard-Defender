using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>(); // if it doesnt exist find it
                if (instance == null)
                {
                    //if you can't find it make it 
                    instance = new GameObject("Spawned YardManager", typeof(GameManager)).GetComponent<GameManager>();
                }
            }
            return instance; // is that
        }
        set
        {
            instance = value;
        }
    }
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        LocalSaveEngine.LoadPlayer();
    }
}