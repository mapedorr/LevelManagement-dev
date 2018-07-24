using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace LevelManagement.Data
{
	public class JsonSaver
	{
		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		private static readonly string _fileName = "LevelManagement.save";

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Gets the full path for the file to be used on saving and loading data.
		/// </summary>
		/// <returns>A string with the full path to the file.</returns>
		public static string GetSaveFileNamePath ()
		{
			return Application.persistentDataPath + "/" + _fileName;
		}
		/// <summary>
		/// Stores in a file the data in the received object as a JSON.
		/// </summary>
		/// <param name="data">Object with the data to store.</param>
		public void Save (SaveData data)
		{
			// parse to JSON the class with the data to store
			string json = JsonUtility.ToJson (data);
			// get the full path of the file to create with the data to save
			string saveFileNamePath = GetSaveFileNamePath ();
			// create the stream for storing the data
			FileStream filestream = new FileStream (saveFileNamePath, FileMode.Create);
			// the object created with using will be destroyed after the block of
			// code inside the curly braces has finished
			using (StreamWriter writer = new StreamWriter (filestream))
			{
				writer.Write (json);
			}
		}
		/// <summary>
		/// Loads the JSON stored in a file to the object received as parameter.
		/// </summary>
		/// <param name="data">Object to which the data in the file will be mapped to.</param>
		/// <returns></returns>
		public bool Load (SaveData data)
		{
			// get the full path of the file to read
			string loadFileNamePath = GetSaveFileNamePath ();
			// check if the file exists and load it if so
			if (File.Exists (loadFileNamePath))
			{
				// create the stream for storing the data
				using (StreamReader reader = new StreamReader (loadFileNamePath))
				{
					string json = reader.ReadToEnd ();
					JsonUtility.FromJsonOverwrite (json, data);
				}
				return true;
			}
			// the file couldn't be loaded
			return false;
		}
		/// <summary>
		/// Deletes the file in which the game is storing data.
		/// </summary>
		public void Delete ()
		{
			File.Delete (GetSaveFileNamePath ());
		}
	}

}