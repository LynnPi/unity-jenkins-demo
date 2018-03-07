using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class BuildPlayerUtility : MonoBehaviour {

// <summary>  
/// 获取当前本地时间戳  
/// </summary>  
/// <returns></returns>        
public static long GetCurrentTimeUnix()  
{  
    TimeSpan cha = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));  
    long t = (long)cha.TotalSeconds;  
    return t;  
}  

	public static void BuildAndroid(){
		long startTime = GetCurrentTimeUnix();	
		BuildPipeline.BuildPlayer(new BuildPlayerOptions(){
			 scenes = new[]{"Assets/launcher.unity"},
			  locationPathName = string.Format( Application.dataPath, "../built/myapp") ,
			   target = BuildTarget.StandaloneWindows,
			    options = BuildOptions.None});

		long wasteSeconds = GetCurrentTimeUnix() - startTime;
		Debug.LogFormat("waste seconds:{0}s", wasteSeconds);	

	}
}
