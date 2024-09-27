using System;
using System.IO;
using UnityEngine;

public class CarCollisionLogger : MonoBehaviour
{
    // CSV file path
    private string filePath;

    private void Start()
    {
        // Set the path to store the CSV file
        filePath = Application.dataPath + "/CarLog.csv";

        // If the file doesn't exist, create it and write the header
        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("TimeElapsed,Action");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Get the time elapsed since the start
        float timeElapsed = Time.time;
        LogAction(timeElapsed, "Collision Detected");
    }

    private void LogAction(float timeElapsed, string action)
    {
        // Append the data to the CSV file
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            // Write the time elapsed in seconds and action to the CSV
            writer.WriteLine($"{timeElapsed:F2},{action}"); // Format the time to 2 decimal places
        }
    }
}
