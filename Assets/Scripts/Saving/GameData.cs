using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

[System.Serializable]
public class GameData
{
    public float speed;
    public Vector3 position;
    public Quaternion rotation;

    public GameData()
    {
        speed = 10f;
        position = Vector3.up;
        rotation = Quaternion.identity;
    }
}
