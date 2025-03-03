using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBug
{
	public interface ISaveable
	{
		string SaveId { get; }
		Dictionary<string, object> Save();
	}
}
