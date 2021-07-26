# Intention of the sln

## Motivation
based on the premise of this SO question: https://stackoverflow.com/q/67150424/14620975
; and the answer provided by uncle bob:

> There is another problem, though. **When a new enumerator is added** due
> to a change in the requirements, **both sides of the boundary have to change**.
> This **violates the open-closed principle**. We want to be able to
> make changes that **do not affect the higher level side of the boundary**.
> 
> If you **use a string**, instead, then adding the new condition below the
> line does not force any change above the line.
> 
> You may rightly ask **how the high level side learns about the strings** _(values used by the factory)_.
> It turns out that **the high level side can ask the low level side for all the relevant strings**.
> 
> **Thus, by using strings, instead of enums, you can protect the high level code from changes to the lower level requirements.**


## Goal
I'll try to create some examples of a factory first using an enum and then using a string.

Later try adding a new value to the list of possible values to be handled by the factory (initially in the enum), and see how it goes...

# Conclusion

turns out that by using a string, indeed we can be much more effective on managing the impact the low level module has on the high level one.

this happened because declaring the enum type, forced us to place it within the high level module as it was a dependency on the factory's interface itself.

When we changed it into a string, the dep is gone as it became a dep on the .net frmwk itself (a primitive type in the end).
Thus enabling us to move the Factory implementation + the factory's known and handled values into the low level details.

Hence, changing the low level details (handled factgory's values and switch in factory itself) does not affect the high level values at all.

A nice way to structure the 'strings' though is as constants within a class

# Consequences

(+) High and Low modules decoupled completely

(+) Adding a new type for the Factory to handle is completely trivial and within the same module's scope

(-) Handling the string cases might become tricky, implementing a dictionary is definitely recommended but much more verbose and adds overhead code (the dictionary management code)