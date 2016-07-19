# custom_wince_numpad
Implement a numpad in a wince application using c#. You can easily customize the class to make it more versatile (include alpha keys, resize, etc.).

# Usage
Add the dll file into the References of your Wince project. You still need to add the numpad into your form as a control.

```c#
this.Controls.Add(ck.getNumpad());
```

# Include
The current numpad class include the following:  
1. Draggable  
2. Customizable background, button, button-click, text colors.  
3. Show/hide numpad
