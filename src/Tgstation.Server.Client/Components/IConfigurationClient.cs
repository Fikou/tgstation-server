﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tgstation.Server.Api.Models;
using Tgstation.Server.Api.Rights;

namespace Tgstation.Server.Client.Components
{
	/// <summary>
	/// For managing <see cref="ConfigurationFile"/> files
	/// </summary>
	public interface IConfigurationClient : IRightsClient<ConfigurationRights>
	{
		/// <summary>
		/// List configuration files
		/// </summary>
		/// <param name="directory">The path to the directory to list files in</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="IReadOnlyList{T}"/> of <see cref="ConfigurationFile"/>s in the <paramref name="directory"/></returns>
		Task<IReadOnlyList<ConfigurationFile>> List(string directory, CancellationToken cancellationToken);

		/// <summary>
		/// Read a <see cref="ConfigurationFile"/> file
		/// </summary>
		/// <param name="file">The <see cref="ConfigurationFile"/> file to read</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task"/> representing the running operation</returns>
		Task Read(ConfigurationFile file, CancellationToken cancellationToken);

		/// <summary>
		/// Overwrite a <see cref="ConfigurationFile"/> file with integrity checks
		/// </summary>
		/// <param name="file">The <see cref="ConfigurationFile"/> file to write</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task"/> representing the running operation</returns>
		Task Write(ConfigurationFile file, CancellationToken cancellationToken);

		/// <summary>
		/// Create/overwrite a <see cref="ConfigurationFile"/> file
		/// </summary>
		/// <param name="file">The <see cref="ConfigurationFile"/> file to write</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task"/> representing the running operation</returns>
		Task Create(ConfigurationFile file, CancellationToken cancellationToken);

		/// <summary>
		/// Delete a <see cref="ConfigurationFile"/> file
		/// </summary>
		/// <param name="file">The <see cref="ConfigurationFile"/> file to delete</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task"/> representing the running operation</returns>
		Task Delete(ConfigurationFile file, CancellationToken cancellationToken);
	}
}