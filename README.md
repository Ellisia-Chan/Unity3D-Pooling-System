# Generic Pooling System

This branch contains a simple generic object pooling system in Unity, designed to handle a single type of pooled object. It efficiently manages object reuse, making it suitable for scenarios where repeated instantiation and destruction of the same prefab could cause performance issues.

## Overview

The `PoolingSystem` class is a singleton that initializes a fixed number of instances of a specified prefab. These instances are stored in a list and reused as needed, reducing the overhead associated with frequently creating and destroying objects.

This pooling system aims to:
- Minimize instantiation overhead for frequently used objects
- Improve performance in scenarios where a single type of object is used repeatedly
- Simplify the pooling implementation for projects that only need one type of pooled object

## Key Features

- **Singleton Pattern**: Ensures a single, globally accessible instance of the `PoolingSystem`.
- **Pre-Pooled Objects**: Instantiates a set number of objects at startup, based on the specified prefab and amount.
- **Simple Reuse System**: Returns the next inactive object from the pool when requested.

## Usage

1. **Configure the Pool**: In the Unity Inspector, set:
   - `cubePrefab`: The prefab to be pooled.
   - `cubeParent`: (Optional) The Transform parent for organizing pooled objects.
   - `amountToPool`: The maximum number of instances to pool.

2. **Getting Pooled Objects**: Call `PoolingSystem.Instance.GetPooledObject()` to retrieve an inactive object from the pool. This returns an existing instance if available; otherwise, it returns `null` if all instances are active.

## Code Structure

- **PoolingSystem**: Manages initialization and object retrieval.
- **Start()**: Instantiates and deactivates objects based on the specified pool size at startup.
- **GetPooledObject()**: Checks for an inactive object in the list and returns it for use.

## Example

```csharp
GameObject cube = PoolingSystem.Instance.GetPooledObject();
if (cube != null) {
    cube.SetActive(true);
    cube.transform.position = spawnPosition;
}
```
## Preview
![image](https://github.com/user-attachments/assets/fe20712b-dfa8-4ac7-bc3d-b24a9c44bb0e)
