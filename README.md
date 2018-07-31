# WFCalculator
A C# WinForms implementation of a standard calculator

The strategy used to create this calculator was string manipulation, utilizing
the DataTable class' Compute method to evaluate a given string in the 
DisplayBox text field (RichTextBox).

Some extra features include parentheses and an Ans button that allows the user 
to use the last answer calculated for efficiency. Additionally, the user is able
to navigate to any cursor position in the textbox and edit expressions. This 
calculator can be used with button clicks (mouse/touchscreen) or the keyboard 
(including the numpad). This is also a DPI Aware WinForms application.
