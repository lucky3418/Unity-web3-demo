public static class Constant
{
    public enum Chain {
        Ethereum,
        Polygon
    }

    public static string ETH_MAINNET_CHAIN_ID = "1";
    public static string ETH_GOERLI_CHAIN_ID = "5";
    public static string MATIC_MAINNET_CHAIN_ID = "137";
    public static string MATIC_MUMBAI_CHAIN_ID = "80001";

    public static string ETH_MAINNET_RPC_URL = "";
    public static string ETH_GOERLI_RPC_URL = "";
    public static string MATIC_MAINNET_RPC_URL = "";
    public static string MATIC_MUMBAI_RPC_URL = "";

    public static string CHAIN_ID(Chain chain) {
        #if TESTNET
        if (chain == Chain.Polygon) {
            return MATIC_MUMBAI_CHAIN_ID;
        } else {
            return ETH_GOERLI_CHAIN_ID;
        }
        #else
        if (chain == Chain.Polygon) {
            return MATIC_MAINNET_CHAIN_ID;
        } else {
            return ETH_MAINNET_CHAIN_ID;
        }
        #endif
    }

    public static string RPC_URL(Chain chain) {
        #if TESTNET
        if (chain == Chain.Polygon) {
            return MATIC_MUMBAI_RPC_URL;
        } else {
            return ETH_GOERLI_RPC_URL;
        }
        #else
        if (chain == Chain.Polygon) {
            return MATIC_MAINNET_RPC_URL;
        } else {
            return ETH_MAINNET_RPC_URL;
        }
        #endif
    }
}
