# TradeCategory
Categorize trades in a bank´s portfolio

To insert a new category into the project:

    Add the new category to the Categories.cs Class and create the bool property IsPoliticallyExposed (in the example) in the ITrade Interface and in the Trade Class, already receiving a value through the constructor. In the ConvertStringToTrade method of the Utilities Class, include the string to Bool conversion, so that the IsPoliticallyExposed property receives this value. At the beginning of the CategorizeTrade method of the Class Trade, include the condition that checks whether the IsPoliticallyExposed property is true or false. If the condition is true, assign the new category to the Trade.
