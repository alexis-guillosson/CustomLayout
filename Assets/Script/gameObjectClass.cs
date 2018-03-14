using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameObjectClass : MonoBehaviour {

        public static GameObject CurrentlySelectedGameObject = null;

        private void OnMouseUpAsButton()
        {
            CurrentlySelectedGameObject = gameObject;
        }
    
}
