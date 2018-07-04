using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPiggy.Core
{
	public interface IStorage
	{
		Task DeleteAsync(string fileName, string folderName);
		Task<IEnumerable<T>> GetAllAsync<T>(string folderName) where T : class;
		Task SaveAsync(string folderName, string fileName, object obj);
	}
}