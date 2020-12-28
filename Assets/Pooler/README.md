# Unity Bedrock - Pooler

A lightweight, extensible way of working with Pools in Unity.
Comes with built-in support for pooling Game Objects, but it can also be used for pooling any kind of object.

## UPM Package

### GitHub

You can download the asset manually from the [GitHub releases](https:/
/github.com/Unity-Bedrock/Pooler/releases)...

Or you can import directly via the Unity Package Manager by using the following Git Urls:

- Latest release - `https://github.com/Unity-Bedrock/Pooler.git?path=Assets/Pooler`
- Particular release - e.g. `https://github.com/Unity-Bedrock/Pooler.git?path=Assets/Pooler#1.0.0` (replace 1.0.0 with desired version)

### OpenUPM

[![openupm](https://img.shields.io/npm/v/com.unity-bedrock.pooler?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.unity-bedrock.pooler/)

You can download the package from [openupm](https://openupm.com/packages/com.unity-bedrock.pooler), or run the following command if you have the openupm CLI installed:

```bat
openupm add com.unity-bedrock.pooler
```

## Getting Started

To start using Pooler for Game Objects, attach the `GameObjectPooler` behaviour to any GameObject in your scene, set the `GameObjectPrefab`, `Parent` and optionally, the `InitialCapacity` fields and you are set to go.

You can then access the `Pooler` property inside this behaviour to get new and return unused instances to the pool.

You can call `GetObject()` to retrieve an object from the pool.  

It is also good practise to return the objects once you are done with them in order to be able to reuse or clean them up later. You can return objects with the `ReturnObject(yourObject)` method and clean the unused object store with the `ClearAvailableObjects()` method.

## Extending the Pooler

As mentioned, you can configure the pooler to work with any type of C# objects. In order to do this, you would need to follow the following steps:

1. Create an implementation of the `IFactory` interface that will instantiate the new objects of the type you want to support.

2. Optional: Create an implementation of the `IDisposer` interface that will take care of disposing of unused objects you want to clean up.

3. Optional: Create an implementation of the `IStore` interface to implement custom storage for the pool of objects. The package already comes with a simple implementation you can use called `BaseListStore`, which stores the pool objects into a list.

4. Construct a new instance of the `BasePooler` class with the implementation from the steps above.  

For example:

If you want to support pooling of randomly generated strings, you would create an implementation of the `IFactory<string>` interface with the logic for generating new random strings and then create a new instance of the `BasePooler` as so:

```c#
basePooler = new BasePooler<string>(
    randomStringFactory,    // Factory for creating new objects
    baseListStore1,         // Store for unused objects.
    baseListStore2,         // Store for used objects.
);
```

Notice how the 4th argument is empty. We do not need to dispose of these strings ourselves, the garbage collector will take care of that for us, so there is no need to implement and use a disposer.

## License

[MIT](https://spdx.org/licenses/MIT.html)