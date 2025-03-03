﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

#pragma warning disable 0414 // Reason: Some inspector variables are only used in specific platforms and their usages are removed using #if blocks

	[RequireComponent(typeof(Button))]
	public class IAPProductButton : MonoBehaviour
	{
		#region Inspector Variables

		[SerializeField] private string	productId		= "";
		[SerializeField] private Text	titleText		= null;
		[SerializeField] private Text	descriptionText	= null;
		[SerializeField] private Text	priceText		= null;

		#endregion

		#region Private Methods

		private const string LogTag = "IAPProductButton";

		private Button button;

		#endregion

		#region Properties

		#endregion

		#region Unity Methods

		private void Start()
		{
			button = gameObject.GetComponent<Button>();

			button.onClick.AddListener(OnClicked);

			UpdateButton();
			
			IAPManager.Instance.OnInitializedSuccessfully	+= UpdateButton;
			IAPManager.Instance.OnProductPurchased			+= OnProductPurchased;
		}

		#endregion

		#region Private Methods

		private void OnClicked()
		{
			IAPManager.Instance.BuyProduct(productId);
		}

		private void OnProductPurchased(string id)
		{
			if (productId == id)
			{
				UpdateButton();
			}
		}

		private void UpdateButton()
		{
			button.interactable = false;

			if (IAPManager.Instance.IsInitialized)
			{
				Product product = IAPManager.Instance.GetProductInformation(productId);

				if (product == null)
				{
					Debug.Log("Product with id \"" + productId + "\" does not exist.");
				}
				else if (!product.availableToPurchase)
				{
					Debug.Log("Product with id \"" + productId + "\" is not available to purchase.");
				}
				else
				{
					button.interactable = true;

					SetupButton(product);
				}
			}
		}

		private void SetupButton(Product product)
		{
			if (IAPManager.Instance.IsProductPurchased(productId))
			{
				// If the product has been purchased then hide the button (Only for non-consumable products)
				gameObject.SetActive(false);
			}
			else
			{
				gameObject.SetActive(true);

				if (priceText != null)
				{
					priceText.text = product.metadata.localizedPriceString;
				}

				if (titleText != null)
				{
					#if UNITY_EDITOR
					titleText.text = productId;
					#else
					string title = product.metadata.localizedTitle;
					
					// Strip the "(App Name)" text that is included by google for some reason
					int startIndex	= title.LastIndexOf('(');
					int endIndex	= title.LastIndexOf(')');
					
					if (startIndex > 0 && endIndex > 0 && startIndex < endIndex)
					{
					title = title.Remove(startIndex, endIndex - startIndex + 1);
					title = title.Trim();
					}
					
					titleText.text = title;
					#endif
				}

				if (descriptionText != null)
				{
					descriptionText.text = product.metadata.localizedDescription;
				}
			}
		}
		#endregion
	}
