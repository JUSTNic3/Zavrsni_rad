using UnityEngine;

public class KeyController : MonoBehaviour
{
    public bool isKeyCollected = false;

    public void CollectKey()
    {
        isKeyCollected = true;
    }
}
