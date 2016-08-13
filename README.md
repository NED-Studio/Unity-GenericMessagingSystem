# Generic Messaging System
------
**Generic Messaging System** adalah messaging system for Unity game engine which implementing Generic class to store instance of handler.

## How to use
1. Download *.unitypackage release from [Release Page](../../releases)
2. Import to your Unity project
3. Create New Class which extending BaseMessagingManager class
4. Overite abstract method **BaseMessagingManager.CreateAllStorage()** and **BaseMessagingManager.DestroyAllStorage()** using method :

	```
	BaseMessagingManager.CreateStorage<D, I>() where D : IMessageDomain where I : IMessageListener
	
	BaseMessagingManager.DestroyStorage<D, I>() where D : IMessageDomain where I : IMessageListener
	```

5. Create Interface which extending IMessageListener
6. Create Interface which extending IMessageDomain or use GlobalDomain
7. Create new class which extend IMessageListener and Add or Remove its instrance using :

	```
	BaseMessagingManager.Add<D, I>(I handler) where D : IMessageDomain where I : IMessageListener
	
	BaseMessagingManager.Remove<D, I>(I handler) where D : IMessageDomain where I : IMessageListener
	```

Please look at Sample for more detail 

## Contribution
Please read [CONTRIBUTION.md](./CONTRIBUTION.md) file for detail about contribution.

## Licenses
Please read [LICENSE](./LICENSE) file for detail about lincese.

