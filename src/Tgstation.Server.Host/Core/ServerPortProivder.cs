﻿using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Tgstation.Server.Host.Core
{
	/// <inheritdoc />
	sealed class ServerPortProivder : IServerPortProvider
	{
		/// <inheritdoc />
		public ushort HttpApiPort { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerPortProivder"/> <see langword="class"/>.
		/// </summary>
		/// <param name="configuration">The <see cref="IConfiguration"/> to use.</param>
		public ServerPortProivder(IConfiguration configuration)
		{
			if (configuration == null)
				throw new ArgumentNullException(nameof(configuration));

			var httpEndpoint = configuration
				.GetSection("Kestrel")
				.GetSection("Endpoints")
				.GetSection("Http")
				.GetSection("Url")
				.Value;

			HttpApiPort = GetPortFromAddress(httpEndpoint);
		}

		/// <summary>
		/// Convert a given <paramref name="address"/> to its port.
		/// </summary>
		/// <param name="address">The address <see cref="string"/>.</param>
		/// <returns>The parsed port.</returns>
		static ushort GetPortFromAddress(string address)
		{
			var splits = address.Split(":", StringSplitOptions.RemoveEmptyEntries);
			var portString = splits.Last();
			portString = portString.TrimEnd('/');
			if (!UInt16.TryParse(portString, out var result))
				throw new InvalidOperationException("Failed to parse HTTP API port!");
			return result;
		}
	}
}