[System.Serializable]
/// <summary>
/// Represents the configuration settings for connecting to a MongoDB database.
/// </summary>
public class MongoDBConfig
{
    /// <summary>
    /// The username for authenticating with the MongoDB database.
    /// </summary>
    public string username;

    /// <summary>
    /// The password for authenticating with the MongoDB database.
    /// </summary>
    public string password;

    /// <summary>
    /// The name of the MongoDB database to connect to.
    /// </summary>
    public string databaseName;

    /// <summary>
    /// The name of the collection within the MongoDB database.
    /// </summary>
    public string collectionName;
}
