# Custom Pooling System

This branch contains a custom object pooling system in Unity, designed to efficiently manage frequently instantiated and destroyed objects, optimizing performance for scenarios where many objects need to be created, reused, and destroyed rapidly.

## Overview

The `PoolingSystem` is a singleton class that manages multiple object pools, each defined by a prefab and its maximum pool size. It maintains a queue for each pool, enabling objects to be spawned, reused, and returned to the pool as needed. This system is particularly useful in games with high object counts and frequent physics interactions, helping to:

- Minimize object instantiation overhead during gameplay
- Reduce memory allocation and garbage collection
- Improve overall performance

## Key Features

- **Singleton Pattern**: Ensures a single, globally accessible instance of the `PoolingSystem`.
- **Dynamic Pool Initialization**: Initializes pools for specified prefabs and sizes at runtime.
- **Object Reuse**: Spawns objects from pools without re-instantiation, reducing runtime overhead.
- **Automatic Recycling**: Returns objects to the pool when no longer needed, allowing them to be reused and minimizing performance costs.

## Usage

1. **Setup Pools**: Define your pools by adding `Pool` instances to the `pools` list in the inspector. Each pool should specify:
   - `prefab`: The GameObject to be pooled.
   - `size`: The maximum number of instances for that prefab.
   - `parent`: (Optional) The Transform parent to organize pooled objects.

2. **Spawning Objects**: Use `PoolingSystem.Instance.SpawnFromPool(prefab)` to spawn an object from the pool. If the pool is empty, it reuses the oldest object in the queue.

3. **Returning Objects**: To return an object to the pool, use `PoolingSystem.Instance.ReturnToPool(prefab, obj)`. This deactivates the object and adds it back to the pool for reuse.

## Code Structure

- **PoolingSystem**: Manages the initialization and handling of all pools.
- **InitializePools()**: Sets up the pools based on the defined prefab and size parameters.
- **SpawnFromPool()**: Activates and retrieves an object from the specified pool.
- **ReturnToPool()**: Deactivates and returns an object to its respective pool.

## Example

```csharp
GameObject enemy = PoolingSystem.Instance.SpawnFromPool(enemyPrefab);
if (enemy != null) {
    enemy.transform.position = spawnPosition;
}

// Return the enemy to the pool after use
PoolingSystem.Instance.ReturnToPool(enemyPrefab, enemy);
