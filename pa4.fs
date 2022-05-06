// Brandon Wong
// CPSC 3400
// 5/5/2022
// HW4: F# Assignment
// The code that I am submitting is original code and has not been copied
// from another source. I have written and understand all the code 
// I am submitting.

open System

// Part 1
/// Takes in a list of (float, float, float) tuples
/// Returns the maximum cube volume from the list as a float
let rec maxCubeVolume list: float = 
    match list with
    | [] -> 0.0
    | hd :: tl ->
        match hd with 
        | (length, width, height) ->
            let volume = length * width * height
            if  volume > maxCubeVolume tl then volume               
            else maxCubeVolume tl            

// Part 2
/// Takes in a key and a list of (string, int) tuples
/// Returns a list of ints whose string matched the key
let rec findMatches key list: int list = 
    match list with
    | [] -> []
    | hd :: tl -> 
        match hd with
        | (string, num) ->
            if key = string then List.sort(num :: findMatches key tl)                
            else List.sort(findMatches key tl)                

// Part 3
// Tree definition for problem 3
type BST =
    | Empty
    | TreeNode of int * BST * BST

/// Takes in a value and a node
/// Inserts the value at the correct spot and returns resulting tree
/// If value is already in the tree, return the tree without inserting the value
let rec insert value tree: BST =
    match tree with
    | Empty -> TreeNode(value, Empty, Empty)
    | TreeNode(num, left, right) ->
        if value < num then TreeNode(num, insert value left, right)           
        else if value > num then TreeNode(num, left, insert value right)          
        else tree           

/// Takes in a value and a tree
/// Returns true if the value is in the tree or falise if it is not
let rec contains value tree: bool =
    match tree with
    | Empty -> false
    | TreeNode(num, left, right) ->
        if value < num then contains value left
        else if value > num then contains value right
        else true

/// Takes in a Boolean function that takes a single paramater and returns true or false
/// The function tests the value of each node with func and returns the number of 
/// nodes that evaluate to true
let rec count func tree: int =
    match tree with
    | Empty -> 0
    | TreeNode(num, left, right) ->
        if func num then count func left + count func right + 1           
        else count func left + count func right     

/// Takes in a tree
/// Returns the number of nodes that contain even integers
let rec evenCount tree: int =
    match tree with
    | Empty -> 0
    | TreeNode(num, left, right) ->
        if num % 2 = 0 then count (fun x -> x % 2 = 0) left + count (fun x -> x % 2 = 0) right + 1            
        else count (fun x -> x % 2 = 0) left + count (fun x -> x % 2 = 0) right            