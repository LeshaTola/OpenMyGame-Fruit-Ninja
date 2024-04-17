using System.IO;
using UnityEngine;

namespace SaveLoad
{
	public class SaveLoadSystem
	{
		public static readonly string SAVE_PATH = $"{Application.dataPath}/Saves";
		public const string FILE_NAME = "/Save.txt";

		public static void Save(SaveData saveData)
		{
			if (!Directory.Exists(SAVE_PATH))
			{
				Directory.CreateDirectory(SAVE_PATH);
			}
			string json = JsonUtility.ToJson(saveData);
			File.WriteAllText(SAVE_PATH + FILE_NAME, json);
		}

		public static SaveData Load()
		{
			if (!File.Exists(SAVE_PATH + FILE_NAME))
			{
				return new SaveData();
			}

			string json = File.ReadAllText(SAVE_PATH + FILE_NAME);
			SaveData saveData = JsonUtility.FromJson<SaveData>(json);
			return saveData;
		}
	}
}
