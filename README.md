# Group9_FOP_Console
This is a console application about three little pigs using C#. Storytelling with choices for scenarios
# Code Guide: The Three Little Pigs

This guide explains how `Program.cs` runs. The program is a small interactive story: the reader makes two choices, reads one of four story variations, and can restart.

## Run the program

Open a terminal in this folder and run:

```text
dotnet run
```

The program targets .NET 8. It can also be opened as a project in Visual Studio with `ThreePigsStory.csproj`.

## The overall flow

1. `Main(string[] args)` starts the program. `args` is included as the standard command-line entry-point parameter, though this story does not currently use it.
2. A `while` loop shows the story. It repeats if the reader selects the replay option at the end.
3. The program prints the title, introduces the pigs, and tells the opening scene.
4. `AskChoice` displays two menus and keeps asking until each answer is a valid number.
5. `TellEnding` uses a `switch` to choose Pip's main action. The second answer selects details inside that story path.
6. The program shows an ending and asks whether to restart.

## Arrays

Arrays store several related strings under one name. For example, `pigNames`, `houseMaterials`, and `houseStrength` each have three items. The items match by position: `pigNames[0]` is Pip, `houseMaterials[0]` is straw, and `houseStrength[0]` describes Pip's house.

`firstChoices` and `secondChoices` store the menu text. `AskChoice` accepts an array, then prints each item using a `for` loop. C# array positions start at zero, so the code adds one when showing menu numbers to the reader.

## Loops

- The `while (playAgain)` loop in `Main` repeats the entire story when requested.
- The `while (!validChoice)` loop in `AskChoice` repeats a menu until a valid number is entered.
- `for` loops print the pig information and the choices, and search the house-material array.
- A `foreach` loop checks each item in the `kindWords` array in `IsTheWolfPolite`.

## Input checking and nested `if` statements

`AskChoice` reads a line of text and uses `int.TryParse` to check whether it is a number. Nested `if` statements then check that the number is at least 1 and no greater than the number of menu options. If any check fails, the program displays an error and asks again.

The story methods also use nested `if` statements. For example, `TellStayInsideStory` first checks the second choice; inside that branch it calls `IsTheWolfPolite` or `AreBrothersReady` to choose more story text. `TellGetBrothersStory` follows the same pattern for Pip's other action.

In this example, `IsTheWolfPolite` finds `"thank you"` in its word array, and `AreBrothersReady` finds `"bricks"` in the house-material array. Therefore, those helper methods currently return `true`. Their `else` sections demonstrate how a different result could lead to different text.

## `switch` cases

`TellEnding` switches on Pip's first choice:

- `case 1` tells the path where Pip stays inside.
- `case 2` tells the path where Pip gets his brothers.
- `default` is a fallback if an unexpected number reaches the method.

`AskToPlayAgain` has another `switch` for the replay menu. Choosing `1` returns `true`; choosing `2` returns `false`.

## Methods

Each `static` method has one small job. For instance, `ShowHeader` prints the title, `AskChoice` handles a menu, and `TellGetBrothersStory` prints that story path. Keeping jobs separate makes the program easier to read and change.

`static` means these methods and arrays belong to the `Program` class, so `Main` can call them directly. The return type says what a method gives back: `void` means it returns no value, `int` is used for a selected menu number, and `bool` is used for yes/no results.

## Console colors

The program changes `Console.ForegroundColor` for headings, prompts, errors, and endings. `Console.ResetColor()` restores the terminal's normal text color after each colored section.
