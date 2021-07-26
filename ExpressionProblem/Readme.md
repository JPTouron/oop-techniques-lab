# Intention of the sln

## Motivation
based on the premise of this SO question: https://stackoverflow.com/q/67150424/14620975
; and these answers provided by uncle bob and mark seeman.

And furthermore Mark's comment:
"When a new enumerator is added due to a change in the requirements, both sides of the boundary have to change" Yes, on the other hand, with the proposed design, while you can add new values to switch on, if you need to add a new capability (a new method), both sides have to change. This is known as the **Expression Problem**. You probably already know that, but I'll leave it here for other interested readers. – Mark Seemann

Expression problem:
https://en.wikipedia.org/wiki/Expression_problem


## Goal
I'll try to create some examples of the Expression problem statement and a couple solutions I think could be plausible to carry onward my every-day programming