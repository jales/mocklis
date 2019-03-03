// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogContext.cs">
//   Copyright © 2019 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Steps.Log
{
    #region Using Directives

    using System;
    using Mocklis.Core;

    #endregion

    /// <summary>
    ///     Interface that captures all of the types of log messages that can be generated by a 'log' step.
    /// </summary>
    public interface ILogContext
    {
        #region Event logs

        /// <summary>
        ///     Logs the fact that an event handler is being added.
        /// </summary>
        /// <typeparam name="THandler">The event handler type for the event.</typeparam>
        /// <param name="mockInfo">Information about the mock through which the event handler is being added.</param>
        /// <param name="value">The event handler.</param>
        void LogBeforeEventAdd<THandler>(IMockInfo mockInfo, THandler value) where THandler : Delegate;

        /// <summary>
        ///     Logs the fact that an event handler has been added.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the event handler is being added.</param>
        void LogAfterEventAdd(IMockInfo mockInfo);

        /// <summary>
        ///     Logs the fact that adding an event handler threw an exception.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the event handler is being added.</param>
        /// <param name="exception">The exception that was thrown.</param>
        void LogEventAddException(IMockInfo mockInfo, Exception exception);

        /// <summary>
        ///     Logs the fact that an event handler is being removed.
        /// </summary>
        /// <typeparam name="THandler">The event handler type for the event.</typeparam>
        /// <param name="mockInfo">Information about the mock through which the event handler is being removed.</param>
        /// <param name="value">The event handler.</param>
        void LogBeforeEventRemove<THandler>(IMockInfo mockInfo, THandler value) where THandler : Delegate;

        /// <summary>
        ///     Logs the fact that av event handler has been removed.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the event handler is being removed.</param>
        void LogAfterEventRemove(IMockInfo mockInfo);

        /// <summary>
        ///     Logs the fact that removing an event handler threw an exception.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the event handler is being removed.</param>
        /// <param name="exception">The exception that was thrown.</param>
        void LogEventRemoveException(IMockInfo mockInfo, Exception exception);

        #endregion

        #region Indexer logs

        /// <summary>
        ///     Logs the fact that an indexer is being read from.
        /// </summary>
        /// <typeparam name="TKey">The type of the indexer key.</typeparam>
        /// <param name="mockInfo">Information about the mock through which the value is read.</param>
        /// <param name="key">The indexer key used.</param>
        void LogBeforeIndexerGet<TKey>(IMockInfo mockInfo, TKey key);

        /// <summary>
        ///     Logs the fact that an indexer has been read from.
        /// </summary>
        /// <typeparam name="TValue">The type of the indexer value.</typeparam>
        /// ram>
        /// <param name="mockInfo">Information about the mock through which the value is read.</param>
        /// <param name="value">The value that was read.</param>
        void LogAfterIndexerGet<TValue>(IMockInfo mockInfo, TValue value);

        /// <summary>
        ///     Logs the fact that reading from an indexer threw an exception.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the value is read.</param>
        /// <param name="exception">The exception that was thrown.</param>
        void LogIndexerGetException(IMockInfo mockInfo, Exception exception);

        /// <summary>
        ///     Logs the fact that an indexer is being written to.
        /// </summary>
        /// <typeparam name="TKey">The type of the indexer key.</typeparam>
        /// <typeparam name="TValue">The type of the indexer value.</typeparam>
        /// <param name="mockInfo">Information about the mock through which the value is written.</param>
        /// <param name="key">The indexer key used.</param>
        /// <param name="value">The value being written.</param>
        void LogBeforeIndexerSet<TKey, TValue>(IMockInfo mockInfo, TKey key, TValue value);

        /// <summary>
        ///     Logs the fact that and indexer has been written to.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the value is written.</param>
        void LogAfterIndexerSet(IMockInfo mockInfo);

        /// <summary>
        ///     Logs the fact that writing to an indexer threw an exception.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the value is written.</param>
        /// <param name="exception">The exception that was thrown.</param>
        void LogIndexerSetException(IMockInfo mockInfo, Exception exception);

        #endregion

        #region Method logs

        /// <summary>
        ///     Logs the fact that a method is being called without parameters.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the method is called.</param>
        void LogBeforeMethodCallWithoutParameters(IMockInfo mockInfo);

        /// <summary>
        ///     Logs the fact that a method is being called without parameters.
        /// </summary>
        /// <typeparam name="TParam">The method parameter type.</typeparam>
        /// <param name="mockInfo">Information about the mock through which the method is called.</param>
        /// <param name="param">The parameters passaed to the method.</param>
        void LogBeforeMethodCallWithParameters<TParam>(IMockInfo mockInfo, TParam param);

        /// <summary>
        ///     Logs the fact that a method has been called and didn't return a result.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the method is called.</param>
        void LogAfterMethodCallWithoutResult(IMockInfo mockInfo);

        /// <summary>
        ///     Logs the fact that a method has been called and returned a result.
        /// </summary>
        /// <typeparam name="TResult">The method return type.</typeparam>
        /// <param name="mockInfo">The mock information.</param>
        /// <param name="result">The result returned from the method.</param>
        void LogAfterMethodCallWithResult<TResult>(IMockInfo mockInfo, TResult result);

        /// <summary>
        ///     Logs the fact that an exception was thrown when calling a method.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the method is called.</param>
        /// <param name="exception">The exception that was thrown.</param>
        void LogMethodCallException(IMockInfo mockInfo, Exception exception);

        #endregion

        #region Property logs

        /// <summary>
        ///     Logs the fact that an property is being read from.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the value is read.</param>
        void LogBeforePropertyGet(IMockInfo mockInfo);

        /// <summary>
        ///     Logs the fact that an property has been read from.
        /// </summary>
        /// <typeparam name="TValue">The type of the property.</typeparam>
        /// ram>
        /// <param name="mockInfo">Information about the mock through which the value is read.</param>
        /// <param name="value">The value that was read.</param>
        void LogAfterPropertyGet<TValue>(IMockInfo mockInfo, TValue value);

        /// <summary>
        ///     Logs the fact that reading from an property threw an exception.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the value is read.</param>
        /// <param name="exception">The exception that was thrown.</param>
        void LogPropertyGetException(IMockInfo mockInfo, Exception exception);

        /// <summary>
        ///     Logs the fact that an property is being written to.
        /// </summary>
        /// <typeparam name="TValue">The type of the property.</typeparam>
        /// <param name="mockInfo">Information about the mock through which the value is written.</param>
        /// <param name="value">The value being written.</param>
        void LogBeforePropertySet<TValue>(IMockInfo mockInfo, TValue value);

        /// <summary>
        ///     Logs the fact that and property has been written to.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the value is written.</param>
        void LogAfterPropertySet(IMockInfo mockInfo);

        /// <summary>
        ///     Logs the fact that writing to an property threw an exception.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the value is written.</param>
        /// <param name="exception">The exception that was thrown.</param>
        void LogPropertySetException(IMockInfo mockInfo, Exception exception);

        #endregion
    }
}
