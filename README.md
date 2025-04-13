# WPF Calculator Application

This is a simple **WPF Calculator** application built using **C#** and **.NET Framework 4.8**. The application implements basic arithmetic operations such as addition, subtraction, multiplication, and division, and follows the **MVVM** design pattern for separation of concerns.

## Features
- Basic arithmetic operations: addition, subtraction, multiplication, division.
- Input handling using buttons
- Supports decimal input with up to 5 decimal places.
- Log4net is used for logging.
- Designed using **MVVM** architecture for better code separation and testability.

## Technologies Used
- **C#**
- **WPF (Windows Presentation Foundation)**
- **.NET Framework 4.8**
- **MVVM Pattern**
- **Log4net**
- **Git** (for version control)
- **Visual Studio 2022**

## Upcoming Improvements & Features
The following improvements and additional features are planned for future versions of the application:

### 1. **Direct Text Input with Validation**
   - Enable users to enter numbers directly via `TextBox`.
   - Use `ValidationRule` to validate input format (e.g., allowing only numeric values with up to 5 decimal digits).

### 2. **Custom UI Enhancements**
   - Implement a custom `ButtonBase` and derived button class with support for a `DisplayCharacter` dependency property.
   - Use WPF styling and control templates to enhance the UI, providing a more modern and themed look.
   - Allow runtime UI customization with custom themes (light/dark mode).

### 3. **Scientific Calculator Mode**
   - Extend the application to include scientific functions like square root, power, trigonometric functions (sin, cos, tan), logarithms, etc.
   - A toggle button to switch between basic and scientific modes.

### 4. **Error Handling & User Feedback**
   - Improve error handling to provide clear feedback when invalid operations are attempted (e.g., dividing by zero).
   - Show user-friendly error messages in the UI (e.g., "Cannot divide by zero").

### 5. **Multi-Operand and Advanced Operations**
   - Implement support for multi-operand calculations (e.g., `2 + 3 * 5` should calculate correctly).
   - Allow advanced mathematical functions such as factorial, percentage, etc.
