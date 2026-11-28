using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public string name;

    public void Start()
    {
        if(name is string type)
        {
            Debug.Log(type.ToUpper());
        }
    }
}
