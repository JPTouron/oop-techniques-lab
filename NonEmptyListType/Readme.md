# Intention of the sln

## Motivation
based on the article's arguments: https://lexi-lambda.github.io/blog/2019/11/05/parse-don-t-validate/
a solution to a very common problem: how to validate (rather parse) input data, based on this definition of these actions:

>Consider: what is a parser? Really, a parser is just a function that consumes less-structured input and produces more-structured output

The article proposes a haskell code example where a list is defined in such a type that it cannot be empty:

`data NonEmpty a = a :| [a]`

The list implementation should be:

`nonEmpty :: [a] -> Maybe (NonEmpty a)`


## Goal
I'll try to create a c# type that enables this check within a Type, so if the type is used in an input an error should pop in compile-time instead of run-time as much as possible