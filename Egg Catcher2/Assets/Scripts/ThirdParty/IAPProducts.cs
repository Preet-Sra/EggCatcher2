using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
public class IAPProducts : MonoBehaviour
{
    public string grant500= "com.xyz.eggcatcher.500eggs";
    public string removeAds = "com.xyz.eggcatcher.removeads";
    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == grant500)
        {
            //grant 500 eggs
        }
        if (product.definition.id == removeAds)
        {
            PlayerPrefs.SetInt("AdsRemoved", 1);
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(product.definition.id + " failed becasuse: " + failureReason);
    }
}
