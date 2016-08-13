// Licensed to NED Studio.
// See the LICENSE file in the project root for more information.
// Created By Leo Pripos Marbun

using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

namespace NED.GenericMessaingSystem
{
    /// <summary>
    /// Base class for All Messaging Manager
    /// </summary>
    public abstract class BaseMessagingManager : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField]
        protected bool EnableDebug = false;
#endif

        #region Logic Process Function
        /// <summary>
        /// Called automaticly by Internal Unity
        /// Call <see cref="CreateAllStorage()"/> in implementation
        /// </summary>
        protected virtual void Awake()
        {
#if UNITY_EDITOR
            if (EnableDebug) Debug.Log("Awake");
#endif
            CreateAllStorage();
        }

        /// <summary>
        /// Called automaticly by Internal Unity
        /// Call <see cref="DestoryAllStorage()"/> in implementation
        /// </summary>
        protected virtual void OnDestroy()
        {
#if UNITY_EDITOR
            if (EnableDebug) Debug.Log("OnDestroy");
#endif
            DestoryAllStorage();
        }

        /// <summary>
        /// Proces to create all storage, called in Awake in MonoBehaviour lifecycle
        /// </summary>
        protected abstract void CreateAllStorage();

        /// <summary>
        /// Proces to destroy all storage, called in OnDestroy in MonoBehaviour lifecycle
        /// </summary>
        protected abstract void DestoryAllStorage();
        #endregion

        #region Message Function
        /// <summary>
        /// Create storage for spesific listener interface for spesific domain
        /// </summary>
        /// <typeparam name="I">Interface of listerner</typeparam>
        public void CreateStorage<D, I>() where D : IMessageDomain where I : IMessageListener
        {
#if UNITY_EDITOR
            if (EnableDebug) Debug.Log("CreateStorage<" + typeof(D).ToString() + "," + typeof(I).ToString() + ">()");
#endif

            HandlerStorage<D, I>.Handlers = new List<I>();
        }

        /// <summary>
        /// Destroy storage for spesific listener for spesific domain
        /// </summary>
        /// <typeparam name="I">Interface of listerner</typeparam>
        public void DestroyStorage<D, I>() where D : IMessageDomain where I : IMessageListener
        {
#if UNITY_EDITOR
            if (EnableDebug) Debug.Log("DestroyStorage<" + typeof(D).ToString() + "," + typeof(I).ToString() + ">()");
#endif

            HandlerStorage<D, I>.Handlers = null;
        }

        /// <summary>
        /// Add listener handler for spesific listener interface in spesific domain
        /// </summary>
        /// <typeparam name="I">Interface of listerner</typeparam>
        /// <param name="handler">Listener handler</param>
        public void Add<D, I>(I handler) where D : IMessageDomain where I : IMessageListener
        {
#if UNITY_EDITOR
            if (EnableDebug) Debug.Log("Add<" + typeof(D).ToString() + "," + typeof(I).ToString() + ">()");
#endif

            Assert.IsNotNull<List<I>>(HandlerStorage<D, I>.Handlers, "Handler storage not created yet!");

            HandlerStorage<D, I>.Handlers.Add(handler);
        }

        /// <summary>
        /// Remove listener handler for spesific listener interface in global domain
        /// </summary>
        /// <typeparam name="I">Interface of listerner</typeparam>
        /// <param name="handler">Listener handler</param>
        public void Remove<D, I>(I handler) where D : IMessageDomain where I : IMessageListener
        {
#if UNITY_EDITOR
            if (EnableDebug) Debug.Log("Remove<" + typeof(D).ToString() + "," + typeof(I).ToString() + ">()");
#endif

            if (HandlerStorage<D, I>.Handlers != null)
            {
                HandlerStorage<D, I>.Handlers.Remove(handler);

                if (HandlerStorage<D, I>.Handlers.Count == 0)
                {
                    HandlerStorage<D, I>.Handlers = null;
                }
            }
        }

        /// <summary>
        /// Boardcast message to all listener handler in spesific domain synchronously
        /// </summary>
        /// <typeparam name="I">Interface of listerner</typeparam>
        /// <param name="action">Delegate function which calling handler method</param>
        public void Broadcast<D, I>(Action<I> action) where D : IMessageDomain where I : IMessageListener
        {
#if UNITY_EDITOR
            if (EnableDebug) Debug.Log("Broadcast<" + typeof(D).ToString() + "," + typeof(I).ToString() + ">()");
#endif

            if (HandlerStorage<D, I>.Handlers != null)
            {
                var handlersCount = HandlerStorage<D, I>.Handlers.Count;
                for (var i = 0; i < handlersCount; i++)
                {
                    action(HandlerStorage<D, I>.Handlers[i]);
                }
            }
        }

        /// <summary>
        /// Boardcast message to all listener handler in global domain synchronously using StartCouroutine()
        /// </summary>
        /// <typeparam name="I">Interface of listerner</typeparam>
        /// <param name="action">Delegate function which calling handler method</param>
        /// <returns>yield return null</returns>
        public IEnumerator BroadcastAsync<D, I>(Action<I> action) where D : IMessageDomain where I : IMessageListener
        {
#if UNITY_EDITOR
            if (EnableDebug) Debug.Log("BroadcastAsync<" + typeof(D).ToString() + "," + typeof(I).ToString() + ">()");
#endif
            yield return null;

            Broadcast<D, I>(action);
        }
        #endregion
    }
}
