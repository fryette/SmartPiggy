using System.Collections.Generic;
using System.Threading.Tasks;
using SmartPiggy.Core.Models;

namespace SmartPiggy.Core
{
	public class PurseManager
	{
		private readonly IStorage _storage;
		private const string PURSES_STRING = "PURSES";
		public PurseManager(IStorage storage)
		{
			_storage = storage;
		}

		public Task<IEnumerable<Purse>> LoadPursesAsync()
		{
			return _storage.GetAllAsync<Purse>(PURSES_STRING);
		}

		public Task RemovePurse(Purse purse)
		{
			return _storage.DeleteAsync(PURSES_STRING, purse.Name);
		}

		public Task SaveChanges(Purse purse)
		{
			return _storage.SaveAsync(PURSES_STRING, purse.Name, purse);
		}
	}
}
