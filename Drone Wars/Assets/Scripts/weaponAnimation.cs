using UnityEngine;

public class weaponAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = Quaternion.identity;
    }

    public void Open()
    {
        LeanTween.rotateLocal(gameObject, new Vector3(gameParameters.weapon_rotation, 0, 0), gameParameters.weapon_animation_duration).setEaseOutBack().setOnComplete(Close);
    }

    public void Close()
    {
        LeanTween.rotateLocal(gameObject, Vector3.zero, gameParameters.weapon_animation_duration).setEaseInBack();
    }
}