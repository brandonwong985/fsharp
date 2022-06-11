# fsharp
Assignment for CPSC-3400 Languages and Computation at Seattle University.
Practicing F# and functional programming practices.

## Part 1
<code>maxCubeVolume</code> takes in a list of floating point tuples that represent the dimensions of a cube (length, width, and height) and returns the volume of the cube that has the largest volume.
```
> maxCubeVolume [(2.1, 3.4, 1.8); (4.7, 2.8, 3.2); (0.9, 6.1, 1.0); (3.2, 5.4, 9.9)];;
val it : float = 171.072
> maxCubeVolume [(0.33, 0.66, 2.75)];;
val it : float = 0.59895
> maxCubeVolume [];;
val it : float = 0.0
```
## Part 2
<code>findMatches</code> takes a string and a list of tuples as arguments. Each element of the list will be a tuple consisting of a string and an int. <code>findMatches</code> finds all the tuples for which the string matches the first argument and collect all of the corresponding integers, sorted in ascending order.
```
> findMatches "A" [("A",5); ("BB",6); ("AA",9); ("A",0)];;
val it : int list = [0; 5]
> findMatches "BB" [("A",5); ("BB",6); ("AA",9); ("A",0)];;
val it : int list = [6]
> findMatches "X" [("A",5); ("BB",6); ("AA",9); ("A",0)];;
val it : int list = []
> findMatches "A" [];;
val it : int list = []
```
## Part 3
Binary search tree with the following type definition:
```
type BST =
    | Empty
    | TreeNode of int * BST * BST
```
The BST has the following functions:
1. <code>insert value tree</code>: inserts the value into the tree and returns the resulting tree. The resulting tree does *NOT* need to be balanced. If the value already exists in the tree, return the tree without inserting the value
```
> let bt1 = insert 10 Empty;;
val bt1 : BST = TreeNode (10,Empty,Empty)
> let bt2 = insert 5 bt1;;
val bt2 : BST = TreeNode (10,TreeNode (5,Empty,Empty),Empty)
> let bt3 = insert 3 bt2;;
val bt3 : BST =
  TreeNode (10,TreeNode (5,TreeNode (3,Empty,Empty),Empty),Empty)
> let bt4 = insert 17 bt3;;
val bt4 : BST =
  TreeNode
    (10,TreeNode (5,TreeNode (3,Empty,Empty),Empty),TreeNode (17,Empty,Empty))
> let bt5 = insert 12 bt4;;
val bt5 : BST =
  TreeNode
    (10,TreeNode (5,TreeNode (3,Empty,Empty),Empty),
     TreeNode (17,TreeNode (12,Empty,Empty),Empty))
```
2. <code>contains value tree</code>: returns true if the value is in the tree or false if it is not
```
> contains 17 bt5;;
val it : bool = true
> contains 4 bt5;;
val it : bool = false
```
3. <code>count func tree</code>: The parameter func is a Boolean function that takes a single parameter and returns true or false. The function tests the value of each node with func and returns the number of nodes that evalutate to true.
```
> count gtTen bt5;;
val it : int = 2
```
4. <code>evenCount tree</code>: Returns the number of nodes that contain even integers. This function does not call any other function by name, except for the <code>count</code> function and lambda functions (which do not have a name)
```
> evenCount bt5;;
val it : int = 2
```
   
