// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyMock.cs">
//   Copyright © 2019 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Core
{
    #region Using Directives

    using System;
    using Mocklis.Steps.Missing;

    #endregion

    /// <summary>
    ///     Class that reperesents a mock of a property of a given type. This class cannot be inherited.
    ///     Inherits from the <see cref="Mocklis.Core.MemberMock" /> class.
    ///     Implements the <see cref="Mocklis.Core.ICanHaveNextPropertyStep{TValue}" /> interface.
    /// </summary>
    /// <typeparam name="TValue">The type of the property.</typeparam>
    /// <seealso cref="Mocklis.Core.MemberMock" />
    /// <seealso cref="Mocklis.Core.ICanHaveNextPropertyStep{TValue}" />
    public sealed class PropertyMock<TValue> : MemberMock, ICanHaveNextPropertyStep<TValue>
    {
        private IPropertyStep<TValue> _nextStep = MissingPropertyStep<TValue>.Instance;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyMock{TValue}" /> class.
        /// </summary>
        /// <param name="mockInstance">The instance of the mocklis class through with the mocked member is accessed.</param>
        /// <param name="mocklisClassName">The name of the mocklis class.</param>
        /// <param name="interfaceName">The name of the interface on which the mocked member is defined.</param>
        /// <param name="memberName">The name of the mocked member.</param>
        /// <param name="memberMockName">The name of the property or method used to provide the mocked member with behaviour.</param>
        public PropertyMock(object mockInstance, string mocklisClassName, string interfaceName, string memberName, string memberMockName)
            : base(mockInstance, mocklisClassName, interfaceName, memberName, memberMockName)
        {
        }

        /// <summary>
        ///     Replaces the current 'next' step with a new step.
        /// </summary>
        /// <typeparam name="TStep">The actual type of the new step.</typeparam>
        /// <param name="step">The new step.</param>
        /// <returns>The new step, so that we can add further steps in a fluent fashion.</returns>
        /// <exception cref="ArgumentNullException">step</exception>
        TStep ICanHaveNextPropertyStep<TValue>.SetNextStep<TStep>(TStep step)
        {
            if (step == null)
            {
                throw new ArgumentNullException(nameof(step));
            }

            _nextStep = step;
            return step;
        }

        /// <summary>
        ///     Gets or sets the <typeparamref name="TValue" /> on the mocked property.
        /// </summary>
        /// <value>The value being read or written.</value>
        public TValue Value
        {
            get => _nextStep.Get(this);
            set => _nextStep.Set(this, value);
        }
    }
}
