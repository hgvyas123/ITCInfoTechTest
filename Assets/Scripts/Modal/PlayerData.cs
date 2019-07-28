using Newtonsoft.Json;

[System.Serializable]
class PlayerData
{
    [JsonProperty("FirstName")] public string pFirstName { get; private set; }
    [JsonProperty("LastName")] public string pLastName { get; private set; }
    [JsonProperty("Email")] public string pEmail { get; private set; }
    [JsonProperty("Mobile")] public string pMobileNumber { get; private set; }

    public PlayerData(string firstName, string lastName, string Email, string mobileNumber)
    {
        pFirstName = firstName;
        pLastName = lastName;
        pEmail = Email;
        pMobileNumber = mobileNumber;
    }
}