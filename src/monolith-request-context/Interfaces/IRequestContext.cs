namespace Roblox.RequestContext;

using System;
using System.Collections.Generic;

/// <summary>
/// Roblox Request Context.
/// </summary>
public interface IRequestContext
{
	/// <summary>
	/// Authenticated User ID.
	/// </summary>
	long? AuthenticatedUserID { get; }

	/// <summary>
	/// Request IP address.
	/// </summary>
	string RequestIPAddress { get; }

	/// <summary>
	/// User Agent.
	/// </summary>
	string UserAgent { get; }

	/// <summary>
	/// Age Bracket.
	/// </summary>
	AgeBracket? AgeBracket { get; }

	/// <summary>
	/// Age.
	/// </summary>
	int? Age { get; }

	/// <summary>
	/// Platform Type.
	/// </summary>
	string PlatformType { get; }

	/// <summary>
	/// Platform type ID.
	/// </summary>
	long? PlatformTypeID { get; }

	/// <summary>
	/// Environment Abbreviation.
	/// </summary>
	string EnvironmentAbbreviation { get; }

	/// <summary>
	/// Browser Tracker ID.
	/// </summary>
	long? BrowserTrackerID { get; }

	/// <summary>
	/// Browser Tracker Create Date.
	/// </summary>
	DateTime? BrowserTrackerCreateDate { get; }

	/// <summary>
	/// Client Version.
	/// </summary>
	string ClientVersion { get; }

	/// <summary>
	/// Operating System Type.
	/// </summary>
	string OperatingSystemType { get; }

	/// <summary>
	/// The Device Type.
	/// </summary>
	string DeviceType { get; }

	/// <summary>
	/// The Application Type.
	/// </summary>
	string ApplicationType { get; }

	/// <summary>
	/// Is the requestor RCC?
	/// </summary>
	bool? IsRCC { get; }

	/// <summary>
	/// Index the <see cref="IRequestContext"/> by a string key.
	/// </summary>
	/// <param name="key">The key.</param>
	/// <returns>The data.</returns>
	string this[string key] { get; }

	/// <summary>
	/// Convert the <see cref="IRequestContext"/> to <see cref="KeyValuePair{TKey, TValue}"/>
	/// </summary>
	/// <returns>The <see cref="KeyValuePair{TKey, TValue}"/>s</returns>
	ICollection<KeyValuePair<string, string>> ToKeyValuePairs();
}
