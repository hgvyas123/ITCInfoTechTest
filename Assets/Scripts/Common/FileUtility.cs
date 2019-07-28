using System;
using System.IO;
using UnityEngine;

public class FileUtility 
{
    static string GetPersistentPath(string fileName)
    {
        return string.Format("{0}/{1}", Application.persistentDataPath, fileName);
    }

    /// <summary>
    /// Saves data in persistent path as per given file name
    /// </summary>
    /// <param name="fileName">File name in which we want to save data</param>
    /// <param name="data">Data which we want to save</param>
    public static void SaveToPersistentFile(string fileName,string data)
    {
        try
        {
            CustomDebug.Log("Saving data to file : " + GetPersistentPath(fileName));
            File.WriteAllText(GetPersistentPath(fileName), data);
            "Data Saved".ShowAsAlert();
        }
        catch(Exception ex)
        {
            CustomDebug.LogException("Custom exception while saving data : "+ex.Message + " to file named "+fileName);
            ex.Message.ShowAsAlert();
        }
    }

    /// <summary>
    /// Reads data from the persistent path as per given filename
    /// returns empty string if no file exists
    /// </summary>
    /// <param name="fileName">filename from which we want to read data</param>
    /// <returns></returns>
    public static string GetDataFromPersistentFile(string fileName)
    {
        string filePath = GetPersistentPath(fileName);
        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }
        else
        {
            CustomDebug.Log("Trying to read file which does not exist returning empty string");
            return string.Empty;
        }
    }
}
