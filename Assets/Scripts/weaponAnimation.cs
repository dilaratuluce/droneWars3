using UnityEngine;

public class weaponAnimation : MonoBehaviour
{

    gun my_gun;
    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = Quaternion.identity;
        my_gun = FindObjectOfType<gun>();
    }

    public void Open()
    {
        LeanTween.rotateLocal(gameObject, new Vector3(gameParameters.weapon_rotation, 0, 0), my_gun.getReloadTime()).setEaseOutBack().setOnComplete(Close);
    }

    public void Close()
    {
        LeanTween.rotateLocal(gameObject, Vector3.zero, my_gun.getReloadTime()).setEaseInBack();
    }
}