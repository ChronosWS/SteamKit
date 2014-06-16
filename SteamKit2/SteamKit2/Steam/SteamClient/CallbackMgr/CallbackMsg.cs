﻿/*
 * This file is subject to the terms and conditions defined in
 * file 'license.txt', which is part of this source code package.
 */

using System;

namespace SteamKit2
{
    /// <summary>
    /// Represents the base object all callbacks are based off.
    /// </summary>
    public abstract class CallbackMsg
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CallbackMsg"/> class.
        /// </summary>
        protected CallbackMsg()
        {
            JobID = JobID.Invalid;
        }

        /// <summary>
        /// Gets or sets the job ID this callback refers to. If it is not a job callback, it will be <see cref="P:JobID.Invalid" />.
        /// </summary>
        public JobID JobID { get; set; }

        /// <summary>
        /// Determines whether this callback is a certain type.
        /// </summary>
        /// <typeparam name="T">The type to check against.</typeparam>
        /// <returns>
        /// 	<c>true</c> if this callback is the type specified; otherwise, <c>false</c>.
        /// </returns>
        public bool IsType<T>()
            where T : CallbackMsg
        {
            return ( this is T );
        }

        /// <summary>
        /// Invokes the specified handler delegate if the callback matches the type parameter.
        /// </summary>
        /// <typeparam name="T">The type to check against.</typeparam>
        /// <param name="handler">The handler to invoke.</param>
        /// <exception cref="ArgumentNullException">
        /// <c>handler</c> is null.
        /// </exception>
        public void Handle<T>( Action<T> handler )
            where T : CallbackMsg
        {
            if ( handler == null )
                throw new ArgumentNullException( "handler" );

            var callback = this as T;

            if ( callback != null )
            {
                handler( callback );
            }
        }
    }
}
