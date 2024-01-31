using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncherAnimation : MonoBehaviour
{

    GrenadeLauncher grenadeLauncher;
    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = Quaternion.identity;
        grenadeLauncher = FindObjectOfType<GrenadeLauncher>();
    }

    public void Open()
    {
        LeanTween.rotateLocal(gameObject, new Vector3(gameParameters.weapon_rotation, 0, 0), grenadeLauncher.getReloadTime()).setEaseOutBack().setOnComplete(Close);
    }

    public void Close()
    {
        LeanTween.rotateLocal(gameObject, Vector3.zero, grenadeLauncher.getReloadTime()).setEaseInBack();
    }
}
