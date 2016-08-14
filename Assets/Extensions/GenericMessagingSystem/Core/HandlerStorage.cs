// Licensed to NED Studio.
// See the LICENSE file in the project root for more information.
// Created By Leo Pripos Marbun

using System.Collections.Generic;

namespace NED.GenericMessagingSystem
{
    /// <summary>
    /// Class to message handler object
    /// </summary>
    /// <typeparam name="D">Domain</typeparam>
    /// <typeparam name="I">Interface of handler</typeparam>
    internal static class HandlerStorage<D, I> where D : IMessageDomain where I : IMessageListener
    {
        private static List<I> m_Handlers;

        /// <summary>
        /// Get ready status of Handler
        /// </summary>
        public static bool IsReady
        {
            get { return (m_Handlers != null); }
        }

        /// <summary>
        /// Get all handler collections
        /// </summary>
        public static List<I> Handlers
        {
            get { return m_Handlers; }
            set { m_Handlers = value; }
        }
    }
}
