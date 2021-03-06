// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VerificationFailedException.cs">
//   SPDX-License-Identifier: MIT
//   Copyright © 2019-2020 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Verification
{
    #region Using Directives

    using System;
#if !NETSTANDARD1_3
    using System.Runtime.Serialization;

#endif

    #endregion

    /// <summary>
    ///     Exception class that indicates that at least one item in a tree of verifications has failed.
    ///     Inherits from the <see cref="Exception" /> class.
    /// </summary>
    /// <seealso cref="Exception" />
#if !NETSTANDARD1_3
    [Serializable]
#endif
    public class VerificationFailedException : Exception
    {
        /// <summary>
        ///     Gets the verification result.
        /// </summary>
        public VerificationResult VerificationResult { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VerificationFailedException" /> class with a verification result.
        /// </summary>
        /// <param name="verificationResult">The verification result.</param>
        public VerificationFailedException(VerificationResult verificationResult) : base("Verification failed.")
        {
            VerificationResult = verificationResult;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VerificationFailedException" /> class with a verification result and
        ///     message.
        /// </summary>
        /// <param name="verificationResult">The verification result.</param>
        /// <param name="message">The message.</param>
        public VerificationFailedException(VerificationResult verificationResult, string message) : base(message)
        {
            VerificationResult = verificationResult;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VerificationFailedException" /> class with a verification result, a
        ///     message,
        ///     and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="verificationResult">The verification result.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public VerificationFailedException(VerificationResult verificationResult, string message, Exception innerException) : base(message,
            innerException)
        {
            VerificationResult = verificationResult;
        }

#if !NETSTANDARD1_3
        /// <summary>
        ///     Initializes a new instance of the <see cref="VerificationFailedException" /> class with serialized data.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being
        ///     thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual information about the source or
        ///     destination.
        /// </param>
        protected VerificationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            VerificationResult = (VerificationResult)info.GetValue(nameof(VerificationResult), typeof(VerificationResult));
        }

        /// <summary>
        ///     Sets the <see cref="SerializationInfo" /> with information abouet the exception.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being
        ///     thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual information about the source or
        ///     destination.
        /// </param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(VerificationResult), VerificationResult);
        }
#endif
    }
}
