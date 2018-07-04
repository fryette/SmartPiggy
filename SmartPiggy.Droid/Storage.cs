using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCLStorage;
using SmartPiggy.Core;

namespace SmartPiggy.Droid
{
	public class Storage : IStorage
	{
		private readonly IFileSystem _fileSystem;

		public Storage()
		{
			_fileSystem = FileSystem.Current;
		}

		public async Task SaveAsync(string folderName, string fileName, object obj)
		{
			var folder = await _fileSystem.LocalStorage.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);

			var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
			await file.WriteAllTextAsync(JsonConvert.SerializeObject(obj));
		}

		public async Task<IEnumerable<T>> GetAllAsync<T>(string folderName) where T : class
		{
			var folder = await _fileSystem.LocalStorage.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);

			var files = await folder.GetFilesAsync();

			var result = new List<T>(files.Count);

			foreach (var file in files)
			{
				result.Add(JsonConvert.DeserializeObject<T>(await file.ReadAllTextAsync()));
			}

			return result;
		}

		public async Task DeleteAsync(string folderName, string fileName)
		{
			var folder = await _fileSystem.LocalStorage.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);

			var file = await folder.GetFileAsync(fileName);

			if (file != null)
			{
				await file.DeleteAsync();
			}
		}
	}
}
