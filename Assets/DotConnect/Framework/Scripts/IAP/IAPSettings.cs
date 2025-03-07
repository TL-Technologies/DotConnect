﻿using GameBug;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class IAPSettings : SingletonScriptableObject<IAPSettings>
	{
		#region Classes

		[System.Serializable]
		public class ProductInfo
		{
			public string	productId;
			public bool		consumable;
		}

		#endregion

		#region Member Variables

		public List<ProductInfo> productInfos;

		#endregion

		#region Properties

		public static bool IsIAPEnabled
		{
			get
			{
				return true;
			}
		}

		#endregion
	}

