using UnityEngine;
using UnityEditor;
using System.IO;

public static class newHandleTextFile
{
    public static void WriteString(string path, int frame, float thetaPrime, bool isTurtle)
    {
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        string line = frame + " " + thetaPrime + " " + (isTurtle?1:0);
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
