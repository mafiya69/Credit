﻿/*
 * 
 * Copyright (c) 2015 Govind Sahai
 * Licensed Under MIT License
 * 
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace HelperLibrary
{
	public static partial class User
	{
		public static string folderPath= @"/mnt/sda5/Credit";
		public static string filePath=folderPath+@"/data.json";

		public static void ReadDataFromFile()
		{
			try
			{
				using(var streamRead=new StreamReader(filePath))
				{
					string json=streamRead.ReadToEnd();
					mainData=JsonConvert.DeserializeObject<List<UserData>>(json);
				}
				mainData.Sort();
			}

			catch
			{
				try
				{
					if (!File.Exists (filePath))
						File.Create (filePath);
				}
				catch(DirectoryNotFoundException) 
				{
					Directory.CreateDirectory (folderPath);
				}
				finally 
				{
					if (!File.Exists (filePath))
						File.Create (filePath);
				}
			}
			finally 
			{

			}
		}

		public static void WriteDataToFile()
		{
			try
			{
				mainData.Sort();
				string json=JsonConvert.SerializeObject(mainData.ToArray());
				File.WriteAllText(filePath,json);
			}
			catch 
			{

			}
			finally 
			{

			}
		}

		public static void WriteReadData()
		{
			WriteDataToFile ();
			ReadDataFromFile ();
		}
	}
}
