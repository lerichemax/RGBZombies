# Gravity

Menu Path : **Force >** **Gravity**

The **Gravity** block applies the given force to particles. To do this, it changes the affected particlesâ€™ velocity.

## Block compatibility

This Block is compatible with the following Contexts:

- [Update](Context-Update.md)

## Block properties

| **Input** | **Type**                 | **Description**                                              |
| --------- | ------------------------ | ------------------------------------------------------------ |
| **Force** | [Vector](Type-Vector.md) | The force vector this block applies. The default value is (0, -9.81, 0) which simulates gravity on Earth. |

## Remarks

This block only affects the particle position if you enable the **Update Position** setting in the [Update Context](Context-Update.md).
