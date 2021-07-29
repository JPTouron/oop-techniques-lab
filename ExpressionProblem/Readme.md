# Intention of the sln

## Motivation
based on the premise of this SO question: https://stackoverflow.com/q/67150424/14620975
; and the answers provided by uncle bob and mark seeman.

And furthermore Mark's comment:
"When a new enumerator is added due to a change in the requirements, both sides of the boundary have to change" Yes, on the other hand, with the proposed design, while you can add new values to switch on, if you need to add a new capability (a new method), both sides have to change. This is known as the **Expression Problem**. You probably already know that, but I'll leave it here for other interested readers. – Mark Seemann

Expression problem:
https://en.wikipedia.org/wiki/Expression_problem


## Goal
I'll try to create some examples of the Expression problem statement and a couple solutions I think could be plausible to carry onward my every-day programming

# Conclusion
The **expression problem** simply **states that in OOP** it is easy to add new types without affecting existing codebase, but **is very hard to add functions (or any other member) to an existing type without affecting it** (without changing or re compiling it).

**Object Algebra**, is a technique or pattern that is mainly **based on the idea of separating the newly function that is desired to add into a separate type**, with the condition that **such new type extends the original one AND, _this is key_, the original code implements a Generic-typed Abstract Factory**, that through the generic type the client code can define the return types of the methods. The return types are gonna be the actions needed to be performed, and will be leveraging the original code type with the old actions and the new extending code type with the new action.

**This pattern** is very powerful as it essentially **allows the code to be complemented with new actions without the need to recompile or change the existing codebase**.

**However** care and forethought should be put when writing what will become the original codebase to later be extended, since, **if we do not place the Abstract Factory within the original code, it becomes impossible to later leverage this pattern without changing the original codebase**.

## How to use
- Make sure the ProblemStatements project does not automatically compile
- Compile explicitly the ProblemStatements project **once**
- Verify tests pass
- Add a new action in the ProblemSolutions project
- Write tests and verify they pass
- No need ot recompile ProblemStatements project for the second run! :-)

## Useful links:
explanation:
https://github.com/tvdstorm/JoyOfCoding2014

slides of the above explanation: :point_up:
https://speakerdeck.com/joyofcoding/whos-afraid-of-object-algebras-tijs-van-der-storm

expression problem original statement:
https://homepages.inf.ed.ac.uk/wadler/papers/expression/expression.txt
