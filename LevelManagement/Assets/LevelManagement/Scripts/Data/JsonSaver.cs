using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
			// before getting the hash code, make its value empty on SaveData
			data.hashValue = String.Empty;
			// parse to JSON the class with the data to store
			string json = JsonUtility.ToJson (data);
			// get the hash value for the JSON (by converting itself)
			data.hashValue = GetSHA256 (json);
			// update the JSON so it now also has the hash value to store
			json = JsonUtility.ToJson (data);
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

					// check if the hash code in the file matches the expected value of
					// converting the values in the JSON with an empty hashValue
					if (JsonHashCodesMatches (json))
					{
						JsonUtility.FromJsonOverwrite (json, data);
					}
					else
					{
						Debug.LogWarning ("JsonSaver.Load ERROR: invalid hash code.");
					}
				}
				return true;
			}
			// the file couldn't be loaded
			return false;
		}

		/// <summary>
		/// Compares two hash codes to check if they are equal.
		/// </summary>
		/// <param name="json">The source JSON to use for compariton.</param>
		/// <returns>Returns true if the source JSON matches its original's version hash code.</returns>
		bool JsonHashCodesMatches (string json)
		{
			// make a copy of the received JSON
			SaveData tempSaveData = new SaveData ();
			JsonUtility.FromJsonOverwrite (json, tempSaveData);

			// copy the current hash code in the JSON
			string currentHashCode = tempSaveData.hashValue;

			// get the original hash code for the received JSON (that is with its
			// hashValue property empty)
			tempSaveData.hashValue = String.Empty;
			string tempJson = JsonUtility.ToJson (tempSaveData);
			string expectedHashCode = GetSHA256 (tempJson);

			// return the result of the comparition of hash codes
			return (expectedHashCode == currentHashCode);
		}

		/// <summary>
		/// Deletes the file in which the game is storing data.
		/// </summary>
		public void Delete ()
		{
			File.Delete (GetSaveFileNamePath ());
		}

		/// <summary>
		/// Returns a string converted to a SHA256 value.
		/// </summary>
		/// <param name="sourceText">The text to convert to SHA256.</param>
		/// <returns>The converted string.</returns>
		string GetSHA256 (string sourceText)
		{
			// convert the source text to an array of bytes
			byte[] textAsBytes = Encoding.UTF8.GetBytes (sourceText);

			using (SHA256Managed mySHA256 = new SHA256Managed ())
			{
				// convert the source text (in bytes) to a hash
				byte[] hashValue = mySHA256.ComputeHash (textAsBytes);

				// return the converted text
				return GetHexStringFromHash (hashValue);
			}
		}

		/// <summary>
		/// Converts and array of bytes to a hexadecimal string.
		/// </summary>
		/// <param name="hash">The array of bytes to convert.</param>
		/// <returns>A hexadecimal string.</returns>
		public string GetHexStringFromHash (byte[] hash)
		{
			// initialize the variable where the converted hash will be stored
			string hexString = String.Empty;

			foreach (byte b in hash)
			{
				// convert the byte to a string (with extra conditions):
				//   - x >> return an hexadecimal string
				//   - 2 >> of two digits
				hexString += b.ToString ("x2");
			}

			return hexString;
		}
	}
}