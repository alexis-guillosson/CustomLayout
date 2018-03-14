using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    #region Properties
    public GameObject myPrefab;
    #endregion

    #region Private Methods
    void Update ()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            AddCube();
        }  
    }   
    void AddCube()
    {
       Instantiate(myPrefab,transform);
    }
    #endregion
}