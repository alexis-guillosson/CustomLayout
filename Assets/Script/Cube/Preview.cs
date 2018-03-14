//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//using UnityEngine.UI;

//public class Preview : MonoBehaviour {

//    public Camera cam;
    
   

//    // Use this for initialization
//    void Start () {
		
//	}
	


//    void Update()
//    {
//        if (Input.GetKeyDown("e"))
//        {
//            Debug.Log("Saving Screen Shot");
//            StartCoroutine(CreateLayerThumbnail());
//        }

//    }

//    IEnumerator CreateLayerThumbnail()
//    {
//        yield return new WaitForEndOfFrame();

//        // create a texture to pass to encoding
//        Texture2D texture = new Texture2D(cam.targetTexture.width, cam.targetTexture.height, TextureFormat.RGB24, false);

//        // Initialisation + render
//        cam.Render();
//        RenderTexture.active = cam.targetTexture;

//        // ajout buffer
//        texture.ReadPixels(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.height), 0, 0);

//        yield return 0;

//        texture.Apply();

//        yield return 0;

//        byte[] bytes = texture.EncodeToPNG();

//        // sauvegarde img
//        string imagePath = "#";
//        File.WriteAllBytes(FileManager.DATA_DIRECTORY + Path.DirectorySeparatorChar + imagePath, bytes);

//        //Destruction onrelease
//        DestroyObject(texture);
//    }
//}
