namespace JMiles42
{
	public interface IJsonSaveable
	{
		/// <summary>
		/// Get the persistent data to save to disk, used with "SetLoadedData" to return to current state
		/// </summary>
		/// <returns>Data required to be saved to disk</returns>
		string GetSaveData();

		/// <summary>
		/// Set the data saved from "GetSaveData" usually loaded from disk
		/// </summary>
		/// <param name="json">The string to load from</param>
		void SetLoadedData(string json);
	}
}