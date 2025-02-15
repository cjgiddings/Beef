﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Beef.Caching.Policy
{
    /// <summary>
    /// The <see cref="ICachePolicy"/> manager enables the centralised management of <see cref="ICachePolicy"/> caches.
    /// </summary>
    public class CachePolicyManager : IDisposable
    {
        private static readonly Lazy<CachePolicyManager> _fallback = new(() => new CachePolicyManager());
        private static readonly Random _random = new();

        private ICachePolicy _defaultPolicy = new NoExpiryCachePolicy();
        private readonly ConcurrentDictionary<string, ICachePolicy> _policies = new();
        private readonly ConcurrentDictionary<string, ICacheCore> _registered = new();
        private readonly object _lock = new();
        private Timer? _timer;
        private ILogger? _logger;
        private TimeSpan _period;
        private bool _disposed;

        /// <summary>
        /// Gets a <see cref="TimeSpan"/> set to one minute.
        /// </summary>
        public static TimeSpan OneMinute { get; } = new TimeSpan(0, 1, 0);

        /// <summary>
        /// Gets a <see cref="TimeSpan"/> set to five minutes.
        /// </summary>
        public static TimeSpan FiveMinutes { get; } = new TimeSpan(0, 5, 0);

        /// <summary>
        /// Gets a <see cref="TimeSpan"/> set to ten minutes.
        /// </summary>
        public static TimeSpan TenMinutes { get; } = new TimeSpan(0, 10, 0);

        /// <summary>
        /// Gets a <see cref="TimeSpan"/> set to one hour.
        /// </summary>
        public static TimeSpan OneHour { get; } = new TimeSpan(1, 0, 0);

        /// <summary>
        /// Gets a <see cref="TimeSpan"/> set to one day.
        /// </summary>
        public static TimeSpan OneDay { get; } = new TimeSpan(1, 0, 0, 0);

        /// <summary>
        /// Gets the current <see cref="CachePolicyManager"/> (uses the <see cref="ExecutionContext.GetService{T}"/> to get/instantiate).
        /// </summary>
        public static CachePolicyManager Current => ExecutionContext.GetService<CachePolicyManager>(throwExceptionOnNull: false) ?? _fallback.Value;

        /// <summary>
        /// Get or sets the default <see cref="ICachePolicy"/> for use when a policy has not previously been set for a <see cref="Type"/>.
        /// </summary>
        /// <remarks>Where not specified a <see cref="NoExpiryCachePolicy"/> is used as the default.</remarks>
        public ICachePolicy DefaultPolicy
        {
            get => _defaultPolicy;
            set => _defaultPolicy = Check.NotNull(value, nameof(value));
        }

        /// <summary>
        /// Resets the <see cref="ICachePolicy"/> manager to an initial state by <see cref="Unregister(string)">unregistering</see> all previously registered caches.
        /// </summary>
        /// <remarks><i>Caution:</i> where a cache has already been instantied with a policy this will be unregistered; this may result in unintended consequences.</remarks>
        public void Reset()
        {
            foreach (var r in _policies.ToArray())
            {
                Unregister(r.Key);
            }
        }

        /// <summary>
        /// Registers a <see cref="ICacheCore"/> to enable advanced support; i.e. automatic cache flush.
        /// </summary>
        /// <param name="cache">The <see cref="ICacheCore"/> to register.</param>
        /// <param name="overridePolicyKey">The policy key override (defaults to <see cref="ICacheCore.PolicyKey"/>).</param>
        /// <remarks>All <see cref="CacheCoreBase"/> instances are automatically registered.</remarks>
        public void Register(ICacheCore cache, string? overridePolicyKey = null)
        {
            if (cache == null)
                throw new ArgumentNullException(nameof(cache));

            if (!_registered.TryAdd(overridePolicyKey ?? cache.PolicyKey, cache))
                throw new InvalidOperationException("Only a single instance of a Cache PolicyKey can be registered.");
        }

        /// <summary>
        /// Gets the <see cref="Register(ICacheCore, string)">registered</see> <see cref="ICacheCore"/> for the specified <paramref name="policyKey"/>.
        /// </summary>
        /// <param name="policyKey">The cache policy key.</param>
        /// <returns>The <see cref="ICacheCore"/> where found; otherwise, <c>null</c>.</returns>
        public ICacheCore GetRegistered(string policyKey)
        {
            if (string.IsNullOrEmpty(policyKey))
                throw new ArgumentNullException(nameof(policyKey));

            _registered.TryGetValue(policyKey, out ICacheCore cv);
            return cv;
        }

        /// <summary>
        /// Unregisters (removes) the previously <see cref="Register(ICacheCore, string)">registered</see> <see cref="ICacheCore"/> and corresponding policy.
        /// </summary>
        /// <param name="policyKey">The cache policy key.</param>
        /// <remarks>The underlying cache will be flushed (see <see cref="ICacheCore.Flush(bool)"/>) to remove all existing cached data.
        /// <para><i>Caution:</i> where a cache has already been instantied with a policy this will be unregistered; this may result in unintended consequences.</para></remarks>
        public void Unregister(string policyKey)
        {
            if (string.IsNullOrEmpty(policyKey))
                return;

            _registered.TryRemove(policyKey, out ICacheCore cv);
            _policies.TryRemove(policyKey, out _);

            if (cv != null)
            {
                cv.Flush(true);
                cv.Dispose();
            }
        }

        /// <summary>
        /// Sets the <paramref name="policy"/> for a specified key.
        /// </summary>
        /// <param name="policyKey">The cache policy key.</param>
        /// <param name="policy">The <see cref="ICachePolicy"/>.</param>
        public void Set(string policyKey, ICachePolicy policy)
        {
            if (string.IsNullOrEmpty(policyKey))
                throw new ArgumentNullException(nameof(policyKey));

            if (policy == null)
                throw new ArgumentNullException(nameof(policy));

            _policies.AddOrUpdate(policyKey, policy, (k, p) => policy);
        }

        /// <summary>
        /// Gets the <see name="ICachePolicy"/> for a specified key (uses <see cref="DefaultPolicy"/> where not found).
        /// </summary>
        /// <param name="policyKey">The cache policy key.</param>
        /// <param name="autoCreate"><c>true</c> indicates to automatically create the policy where not found; otherwise, <c>false</c> will result in a <c>null</c> response where not found.</param>
        /// <returns>The <see cref="ICachePolicy"/>.</returns>
        public ICachePolicy Get(string policyKey, bool autoCreate = true)
        {
            if (autoCreate)
                return _policies.GetOrAdd(policyKey, (ICachePolicy)_defaultPolicy.Clone());
            else
            {
                _policies.TryGetValue(policyKey, out ICachePolicy policy);
                return policy;
            }
        }

        /// <summary>
        /// Sets the <see name="ICachePolicy"/> for the <see cref="DefaultPolicy"/> and <see cref="Type">Types</see> defined within the configuration.
        /// </summary>
        /// <param name="config">The <see cref="CachePolicyConfig"/>.</param>
        public void SetFromCachePolicyConfig(CachePolicyConfig config) => CachePolicyConfig.SetCachePolicyManager(this, config);

        /// <summary>
        /// Starts the timer to manage the frequency in which expired caches will be flushed (see <see cref="CacheCoreBase.OnFlushCache"/>).
        /// </summary>
        /// <param name="dueTime">The amount of time to delay before <see cref="Flush"/> is invoked for the first time.</param>
        /// <param name="period">The time interval between subsequent invocations of <see cref="Flush"/>.</param>
        /// <param name="logger">The <see cref="ILogger{CachePolicyManager}"/>.</param>
        /// <remarks>This can only be started once; use <see cref="StopFlushTimer"/> to restart.</remarks>
        public void StartFlushTimer(TimeSpan dueTime, TimeSpan period, ILogger<CachePolicyManager>? logger)
        {
            lock (_lock)
            {
                if (_timer != null)
                    return;

                _period = period;
                _logger = logger;
                _logger?.LogDebug($"{nameof(CachePolicyManager)} flush timer started. Timer first/interval {dueTime}/{period}.");
                _timer = new Timer(TimerElapsed, null, dueTime, period);
            }
        }

        /// <summary>
        /// Timer has elapsed so the cache should be flushed.
        /// </summary>
        private void TimerElapsed(Object stateInfo)
        {
            lock (_lock)
            {
                _logger?.LogTrace($"{nameof(CachePolicyManager)} flush triggered by timer.");
                _timer?.Change(Timeout.Infinite, Timeout.Infinite);
            }

            Flush();

            lock (_lock)
            {
                if (_timer != null)
                {
                    _logger?.LogTrace($"{nameof(CachePolicyManager)} execution completed. Retry in {_period}.");
                    _timer.Change(_period, _period);
                }
            }
        }

        /// <summary>
        /// Stops the timer managing the frequency in which expired caches will be flushed.
        /// </summary>
        public void StopFlushTimer()
        {
            lock (_lock)
            {
                _logger?.LogDebug($"{nameof(CachePolicyManager)} flush timer stopped.");
                _timer?.Change(Timeout.Infinite, Timeout.Infinite);
                _timer = null;
            }
        }

        /// <summary>
        /// Flushes all registered (see <see cref="Register(ICacheCore, string)"/>) caches where they have expired (see <see cref="ICachePolicy.IsExpired"/>).
        /// </summary>
        /// <param name="logger">Optional <see cref="ILogger"/> to log debug messages where flushing underlying cache.</param>
        public void Flush(ILogger? logger = null) => EnactFlush(false, logger ?? _logger);

        /// <summary>
        /// Flushes all registered (see <see cref="Register(ICacheCore, string)"/>) caches regardless of expiry (see <see cref="ICachePolicy.IsExpired"/>).
        /// </summary>
        /// <param name="logger">Optional <see cref="ILogger"/> to log debug messages where flushing underlying cache.</param>
        public void ForceFlush(ILogger? logger = null) => EnactFlush(true, logger ?? _logger);

        /// <summary>
        /// Enacts the requested flush.
        /// </summary>
        private void EnactFlush(bool ignoreExpiry, ILogger? logger)
        {
            foreach (var cache in _registered.ToArray())
            {
                var policy = Get(cache.Key);
                if (ignoreExpiry || policy.IsExpired)
                {
                    policy.Refresh();
                    cache.Value.Flush(ignoreExpiry);

                    if (policy.Hits > 0 && logger != null)
                        logger?.LogDebug($"nameof(CachePolicyManager) flush '{cache.Key}' {(ignoreExpiry ? "was forced" : "has expired")} (Hits: {policy.Hits}).");
                }
            }
        }

        /// <summary>
        /// Gets an array of all policies.
        /// </summary>
        /// <returns>An array of policies.</returns>
        public KeyValuePair<string, ICachePolicy>[] GetPolicies() => _policies.Select(x => new KeyValuePair<string, ICachePolicy>(x.Key, x.Value)).ToArray();

        /// <summary>
        /// Add a randomised <paramref name="offset"/> (up to the specified value) to the <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The base time to add the offset to.</param>
        /// <param name="offset">The maximum offset time to add.</param>
        /// <returns>The updated <see cref="DateTime"/> value.</returns>
        public static DateTime AddRandomizedOffsetToTime(DateTime time, TimeSpan? offset)
        {
            if (offset.HasValue)
                return time.AddMilliseconds(_random.NextDouble() * offset.Value.TotalMilliseconds);
            else
                return time;
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="CachePolicyManager"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    foreach (var cache in _registered.ToArray())
                    {
                        Unregister(cache.Key);
                    }
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Closes and disposes the <see cref="CachePolicyManager"/>.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}