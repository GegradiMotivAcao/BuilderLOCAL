//BUILDER LOCAL LINHA DE COMANDO v.2000 AS MELHORES
// "C:\Program Files\Unity\Hub\Editor\2018.4.35f1\Editor\unity.exe" -quit -batchmode -projectPath "D:\Projetos\GEGRADI\MotivacaoUNITY" -executeMethod BuilderLinhaComando.PerformBuild

//"C:\Program Files\Unity\Hub\Editor\2018.4.35f1\Editor\unity.exe" -quit -batchmode -executeMethod BuilderLinhaComando.PerformBuild


// C# example.
using UnityEditor;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class BuilderLinhaComando : MonoBehaviour // n tinha mono
{   
    [SerializeField]
    public GameObject teste;

    [MenuItem("MyTools/Windows Build With Postprocess")]
    public static void PerformBuild ()
    {
        // Get filename.
        string path = EditorUtility.SaveFolderPanel("\\EXECUTAVEL","\\EXECUTAVEL","");
        string[] levels = new string[] { 
                            "Assets/Scenes/TelaInicial.unity",
                            "Assets/Scenes/Creditos.unity",
                            "Assets/Scenes/Meu.unity",
                            "Assets/Scenes/Builder/imagemCenaBuilder.unity"};
        // Build player.
        string date = DateTime.Now.ToString("HH:mm:ss");                   
        BuildPipeline.BuildPlayer(levels, path + "EXECUTAVEL\\MotivAcao.exe", BuildTarget.StandaloneWindows, BuildOptions.None);

        // Run the game (Process class from System.Diagnostics).
       /* Process proc = new Process();
        proc.StartInfo.FileName = path + "/testeLinhaComando.exe";
        proc.Start();*/
    }
}