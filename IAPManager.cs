using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class IAPManager : MonoBehaviour, IStoreListener
{
	public static IAPManager instance;

	private static IStoreController storeController;
	private static IExtensionProvider extensionProvider;
	public string[] productIds;

	void PushReward(int index) {
		switch (index) {
		case 0:
			Debug.Log ("첫번째 상품 지급!");
			break;
		default:
			Debug.Log ("Index Error");
			break;
		}
	}


	void Success(string productId) {
		for (int i = 0; i < productIds.Length; i++) {
			if (string.Compare (productId, productIds [i],false) == 0) {
				PushReward (i);
			}
		}
	}

	void Fail() {
		// 구매실패

	}

	void Awake() {
		instance = this;
		DontDestroyOnLoad (gameObject);
	}
	void Start()
	{
		InitializePurchasing();
	}

	private bool IsInitialized()
	{
		return (storeController != null && extensionProvider != null);
	}

	public void InitializePurchasing()
	{
		if (IsInitialized())
			return;

		var module = StandardPurchasingModule.Instance();

		ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);
		foreach (string id in productIds) {
			builder.AddProduct(id, ProductType.Consumable, new IDs
				{
					{ id, AppleAppStore.Name },
					{ id, GooglePlay.Name },
				});
		}
		UnityPurchasing.Initialize(this, builder);
	}

	public void BuyProductInt(int type) {
		BuyProductID (productIds [type]);
	}

	public void BuyProductID(string productId)
	{
		try
		{
			if (IsInitialized())
			{
				Product p = storeController.products.WithID(productId);
				if (p != null && p.availableToPurchase)
				{
					storeController.InitiatePurchase(p);
				}
				else
				{
					Debug.Log("구매 실패 #1");
				}
			}
			else
			{
				Debug.Log("구매 실패 #2");
			}
		}
		catch (Exception e)
		{
			Debug.Log("구매 실패 #" + e);
		}
	}

	public void RestorePurchase()
	{
		if (!IsInitialized())
		{
			Debug.Log ("초기화 실패");
			return;
		}

		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
		{
			var apple = extensionProvider.GetExtension<IAppleExtensions>();

			apple.RestoreTransactions
			(
				(result) => { Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore."); }
			);
		}
		else
		{
			Debug.Log ("현재 플랫폼은 지원하지 않습니다.");
		}
	}

	public void OnInitialized(IStoreController sc, IExtensionProvider ep)
	{
		storeController = sc;
		extensionProvider = ep;
	}

	public void OnInitializeFailed(InitializationFailureReason reason)
	{
		Debug.Log ("초기화 실패 #" + reason);
	}
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
	{
		bool validPurchase = true;
		if (validPurchase) {
			for (int i = 0; i < productIds.Length; i++) {
				if (string.Compare (args.purchasedProduct.definition.id, productIds [i], false)) {
					PushReward (i);
				}
			}
		}
		return PurchaseProcessingResult.Complete;
	}

	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
	}
}
