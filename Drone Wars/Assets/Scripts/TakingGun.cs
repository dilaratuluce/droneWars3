using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingGun : MonoBehaviour
{
    [SerializeField] GameObject childObject1;
    [SerializeField] GameObject childObject2;

    [SerializeField] GameObject parentObject;

    [SerializeField] bool gun1Shooted;
    [SerializeField] bool gun2Shooted;

    public bool getGun1Shooted()
    {
        return gun1Shooted;
    }
    public bool getGun2Shooted()
    {
        return gun2Shooted;
    }
    public void setGun1ShootedTrue()
    {
        gun1Shooted = true;
    }
    public void setGun2ShootedTrue()
    {
        gun2Shooted = true;
    }




    // Start is called before the first frame update
    void Update()
    {
        if (gun1Shooted)
        {
            Debug.Log("you win gun1");
            childObject1.transform.parent = parentObject.transform;
            childObject1.transform.localPosition = new Vector3(0.388f, -0.117f, 0.443f);
        }
        if (gun2Shooted)
        {
            Debug.Log("you win gun2");
            childObject2.transform.parent = parentObject.transform;
            childObject2.transform.localPosition = new Vector3(0.227f, -0.113f, 0.287f);
        }

    }

}
