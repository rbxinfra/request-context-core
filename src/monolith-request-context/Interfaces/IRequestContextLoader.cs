namespace Roblox.RequestContext;

/// <summary>
/// Request Context Loader.
/// </summary>
public interface IRequestContextLoader
{
	/// <summary>
	/// Get the current request context.
	/// </summary>
	/// <returns>The <see cref="IRequestContext"/></returns>
	IRequestContext GetCurrentContext();
}
