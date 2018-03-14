using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delete : MonoBehaviour {

    private Button _button = null;

    private void Awake()
    {
        _button.onClick.AddListener(() => Destroy(gameObjectClass.CurrentlySelectedGameObject));
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
}
   
