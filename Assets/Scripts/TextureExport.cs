using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextureExport : MonoBehaviour
{
    public Texture2D texture1;
    public Texture2D texture2;

    // Start is called before the first frame update
    void Start()
    {
        byte[] bytes1 = texture1.EncodeToPNG();
        byte[] bytes2 = texture2.EncodeToPNG();
        var dirPath = "D:/testimages/";
        /*if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }*/
        File.WriteAllBytes(dirPath + "tex1" + ".png", bytes1);
        File.WriteAllBytes(dirPath + "tex2" + ".png", bytes2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
