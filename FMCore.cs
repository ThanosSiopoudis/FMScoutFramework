using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Entities;
using FMScoutFramework.Core.Entities.InGame;

namespace FMScoutFramework.Core
{
	public class FMCore : IDisposable
	{
		public GameManager gameManager = null;
		public ObjectManager objectManager = null;

		public DatabaseModeEnum DatabaseMode { get; private set; }

		public event Action GameLoaded = () => {};

		public FMCore(DatabaseModeEnum databaseMode)
		{
			DatabaseMode = databaseMode;
		}

		public FMCore ()
		{
			DatabaseMode = DatabaseModeEnum.Realtime;
		}

		#region Objects
		public IEnumerable<Continent> Continents { get { return GetListFromStore<Continent> (); } }
		public IEnumerable<City> Cities { get { return GetListFromStore<City> (); } }
		public IEnumerable<Club> Clubs { get { return GetListFromStore<Club> (); } }
		public IEnumerable<Nation> Nations { get { return GetListFromStore<Nation> (); } }
		public IEnumerable<Player> Players { get { return GetListFromStore<Player> (); } }
		public IEnumerable<Staff> Staff { get { return GetListFromStore<Staff> (); } }
		public IEnumerable<PlayerStaff> PlayerStaff { get { return GetListFromStore<PlayerStaff> (); } }

		private IQueryable<T> GetListFromStore<T>()
		{
			return ((Dictionary<int, T>)objectManager.ObjectStore [typeof(T)]).Values.AsQueryable ();
		}
		#endregion

		public void LoadData()
		{
			LoadData (false);
		}

		public void LoadData(bool refreshPersonCache)
		{
			CheckProcessAndGame ();
			LoadDataForCheckedGame (refreshPersonCache);
		}

		public bool CheckProcessAndGame()
		{
			if (gameManager == null) {
				gameManager = new GameManager ();
				gameManager.FMLoading = true;
				gameManager.findFMProcess ();
				gameManager.FMLoading = false;
			}

			return gameManager.FMLoaded;
		}

		public void LoadDataForCheckedGame(bool refreshPersonCache)
		{
			if (objectManager == null)
				objectManager = new ObjectManager (gameManager, DatabaseMode);

			objectManager.Load (refreshPersonCache);
			GameLoaded ();
		}

		public MetaDataCls MetaData { get { return new MetaDataCls (this, this.objectManager, gameManager); } }

		#region IDisposable Members
		public void Dispose()
		{
		}
		#endregion
	}

	public class MetaDataCls
	{
		private readonly Global glob;
		private readonly GameManager gameManager;

		internal MetaDataCls(FMCore fmCore, ObjectManager objectManager, GameManager gameManager)
		{
			this.gameManager = gameManager;
			glob = new Global (gameManager.Version);
		}

		public string CurrentVersion {
			get { return gameManager.Version.Description; }
		}

		public DateTime InGameDate {
			get { return glob.InGameDate; }
		}
	}
}

