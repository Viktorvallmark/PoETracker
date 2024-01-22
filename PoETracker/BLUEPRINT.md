# Implementation blueprint 🚀🚀🚀

1. Make a parser for Client.txt that processes information from today's date ✅
2. Make sure that the parser doesn't parse whole of Client.txt every time you run the program. ❌
3. Make code to instantiate the DB. ❌
4. Extract fun data from the parsed information like level ups, deaths etc. ❌
5. Setup database transactions that store this data. ❌

### Keywords to regex for

    - Slain. How many times have I died?
    - ("ClassName") is now level "number". How many times have I leveled up?
    - Successfully allocated passive skill id: mana1478, name: Primal Spirit. Make a heatmap of most allocated passive points?
    Maybe render the skill tree marking the most allocated points, like in Path of Building.

Complaints about C#:

    Why is the Regex class immutable after instantiation?
    Why can you call the Regex constructor with no parameters from only classes derived from the Regex class?
