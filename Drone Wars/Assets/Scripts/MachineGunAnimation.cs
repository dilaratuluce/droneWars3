
using UnityEngine;

public class MachineGunAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    MachineGun my_gun;
    // Start is called before the first frame update
    void Start()
    {
        //transform.localRotation = Quaternion.identity;
        transform.localRotation = Quaternion.Euler(0, 180, 0);

        my_gun = FindObjectOfType<MachineGun>();
    }

    public void Open()
    {
        LeanTween.rotateLocal(gameObject, new Vector3(-gameParameters.weapon_rotation, 180, 0), my_gun.getReloadTime()).setEaseOutBack().setOnComplete(Close);
    }

    public void Close()
    {
        LeanTween.rotateLocal(gameObject, new Vector3(0, 180, 0), my_gun.getReloadTime()).setEaseInBack();
    }
}
