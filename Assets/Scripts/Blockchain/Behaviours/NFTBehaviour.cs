using System;
using UnityEngine;
using Web3Unity.Scripts.Library.Web3Wallet;
using Web3Unity.Scripts.Library.Ethers.Providers;

public class NFTBehaviour : MonoBehaviour
{
    async public void OnMintRaceTracks() {
        // change this if you are implementing your own sign in page
        Web3Wallet.url = "https://chainsafe.github.io/game-web3wallet/";
        string account = PlayerPrefs.GetString("Account");
        try {
            var txid = await AstroRaceTracks.Mint(account, new uint[]{2});
            print("txid: " + txid);

            var provider = new JsonRpcProvider(Constant.RPC_URL(AstroRaceTracks.CHAIN));
            var tx = await provider.GetTransactionReceipt(txid);
            if (tx != null) {
                // Debug Transaction code
                Debug.Log("Transaction Code: " + tx.Status);

                // Conditional Statement to check Transaction Status
                if (tx.Status.ToString() == "0") {
                    Debug.Log("Transaction has failed");
                } else if (tx.Status.ToString() == "1") {
                    Debug.Log("Transaction has been successful");
                }
            }
        } catch(Exception e) {
            Debug.LogWarning(e.Message);
        }
    }
}
