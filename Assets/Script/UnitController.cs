using UnityEngine;

public class UnitController : MonoBehaviour
{
    public float hp;
    public bool player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            if (!player)
            {
                Destroy(gameObject);
            }
            else
            {
                //Debug.Log("DED");
            }
        }
    }
}
