using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour
{
    public static FileManager fileManager;

    public static string saveFilePath;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (fileManager == null){
            transform.parent = null;
            fileManager = this;
            DontDestroyOnLoad(gameObject);
            FileSetup();
        } else {
            Destroy(gameObject);
        }
    }

    static void FileSetup(){
        
        saveFilePath = Application.dataPath + "/SaveFiles";
        
        if (!Directory.Exists(saveFilePath)){
            Directory.CreateDirectory(saveFilePath);
        }
    }
}
