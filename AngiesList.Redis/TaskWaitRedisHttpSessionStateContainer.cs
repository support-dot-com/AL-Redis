using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web;
using System.Threading.Tasks;

namespace AngiesList.Redis
{
	internal class TaskWaitRedisHttpSessionStateContainer : HttpSessionStateContainer
	{
		public RedisSessionItemHash SessionItems { get; private set; }

		public TaskWaitRedisHttpSessionStateContainer(string id,
													RedisSessionItemHash sessionItems,
													HttpStaticObjectsCollection staticObjects,
													int timeout,
													bool newSession,
													HttpCookieMode cookieMode,
													SessionStateMode mode,
													bool isReadonly)
			: base(id, sessionItems, staticObjects, timeout, newSession, cookieMode, mode, isReadonly)
		{
			SessionItems = sessionItems;
		}

		public bool WaitOnAllPersistent()
		{
			SessionItems.PersistChangedReferences();
      SessionItems.OneTimeResetTimeout();
			return Task.WaitAll(SessionItems.SetTasks.ToArray(), 1500);
		}
	}
}
