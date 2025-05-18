namespace Roblox.RequestContext;

using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Default implementation for <see cref="IRequestContext"/>
/// </summary>
/// <seealso cref="IRequestContext"/>
public class RobloxRequestContext : IRequestContext
{
    private readonly IDictionary<string, string> _ContextItems;

    internal static string AuthenticatedUserIdItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}authenticated-userid";
    internal static string RequestIPAddressItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}request-ip-address";
    internal static string UserAgentItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}user-agent";
    internal static string AgeBracketItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}age-bracket";
    internal static string AgeItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}age";
    internal static string PlatformTypeItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}platform-type";
    internal static string EnvironmentAbbreviationItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}environment-abbreviation";
    internal static string BrowserTrackerIdItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}browser-tracker-id";
    internal static string BrowserTrackerCreateDateItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}browser-tracker-create-date";
    internal static string ClientVersionItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}client-version";
    internal static string PlatformTypeIdItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}platform-type-id";
    internal static string OperatingSystemTypeItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}operating-system-type";
    internal static string DeviceTypeItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}device-type";
    internal static string ApplicationTypeItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}application-type";
    internal static string RCCItemKey => $"{RobloxRequestContextConstants.ContextItemKeyPrefix}rcc";

    /// <inheritdoc cref="IRequestContext.AuthenticatedUserID"/>
    public long? AuthenticatedUserID { get; private set; }

    /// <inheritdoc cref="IRequestContext.RequestIPAddress"/>
    public string RequestIPAddress => this[RequestIPAddressItemKey];

    /// <inheritdoc cref="IRequestContext.UserAgent"/>
    public string UserAgent => this[UserAgentItemKey];

    /// <inheritdoc cref="IRequestContext.AgeBracket"/>
    public AgeBracket? AgeBracket { get; private set; }

    /// <inheritdoc cref="IRequestContext.Age"/>
    public int? Age { get; private set; }

    /// <inheritdoc cref="IRequestContext.PlatformType"/>
    public string PlatformType => this[PlatformTypeItemKey];

    /// <inheritdoc cref="IRequestContext.PlatformTypeID"/>
    public long? PlatformTypeID { get; private set; }

    /// <inheritdoc cref="IRequestContext.EnvironmentAbbreviation"/>
    public string EnvironmentAbbreviation => this[EnvironmentAbbreviationItemKey];

    /// <inheritdoc cref="IRequestContext.BrowserTrackerID"/>
    public long? BrowserTrackerID { get; private set; }

    /// <inheritdoc cref="IRequestContext.BrowserTrackerCreateDate"/>
    public DateTime? BrowserTrackerCreateDate { get; private set; }

    /// <inheritdoc cref="IRequestContext.ClientVersion"/>
    public string ClientVersion => this[ClientVersionItemKey];

    /// <inheritdoc cref="IRequestContext.OperatingSystemType"/>
    public string OperatingSystemType => this[OperatingSystemTypeItemKey];

    /// <inheritdoc cref="IRequestContext.DeviceType"/>
    public string DeviceType => this[DeviceTypeItemKey];

    /// <inheritdoc cref="IRequestContext.ApplicationType"/>
    public string ApplicationType => this[ApplicationTypeItemKey];

    /// <inheritdoc cref="IRequestContext.IsRCC"/>
    public bool? IsRCC { get; private set; }

    /// <summary>
	/// Index the <see cref="IRequestContext"/> by a string key.
	/// </summary>
	/// <param name="key">The key.</param>
	/// <returns>The data.</returns>
    public string this[string key]
    {
        get
        {
            if (!_ContextItems.ContainsKey(key)) return null;
            return _ContextItems[key];
        }
    }

    /// <summary>
    /// Construct a new instance of <see cref="RobloxRequestContext"/>
    /// </summary>
    /// <param name="authenticatedUserID"><see cref="AuthenticatedUserID"/></param>
    /// <param name="requestIPAddress"><see cref="RequestIPAddress"/></param>
    /// <param name="userAgent"><see cref="UserAgent"/></param>
    /// <param name="ageBracket"><see cref="AgeBracket"/></param>
    /// <param name="age"><see cref="Age"/></param>
    /// <param name="platformType"><see cref="PlatformType"/></param>
    /// <param name="environmentAbbreviation"><see cref="EnvironmentAbbreviation"/></param>
    /// <param name="additionalItems">Any additional context items.</param>
    /// <param name="browserTrackerID"><see cref="BrowserTrackerID"/></param>
    /// <param name="browserTrackerCreateDate"><see cref="BrowserTrackerCreateDate"/></param>
    /// <param name="clientVersion"><see cref="ClientVersion"/></param>
    /// <param name="platformTypeId"><see cref="PlatformTypeID"/></param>
    /// <param name="operatingSystemType"><see cref="OperatingSystemType"/></param>
    /// <param name="deviceType"><see cref="DeviceType"/></param>
    /// <param name="applicationType"><see cref="ApplicationType"/></param>
    /// <param name="isRCC"><see cref="IsRCC"/></param>
    public RobloxRequestContext(
        long? authenticatedUserID = null,
        string requestIPAddress = null,
        string userAgent = null,
        AgeBracket? ageBracket = null,
        int? age = null,
        string platformType = null,
        string environmentAbbreviation = null,
        ICollection<KeyValuePair<string, string>> additionalItems = null,
        long? browserTrackerID = null,
        DateTime? browserTrackerCreateDate = null,
        string clientVersion = null,
        long? platformTypeId = null,
        string operatingSystemType = null,
        string deviceType = null,
        string applicationType = null,
        bool? isRCC = null
    )
    {
        AuthenticatedUserID = authenticatedUserID;
        AgeBracket = ageBracket;
        Age = age;
        BrowserTrackerID = browserTrackerID;
        BrowserTrackerCreateDate = browserTrackerCreateDate;
        PlatformTypeID = platformTypeId;
        IsRCC = isRCC;

        var contexItems = new Dictionary<string, string>
        {
            { AuthenticatedUserIdItemKey, authenticatedUserID?.ToString() },
            { RequestIPAddressItemKey, requestIPAddress },
            { UserAgentItemKey, userAgent },
            { AgeBracketItemKey, ageBracket?.ToString() },
            { AgeItemKey, age?.ToString() },
            { PlatformTypeItemKey, platformType },
            { PlatformTypeIdItemKey, platformTypeId?.ToString() },
            { EnvironmentAbbreviationItemKey, environmentAbbreviation },
            { BrowserTrackerIdItemKey, browserTrackerID?.ToString() },
            { BrowserTrackerCreateDateItemKey, browserTrackerCreateDate?.ToString() },
            { ClientVersionItemKey, clientVersion },
            { OperatingSystemTypeItemKey, operatingSystemType },
            { DeviceTypeItemKey, deviceType },
            { ApplicationTypeItemKey, applicationType },
            { RCCItemKey, isRCC.ToString() }
        };

        if (additionalItems != null)
            foreach (var item in additionalItems)
                contexItems[item.Key] = item.Value;

        _ContextItems = contexItems;
    }

    /// <summary>
    /// Construct a new instance of <see cref="RobloxRequestContext"/>
    /// </summary>
    /// <param name="authenticatedUserID"><see cref="AuthenticatedUserID"/></param>
    /// <param name="requestIPAddress"><see cref="RequestIPAddress"/></param>
    /// <param name="userAgent"><see cref="UserAgent"/></param>
    /// <param name="ageBracket"><see cref="AgeBracket"/></param>
    /// <param name="platformType"><see cref="PlatformType"/></param>
    /// <param name="environmentAbbreviation"><see cref="EnvironmentAbbreviation"/></param>
    /// <param name="additionalItems">Any additional context items.</param>
    /// <param name="browserTrackerID"><see cref="BrowserTrackerID"/></param>
    public RobloxRequestContext(
        long? authenticatedUserID = null,
        string requestIPAddress = null,
        string userAgent = null,
        AgeBracket? ageBracket = null,
        string platformType = null,
        string environmentAbbreviation = null,
        ICollection<KeyValuePair<string, string>> additionalItems = null,
        long? browserTrackerID = null
    )
    {
        AuthenticatedUserID = authenticatedUserID;
        AgeBracket = ageBracket;
        BrowserTrackerID = browserTrackerID;
        var contextItems = new Dictionary<string, string>
        {
            { AuthenticatedUserIdItemKey, authenticatedUserID?.ToString() },
            { RequestIPAddressItemKey, requestIPAddress },
            { UserAgentItemKey, userAgent },
            { AgeBracketItemKey, ageBracket?.ToString() },
            { PlatformTypeItemKey, platformType },
            { EnvironmentAbbreviationItemKey, environmentAbbreviation },
            { BrowserTrackerIdItemKey, browserTrackerID?.ToString() }
        };
        if (additionalItems != null)
            foreach (var item in additionalItems)
                contextItems[item.Key] = item.Value;
        _ContextItems = contextItems;
    }

    /// <summary>
    /// Construct a new instance of <see cref="RobloxRequestContext"/>
    /// </summary>
    /// <param name="authenticatedUserID"><see cref="AuthenticatedUserID"/></param>
    /// <param name="requestIPAddress"><see cref="RequestIPAddress"/></param>
    /// <param name="userAgent"><see cref="UserAgent"/></param>
    /// <param name="ageBracket"><see cref="AgeBracket"/></param>
    /// <param name="platformType"><see cref="PlatformType"/></param>
    /// <param name="environmentAbbreviation"><see cref="EnvironmentAbbreviation"/></param>
    /// <param name="additionalItems">Any additional context items.</param>
    /// <param name="browserTrackerID"><see cref="BrowserTrackerID"/></param>
    /// <param name="browserTrackerCreateDate"><see cref="BrowserTrackerCreateDate"/></param>
    /// <param name="clientVersion"><see cref="ClientVersion"/></param>
    public RobloxRequestContext(
        long? authenticatedUserID = null,
        string requestIPAddress = null,
        string userAgent = null,
        AgeBracket? ageBracket = null,
        string platformType = null,
        string environmentAbbreviation = null,
        ICollection<KeyValuePair<string, string>> additionalItems = null,
        long? browserTrackerID = null,
        DateTime? browserTrackerCreateDate = null,
        string clientVersion = null
    )
    {
        AuthenticatedUserID = authenticatedUserID;
        AgeBracket = ageBracket;
        BrowserTrackerID = browserTrackerID;
        var contextItems = new Dictionary<string, string>
        {
            { AuthenticatedUserIdItemKey, authenticatedUserID?.ToString() },
            { RequestIPAddressItemKey, requestIPAddress },
            { UserAgentItemKey, userAgent },
            { AgeBracketItemKey, ageBracket?.ToString() },
            { PlatformTypeItemKey, platformType },
            { EnvironmentAbbreviationItemKey, environmentAbbreviation },
            { BrowserTrackerIdItemKey, browserTrackerID?.ToString() },
            { BrowserTrackerCreateDateItemKey, browserTrackerCreateDate?.ToString() },
            { ClientVersionItemKey, clientVersion }
        };
        if (additionalItems != null)
            foreach (var item in additionalItems)
                contextItems[item.Key] = item.Value;
        _ContextItems = contextItems;
    }

    /// <summary>
    /// Construct a new instance of <see cref="RobloxRequestContext"/>
    /// </summary>
    /// <param name="contextItems">The raw request context items.</param>
    /// <exception cref="ArgumentNullException"><paramref name="contextItems"/> cannot be null.</exception>
    public RobloxRequestContext(IDictionary<string, string> contextItems)
    {
        _ContextItems = contextItems ?? throw new ArgumentNullException(nameof(contextItems));

        LoadProperties();
    }

    /// <inheritdoc cref="IRequestContext.ToKeyValuePairs"/>
    public ICollection<KeyValuePair<string, string>> ToKeyValuePairs() => _ContextItems.Select((x) => x).ToArray();

    private void LoadProperties()
    {
        if (!_ContextItems.Any()) return;
        if (_ContextItems.ContainsKey(AuthenticatedUserIdItemKey) && 
            _ContextItems[AuthenticatedUserIdItemKey] != null && 
            long.TryParse(_ContextItems[AuthenticatedUserIdItemKey], out var authenticatedUserID)
        ) AuthenticatedUserID = authenticatedUserID;

        if (_ContextItems.ContainsKey(AgeBracketItemKey) && 
            _ContextItems[AgeBracketItemKey] != null && 
            Enum.TryParse<AgeBracket>(_ContextItems[AgeBracketItemKey], out var ageBracket)
        ) AgeBracket = ageBracket;

        if (_ContextItems.ContainsKey(AgeItemKey) && 
            _ContextItems[AgeItemKey] != null && 
            int.TryParse(_ContextItems[AgeItemKey], out var age)
        ) Age = age;

        if (_ContextItems.ContainsKey(BrowserTrackerIdItemKey) && 
            _ContextItems[BrowserTrackerIdItemKey] != null && 
            long.TryParse(_ContextItems[BrowserTrackerIdItemKey], out var browserTrackerID)
        ) BrowserTrackerID = browserTrackerID;

        if (_ContextItems.ContainsKey(BrowserTrackerCreateDateItemKey) && 
            _ContextItems[BrowserTrackerCreateDateItemKey] != null && 
            DateTime.TryParse(_ContextItems[BrowserTrackerCreateDateItemKey], out var browserTrackerCreateDate)
        ) BrowserTrackerCreateDate = browserTrackerCreateDate;

        if (_ContextItems.ContainsKey(PlatformTypeIdItemKey) && 
            _ContextItems[PlatformTypeIdItemKey] != null && 
            long.TryParse(_ContextItems[PlatformTypeIdItemKey], out var platformTypeID)
        ) PlatformTypeID = platformTypeID;

        if (_ContextItems.ContainsKey(RCCItemKey) && 
            _ContextItems[RCCItemKey] != null && 
            bool.TryParse(_ContextItems[RCCItemKey], out var isRcc)
        ) IsRCC = isRcc;
    }
}
