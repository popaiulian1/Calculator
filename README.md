# Calculator
A calculator application built with WPF that offers both Standard and Programmer calculation modes.

## Features
### Standard Calculator
- Basic arithmetic operations (addition, subtraction, multiplication, division)
- Advanced mathematical functions:
    - Square root (√x)
    - Square (x²)
    - Reciprocal (1/x)
    - Percentage
- Memory functions (MS, MR, MC, M+, M-)
- Decimal support
- Sign change
- Digit grouping option
- History of calculations shown above the result
- Keyboard support for faster input

### Programmer Calculator
- Basic arithmetic operations
- Bitwise operations (left shift, right shift)
- Number base display and conversion:
    - Hexadecimal (HEX)
    - Decimal (DEC)
    - Octal (OCT)
    - Binary (BIN)
- Memory functions
- Integer calculations

### Technologies Used
- C# programming language
- .NET 8.0
- Windows Presentation Foundation (WPF)
- XAML for UI design

## How to Use
### Standard Mode
1. Launch the application (starts in Standard mode by default)
1. Use the number buttons or keyboard to enter values
1. Perform calculations using the operation buttons
1. View the calculation history above the result
1. Use memory functions to store and recall values

### Programmer Mode
1. Click the "Mode" button in the top-left corner and select "Programmer"
1. Enter values using the number buttons
1. Select the number base (HEX, DEC, OCT, or BIN)
1. Perform calculations including bitwise operations
1. View the value in all number bases simultaneously

### Common Features
- Mode Switching: Click "Mode" button to switch between Standard and Programmer modes
- Memory Functions:
    - MS - Memory Store
    - MR - Memory Recall
    - MC - Memory Clear
    - M+ - Memory Add
    - M- - Memory Subtract
- Clipboard Operations (via Menu):
    - Cut - Cut displayed value to clipboard
    - Copy - Copy displayed value to clipboard
    - Paste - Paste value from clipboard

### Keyboard Shortcuts
- Numbers: 0-9
- Operations:
    - Addition: + or Shift+Plus
    - Subtraction: - or Minus
    - Multiplication: * or Shift+8
    - Division: / or Oem2

### Other Functions:
 - Decimal point: . or Decimal
 - Calculate: Enter
 - Clear: ESC
 - Backspace: Removes last digit
 - Percentage: Shift+5
 - Sign change: F9

### Requirements
- Windows operating system
- .NET 8.0 runtime

### Author
Implemented by: **Popa Marian-Iulian**
