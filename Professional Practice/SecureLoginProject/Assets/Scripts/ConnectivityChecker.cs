using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Provides methods to check internet connectivity.
/// </summary>
public static class ConnectivityChecker
{
    /// <summary>
    /// Checks if the internet is available.
    /// </summary>
    /// <returns>True if internet is available, otherwise false.</returns>
    public static bool IsInternetAvailable()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet connection available.");
            return false;
        }

        Debug.Log("Internet connection available.");
        return true;
    }
}
