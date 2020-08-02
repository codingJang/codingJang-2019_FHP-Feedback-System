using UnityEngine;
using UnityEditor;
using System.IO;

public static class HandleTextFile
{
    public static void WriteString(string path, int frame, float theta, float thetaPrime, Vector3[] vectors)
    {
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        string line = "";
        line += frame + " ";
        line += theta + " ";
        line += thetaPrime + " ";
        for(int i=0;i<8;i++)
        {
            line += vectors[i].x + " " + vectors[i].y + " " + vectors[i].z + " ";
        }
        writer.WriteLine(line);
        writer.Close();
    }

    public static string ReadString(string path)
    {
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string line = reader.ReadLine();
        reader.Close();
        return line;
    }
}