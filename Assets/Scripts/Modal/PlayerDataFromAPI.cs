using Newtonsoft.Json;

[System.Serializable]
class PlayerDataFromAPI
{
    [JsonProperty("id")] public string pId { get; private set; }
    [JsonProperty("name")] public string pName { get; private set; }
    [JsonProperty("email")] public string pEmail { get; private set; }
}
