
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    int selectedWeapon = 0;
    bool IsPressed = false;

    [SerializeField] GameObject inventory;

    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
            inventory.SetActive(false);
               
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
            inventory.SetActive(false);
               
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
            inventory.SetActive(false);
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
            inventory.SetActive(false);
              
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
        {
            selectedWeapon = 4;
            inventory.SetActive(false);
                
        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
        
        
    }
    void SelectWeapon()
    {
        Debug.Log("you are selecting");
        int i = 0;
        foreach (Transform weapon in transform)// only one of our weapons are enabled.
        {
            if(i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else weapon.gameObject.SetActive(false);
            i++;
        }
    }
    public int getSelectedWeapon()
    {
        return selectedWeapon;
    }
}
