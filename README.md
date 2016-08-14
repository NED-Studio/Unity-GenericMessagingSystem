# Generic Messaging System
------
**Generic Messaging System** is messaging system for Unity game engine which implementing Generic class to store instance of handler.

## How to use
1. Download *.unitypackage from [Release Page](../../releases)
2. Import to your unity project
3. Create new class which extending BaseMessagingManager class
4. Overite abstract method **BaseMessagingManager.CreateAllStorage()** and **BaseMessagingManager.DestroyAllStorage()**  and using method bellow to create/destroy storage :
	```
	class : BaseMessagingManager
	
	public void CreateStorage<D, I>() where D : IMessageDomain where I : IMessageListener
	
	public void DestroyStorage<D, I>() where D : IMessageDomain where I : IMessageListener
	```

5. Create interface which extending IMessageListener
6. Create interface which extending IMessageDomain to create new domain or use GlobalDomain
7. Create new class which extend IMessageListener as handler class
8. Add/Remove instance of handler using:
	```
	class : BaseMessagingManager
	
	public void Add<D, I>(I handler) where D : IMessageDomain where I : IMessageListener
	
	public void Remove<D, I>(I handler) where D : IMessageDomain where I : IMessageListener
	```
9. Broadcast message using:
	```
	class : BaseMessagingManager
	
	public void Broadcast<D, I>(Action<I> action) where D : IMessageDomain where I : IMessageListener
	
	public IEnumerator BroadcastAsync<D, I>(Action<I> action) where D : IMessageDomain where I : IMessageListener
	```

Please look at sample for more detail.

## Contribution
Please read [CONTRIBUTION.md](./CONTRIBUTION.md) file for detail about contribution.

## Licenses
Please read [LICENSE](./LICENSE) file for detail about lincese.

## Language
* [README(ENGLISH)](./README.md)
* [README(BAHASA)](./README-ID.md)

